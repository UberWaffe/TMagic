﻿using RimWorld;
using System;
using Verse;
using AbilityUser;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace TorannMagic
{
    [StaticConstructorOnStartup]
    class Verb_PhaseStrike : Verb_UseAbility  
    {
        bool arg_41_0;
        bool arg_42_0;
        MightPowerSkill pwr;
        MightPowerSkill ver;
        MightPowerSkill str;

        float weaponDPS = 0;
        float dmgMultiplier = 1;
        float pawnDPS = 0;
        float skillMultiplier = 1;
        ThingWithComps weaponComp;
        int dmgNum = 0;
        bool flag10;

        bool validTarg;
        IntVec3 arg_29_0;

        private static readonly Color bladeColor = new Color(160f, 160f, 160f);
        private static readonly Material bladeMat = MaterialPool.MatFrom("Spells/cleave", false);

        public override bool CanHitTargetFrom(IntVec3 root, LocalTargetInfo targ)
        {
            if (targ.IsValid && targ.CenterVector3.InBounds(base.CasterPawn.Map) && !targ.Cell.Fogged(base.CasterPawn.Map) && targ.Cell.Walkable(base.CasterPawn.Map))
            {
                if ((root - targ.Cell).LengthHorizontal < this.verbProps.range)
                {
                    //out of range
                    validTarg = true;
                }
                else
                {
                    validTarg = false;
                }
            }
            else
            {
                validTarg = false;
            }
            return validTarg;
        }

        protected override bool TryCastShot()
        {
            bool result = false;
            bool arg_40_0;

            CompAbilityUserMight comp = this.CasterPawn.GetComp<CompAbilityUserMight>();
            pwr = comp.MightData.MightPowerSkill_PhaseStrike.FirstOrDefault((MightPowerSkill x) => x.label == "TM_PhaseStrike_pwr");
            ver = comp.MightData.MightPowerSkill_PhaseStrike.FirstOrDefault((MightPowerSkill x) => x.label == "TM_PhaseStrike_ver");
            str = comp.MightData.MightPowerSkill_global_strength.FirstOrDefault((MightPowerSkill x) => x.label == "TM_global_strength_pwr");

            if (this.CasterPawn.equipment.Primary != null && !this.CasterPawn.equipment.Primary.def.IsRangedWeapon)
            {
                weaponComp = base.CasterPawn.equipment.Primary;
                weaponDPS = weaponComp.GetStatValue(StatDefOf.MeleeWeapon_AverageDPS, false) * .7f;
                dmgMultiplier = weaponComp.GetStatValue(StatDefOf.MeleeWeapon_DamageMultiplier, false);
                pawnDPS = base.CasterPawn.GetStatValue(StatDefOf.MeleeDPS, false);
                skillMultiplier = (.8f + (.025f * str.level));
                dmgNum = Mathf.RoundToInt(skillMultiplier * dmgMultiplier * (pawnDPS + weaponDPS));
                ModOptions.SettingsRef settingsRef = new ModOptions.SettingsRef();
                if (!this.CasterPawn.IsColonistPlayerControlled && settingsRef.AIHardMode)
                {
                    dmgNum += 10;
                }

                if (this.currentTarget != null && base.CasterPawn != null)
                {
                    arg_29_0 = this.currentTarget.Cell;
                    Vector3 vector = this.currentTarget.CenterVector3;
                    arg_40_0 = this.currentTarget.Cell.IsValid;
                    arg_41_0 = vector.InBounds(base.CasterPawn.Map);
                    arg_42_0 = true; // vector.ToIntVec3().Standable(base.CasterPawn.Map);
                }
                else
                {
                    arg_40_0 = false;
                }
                bool flag = arg_40_0;
                bool flag2 = arg_41_0;
                bool flag3 = arg_42_0;
                if (flag)
                {
                    if (flag2 & flag3)
                    {
                        Pawn p = this.CasterPawn;
                        Map map = this.CasterPawn.Map;
                        IntVec3 pLoc = this.CasterPawn.Position;
                        if (p.IsColonistPlayerControlled)
                        {
                            try
                            {
                                ThingSelectionUtility.SelectNextColonist();
                                this.CasterPawn.DeSpawn();
                                //p.SetPositionDirect(this.currentTarget.Cell);
                                SearchForTargets(arg_29_0, (2f + (float)(.5f * ver.level)), map, p);
                                GenSpawn.Spawn(p, this.currentTarget.Cell, map);
                                DrawBlade(p.Position.ToVector3Shifted(), 4f + (float)(ver.level));
                                p.drafter.Drafted = true;                                
                                ThingSelectionUtility.SelectPreviousColonist();
                            }
                            catch
                            {
                                if(!CasterPawn.Spawned)
                                {
                                    GenSpawn.Spawn(p, pLoc, map);
                                    p.drafter.Drafted = true;
                                    Log.Message("Phase strike threw exception - despawned pawn has been recovered at casting location");
                                }
                            }
                            this.Ability.PostAbilityAttempt();

                        }
                        else
                        {
                            this.CasterPawn.DeSpawn();
                            SearchForTargets(arg_29_0, (2f + (float)(.5f * ver.level)), map, p);
                            GenSpawn.Spawn(p, this.currentTarget.Cell, map);
                            DrawBlade(p.Position.ToVector3Shifted(), 4f + (float)(ver.level));
                        }
                    
                        //this.CasterPawn.SetPositionDirect(this.currentTarget.Cell);
                        //base.CasterPawn.SetPositionDirect(this.currentTarget.Cell);
                        //this.CasterPawn.pather.ResetToCurrentPosition();
                        result = true;
                    }
                    else
                    {
                    
                        Messages.Message("InvalidTargetLocation".Translate(), MessageTypeDefOf.RejectInput);
                    }
                }
            }
            else
            {
                Messages.Message("MustHaveMeleeWeapon".Translate(new object[]
                {
                    this.CasterPawn.LabelCap
                }), MessageTypeDefOf.RejectInput);
                return false;
            }

            this.burstShotsLeft = 0;
            //this.ability.TicksUntilCasting = (int)base.UseAbilityProps.SecondsToRecharge * 60;
            return result;
        }

        public void SearchForTargets(IntVec3 center, float radius, Map map, Pawn pawn)
        {
            Pawn victim = null;
            IntVec3 curCell;            
            IEnumerable<IntVec3> targets = GenRadial.RadialCellsAround(center, radius, true);
            for (int i = 0; i < targets.Count(); i++)
            {
                curCell = targets.ToArray<IntVec3>()[i];
                MoteMaker.ThrowDustPuff(curCell, map, .2f);
                if (curCell.InBounds(map) && curCell.IsValid)
                {
                    victim = curCell.GetFirstPawn(map);
                }

                if (victim != null && victim.Faction != pawn.Faction)
                {
                    if(Rand.Chance(.1f + .15f*pwr.level))
                    {
                        dmgNum *= 3;
                        MoteMaker.ThrowText(victim.DrawPos, victim.Map, "Critical Hit", -1f);
                    }
                    DrawStrike(center, victim.Position.ToVector3(), map);
                    damageEntities(victim, null, dmgNum, TMDamageDefOf.DamageDefOf.TM_PhaseStrike);
                }
                targets.GetEnumerator().MoveNext();
            }
        }

        public void DrawStrike(IntVec3 center, Vector3 strikePos, Map map)
        {
            TM_MoteMaker.ThrowCrossStrike(strikePos, map, 1f);
            TM_MoteMaker.ThrowBloodSquirt(strikePos, map, 1.5f);
        }

        private void DrawBlade(Vector3 center, float magnitude)
        {

            Vector3 vector = center;
            vector.y = Altitudes.AltitudeFor(AltitudeLayer.MoteOverhead);
            Vector3 s = new Vector3(magnitude, magnitude, (1.5f * magnitude));
            Matrix4x4 matrix = default(Matrix4x4);

            for (int i = 0; i < 6; i++)
            {
                float angle = Rand.Range(0, 360);
                matrix.SetTRS(vector, Quaternion.AngleAxis(angle, Vector3.up), s);
                Graphics.DrawMesh(MeshPool.plane10, matrix, Verb_PhaseStrike.bladeMat, 0);
            }
        }

        public void damageEntities(Pawn victim, BodyPartRecord hitPart, int amt, DamageDef type)
        {
            DamageInfo dinfo;
            amt = (int)((float)amt * Rand.Range(.5f, 1.5f));
            dinfo = new DamageInfo(type, amt, (float)-1, this.CasterPawn, hitPart, null, DamageInfo.SourceCategory.ThingOrUnknown);
            dinfo.SetAllowDamagePropagation(false);
            victim.TakeDamage(dinfo);
        }
    }
}
