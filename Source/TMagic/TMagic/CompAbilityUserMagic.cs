﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using RimWorld;
using UnityEngine;
using AbilityUser;
using Verse;
using Verse.Sound;

namespace TorannMagic
{
    [CompilerGenerated]
    [Serializable]
    [StaticConstructorOnStartup]
    public class CompAbilityUserMagic : CompAbilityUser
    {
        public string LabelKey = "TM_Magic";

        private static readonly Color shieldColor = new Color(90f, 0f, 0f);
        private static readonly Material shieldMat = MaterialPool.MatFrom("Other/Shield", ShaderDatabase.Transparent, CompAbilityUserMagic.shieldColor);
        private static readonly Color manaShieldColor = new Color(127f, 0f, 255f);
        private static readonly Material manaShieldMat = MaterialPool.MatFrom("Other/Shield", ShaderDatabase.Transparent, CompAbilityUserMagic.manaShieldColor);

        private static readonly Material mageMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, Color.black);
        private static readonly Color necroMarkColor = new Color(.4f, .5f, .25f);
        private static readonly Material necroMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, CompAbilityUserMagic.necroMarkColor);
        private static readonly Color summonerMarkColor = new Color(.8f, .4f, .0f);
        private static readonly Material summonerMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, CompAbilityUserMagic.summonerMarkColor);
        private static readonly Material druidMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, Color.green);
        private static readonly Material paladinMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, Color.white);
        private static readonly Material warlockMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, Color.magenta);
        private static readonly Material lightningMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, Color.yellow);
        private static readonly Material iceMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, Color.blue);
        private static readonly Material fireMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, Color.red);
        private static readonly Color priestMarkColor = new Color(1f, 1f, .55f); 
        private static readonly Material priestMarkMat = MaterialPool.MatFrom("Other/MageMark", ShaderDatabase.Transparent, CompAbilityUserMagic.priestMarkColor);

        private static readonly Material enchantMark = MaterialPool.MatFrom("Items/Gemstones/arcane_minor");

        public bool firstTick = false;
        public bool magicPowersInitialized = false;
        public int magicXPRate = 1000;
        public int lastXPGain = 0;
        private int age = -1;
        private bool doOnce = true;

        private float IF_RayofHope_eff = 0.10f;
        private float IF_Firebolt_eff = 0.10f;
        private float IF_Fireclaw_eff = 0.12f;
        private float IF_Fireball_eff = 0.10f;
        private float IF_Firestorm_eff = 0.10f;
        private float HoF_Soothe_eff = 0.10f;
        private float HoF_Icebolt_eff = 0.10f;
        private float HoF_FrostRay_eff = 0.10f;
        private float HoF_Snowball_eff = 0.08f;
        private float HoF_Blizzard_eff = 0.10f;
        private float HoF_Rainmaker_eff = 0.15f;
        private float SB_AMP_eff = 0.10f;
        private float SB_LightningBolt_eff = 0.08f;
        private float SB_LightningCloud_eff = 0.08f;
        private float SB_LightningStorm_eff = 0.05f;
        private float SB_EyeOfTheStorm_eff = 0.05f;
        private float A_Shadow_eff = 0.10f;
        private float A_MagicMissile_eff = 0.10f;
        private float A_Blink_eff = 0.15f;
        private float A_Summon_eff = 0.15f;
        private float A_Teleport_eff = 0.10f;
        private float A_FoldReality_eff = 0.08f;
        private float P_Heal_eff = 0.10f;
        private float P_Shield_eff = 0.10f;
        private float P_ValiantCharge_eff = 0.10f;
        private float P_Overwhelm_eff = 0.10f;
        private float S_SummonElemental_eff = 0.08f;
        private float S_SummonExplosive_eff = 0.15f;
        private float S_SummonMinion_eff = 0.10f;
        private float S_SummonPylon_eff = 0.10f;
        private float D_Poison_eff = 0.10f;
        private float D_SootheAnimal_eff = 0.10f;
        private float D_Regenerate_eff = 0.10f;
        private float D_CureDisease_eff = 0.12f;
        private float D_RegrowLimb_eff = 0.08f;
        private float N_RaiseUndead_eff = 0.05f;
        private float N_DeathMark_eff = 0.08f;
        private float N_FogOfTorment_eff = 0.10f;
        private float N_ConsumeCorpse_eff = 0.0f;
        private float N_CorpseExplosion_eff = 0.08f;
        private float PR_AdvancedHeal_eff = 0.12f;
        private float PR_Purify_eff = 0.08f;
        private float PR_HealingCircle_eff = 0.08f;
        private float PR_BestowMight_eff = 0.08f;
        private float PR_Resurrection_eff = 0.05f;

        private float global_eff = 0.03f;

        public bool spell_Rain = false;
        public bool spell_Blink = false;
        public bool spell_Teleport = false;
        public bool spell_Heal = false;
        public bool spell_Heater = false;
        public bool spell_Cooler = false;
        public bool spell_DryGround = false;
        public bool spell_WetGround = false;
        public bool spell_ChargeBattery = false;
        public bool spell_SmokeCloud = false;
        public bool spell_Extinguish = false;
        public bool spell_EMP = false;
        public bool spell_Firestorm = false;
        public bool spell_Blizzard = false;
        public bool spell_SummonMinion = false;
        public bool spell_TransferMana = false;
        public bool spell_SiphonMana = false;
        public bool spell_RegrowLimb = false;
        public bool spell_EyeOfTheStorm = false;
        public bool spell_ManaShield = false;
        public bool spell_FoldReality = false;
        public bool spell_Resurrection = false;
        public bool spell_PowerNode = false;

        public float maxMP = 1;
        public float mpRegenRate = 1;
        public float coolDown = 1;
        public float mpCost = 1;
        public float xpGain = 1;

        public List<Thing> summonedMinions = new List<Thing>();
        private bool dismissMinionSpell = false;
        private bool dismissUndeadSpell = false;

        private MagicData magicData = null;
        public MagicData MagicData
        {
            get
            {
                bool flag = this.magicData == null && this.IsMagicUser;
                if (flag)
                {
                    this.magicData = new MagicData(this);
                }
                return this.magicData;
            }
        }

        public override void PostDraw()
        {
            ModOptions.SettingsRef settingsRef = new ModOptions.SettingsRef();
            if (settingsRef.AIMarking && !base.AbilityUser.IsColonistPlayerControlled && this.IsMagicUser)
            {
                DrawMageMark();                
            }
            Enchantment.CompEnchant compEnchant = this.Pawn.GetComp<Enchantment.CompEnchant>();
            try
            {
                if (this.IsMagicUser && compEnchant != null && compEnchant.enchantingContainer.Count > 0)
                {
                    DrawEnchantMark();
                }
            }
            catch
            {
                Enchantment.CompProperties_Enchant newEnchantComp = new Enchantment.CompProperties_Enchant();
                this.Pawn.def.comps.Add(newEnchantComp);
            }
            base.PostDraw();
        }

        public static List<TMAbilityDef> MagicAbilities = null;  
        
        public int LevelUpSkill_global_regen(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_global_regen.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }        
        public int LevelUpSkill_global_eff(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_global_eff.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_global_spirit(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_global_spirit.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        public int LevelUpSkill_RayofHope(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_RayofHope.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }        
        public int LevelUpSkill_Firebolt(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Firebolt.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }        
        public int LevelUpSkill_Fireball(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Fireball.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }        
        public int LevelUpSkill_Fireclaw(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Fireclaw.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }        
        public int LevelUpSkill_Firestorm(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Firestorm.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
                
        public int LevelUpSkill_Soothe(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Soothe.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Icebolt(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Icebolt.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_FrostRay(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FrostRay.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Snowball(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Snowball.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Rainmaker(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Rainmaker.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Blizzard(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Blizzard.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        public int LevelUpSkill_AMP(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_AMP.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_LightningBolt(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningBolt.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_LightningCloud(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningCloud.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_LightningStorm(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningStorm.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_EyeOfTheStorm(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_EyeOfTheStorm.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        public int LevelUpSkill_Shadow(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Shadow.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_MagicMissile(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_MagicMissile.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Blink(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Blink.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Summon(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Summon.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Teleport(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Teleport.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_FoldReality(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FoldReality.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        public int LevelUpSkill_Heal(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Heal.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Shield(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Shield.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_ValiantCharge(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_ValiantCharge.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Overwhelm(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Overwhelm.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        public int LevelUpSkill_SummonMinion(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonMinion.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_SummonPylon(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonPylon.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_SummonExplosive(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonExplosive.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_SummonElemental(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonElemental.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        public int LevelUpSkill_Poison(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Poison.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_SootheAnimal(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SootheAnimal.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Regenerate(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Regenerate.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_CureDisease(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_CureDisease.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_RegrowLimb(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_RegrowLimb.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        public int LevelUpSkill_RaiseUndead(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_RaiseUndead.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_DeathMark(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_DeathMark.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_FogOfTorment(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FogOfTorment.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_ConsumeCorpse(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_ConsumeCorpse.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_CorpseExplosion(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_CorpseExplosion.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        public int LevelUpSkill_AdvancedHeal(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_AdvancedHeal.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Purify(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Purify.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_HealingCircle(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_HealingCircle.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_BestowMight(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_BestowMight.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }
        public int LevelUpSkill_Resurrection(string skillName)
        {
            int result = 0;
            MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Resurrection.FirstOrDefault((MagicPowerSkill x) => x.label == skillName);
            bool flag = magicPowerSkill != null;
            if (flag)
            {
                result = magicPowerSkill.level;
            }
            return result;
        }

        private void SingleEvent()
        {
            if (this.Pawn.def.HasComp(typeof(Enchantment.CompEnchant)))
            {
                Enchantment.CompEnchant compEnchant = this.Pawn.GetComp<Enchantment.CompEnchant>();
                compEnchant.Initialize(compEnchant.props);
                compEnchant.enchantingContainer.Clear();
            }
            this.doOnce = false;            
        }

        public override void CompTick()
        {
            bool flag = base.AbilityUser != null;
            if (flag)
            {
                bool spawned = base.AbilityUser.Spawned;
                if (spawned)
                {
                    bool isMagicUser = this.IsMagicUser;
                    if (isMagicUser) 
                    {
                        bool flag3 = !this.firstTick;
                        if (flag3)
                        {
                            this.PostInitializeTick();
                        }
                        if(this.doOnce)
                        {
                            SingleEvent();
                        }
                        base.CompTick();
                        if (this.Mana.CurLevel >= (.99f * this.Mana.MaxLevel))
                        {
                            this.age++;
                            if (this.age > (lastXPGain + magicXPRate))
                            {
                                MagicData.MagicUserXP++;
                                lastXPGain = this.age;
                            }
                        }
                        bool flag4 = Find.TickManager.TicksGame % 30 == 0;
                        if (flag4)
                        {
                            bool flag5 = this.MagicUserXP > this.MagicUserXPTillNextLevel;
                            if (flag5)
                            {
                                this.LevelUp(false);
                            }
                        }
                        if (Find.TickManager.TicksGame % 60 == 0)
                        {
                            ResolveEnchantments();
                            for (int i = 0; i < this.summonedMinions.Count; i++)
                            {
                                Pawn evaluateMinion = this.summonedMinions[i] as Pawn;
                                if (evaluateMinion == null || evaluateMinion.Dead || !evaluateMinion.Spawned)
                                {
                                    this.summonedMinions.Remove(this.summonedMinions[i]);
                                }
                            }
                            ResolveMinions();
                            if(this.Pawn.story.traits.HasTrait(TorannMagicDefOf.Necromancer))
                            {
                                ResolveUndead();
                            }
                        }
                    }
                }
            }
            if (IsInitialized)
            {
                //custom code
            }
        }

        public void PostInitializeTick()
        {
            bool flag = base.AbilityUser != null;
            if (flag)
            {
                bool spawned = base.AbilityUser.Spawned;
                if (spawned)
                {
                    bool flag2 = base.AbilityUser.story != null;
                    if (flag2)
                    {
                        this.firstTick = true;
                        this.Initialize();
                        this.ResolveMagicTab();
                        this.ResolveMagicPowers();
                        this.ResolveMana();
                    }
                }
            }
        }

        public bool IsMagicUser
        {
            get
            {
                bool flag = base.AbilityUser != null;
                bool result;
                if (flag)
                {
                    bool flag3 = base.AbilityUser.story != null;
                    if (flag3)
                    {
                        bool flag4 = base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.InnerFire) || base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.HeartOfFrost) || base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.StormBorn) || base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Arcanist) || base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Paladin) || base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Summoner) || base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Druid) || base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Necromancer) || base.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Priest);
                        if (flag4)
                        {
                            result = true;
                            return result;
                        }
                    }
                }
                result = false;
                return result;
            }
        }        

        public void DrawMageMark()
        {
            float num = Mathf.Lerp(1.2f, 1.55f, 1f);
            Vector3 vector = this.AbilityUser.Drawer.DrawPos;
            vector.x = vector.x + .45f;
            vector.z = vector.z + .45f;
            vector.y = Altitudes.AltitudeFor(AltitudeLayer.MoteOverhead);
            float angle = 290f;
            Vector3 s = new Vector3(.28f, 1f, .28f);
            Matrix4x4 matrix = default(Matrix4x4);
            matrix.SetTRS(vector, Quaternion.AngleAxis(angle, Vector3.up), s);
            if (this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.InnerFire))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.fireMarkMat, 0);
            }
            else if(this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.HeartOfFrost))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.iceMarkMat, 0);
            }
            else if (this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.StormBorn))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.lightningMarkMat, 0);
            }
            else if (this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Arcanist))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.warlockMarkMat, 0);
            }
            else if (this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Paladin))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.paladinMarkMat, 0);
            }
            else if (this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Summoner))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.summonerMarkMat, 0);
            }
            else if (this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Druid))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.druidMarkMat, 0);
            }
            else if (this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Necromancer))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.necroMarkMat, 0);
            }
            else if (this.AbilityUser.story.traits.HasTrait(TorannMagicDefOf.Priest))
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.priestMarkMat, 0);
            }
            else 
            {
                Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.mageMarkMat, 0);
            }
            
        }

        public void DrawEnchantMark()
        {
            float num = Mathf.Lerp(1.2f, 1.55f, 1f);
            Vector3 vector = this.AbilityUser.Drawer.DrawPos;
            vector.x = vector.x + .45f;
            vector.z = vector.z + .45f;
            vector.y = Altitudes.AltitudeFor(AltitudeLayer.MoteOverhead);
            float angle = 0f;
            Vector3 s = new Vector3(.5f, 1f, .5f);
            Matrix4x4 matrix = default(Matrix4x4);
            matrix.SetTRS(vector, Quaternion.AngleAxis(angle, Vector3.up), s);
            Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.enchantMark, 0);           

        }

        public int MagicUserLevel
        {
            get
            {
                return this.MagicData.MagicUserLevel;
            }
            set
            {
                bool flag = value > this.MagicData.MagicUserLevel;
                if (flag)
                {
                    this.MagicData.MagicAbilityPoints++;
                    bool flag2 = this.MagicData.MagicUserXP < value * 500;
                    if (flag2)
                    {
                        this.MagicData.MagicUserXP = value * 500;
                    }
                }
                this.MagicData.MagicUserLevel = value;
            }
        }

        public int MagicUserXP
        {
            get
            {
                return this.MagicData.MagicUserXP;
            }
            set
            {
                this.MagicData.MagicUserXP = value;
            }
        }

        public float XPLastLevel
        {
            get
            {
                float result = 0f;
                bool flag = this.MagicUserLevel > 0;
                if (flag)
                {
                    result = (float)(this.MagicUserLevel * 500); 
                }
                return result;
            }
        }

        public float XPTillNextLevelPercent
        {
            get
            {
                return ((float)this.MagicData.MagicUserXP - this.XPLastLevel) / ((float)this.MagicUserXPTillNextLevel - this.XPLastLevel);
            }
        }

        public int MagicUserXPTillNextLevel
        {
            get
            {
                return (this.MagicData.MagicUserLevel +1) * 500; //was this.magicUserLevel * 100
            }
        }

        public void LevelUp(bool hideNotification = false)
        {
            this.MagicUserLevel++;
            bool flag = !hideNotification;
            if (flag)
            {
                if (Pawn.IsColonist)
                {
                    Messages.Message(Translator.Translate("TM_MagicLevelUp", new object[]
                    {
                    this.parent.Label
                    }), MessageTypeDefOf.PositiveEvent);
                }
            }
        }

        public void LevelUpPower(MagicPower power)
        {
            foreach (AbilityDef current in power.TMabilityDefs)
            {
                base.RemovePawnAbility(current);
            }

            power.level++;
            base.AddPawnAbility(power.nextLevelAbilityDef, true, -1f);
            this.UpdateAbilities();
        }

        public Need_Mana Mana
        {
            get
            {
                return base.AbilityUser.needs.TryGetNeed<Need_Mana>();    
            }
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
            bool flag = CompAbilityUserMagic.MagicAbilities == null;
            if (flag)
            {
                if (this.magicPowersInitialized == false)
                {
                    Pawn abilityUser = base.AbilityUser;
                    bool flag2;
                    MagicData.MagicUserLevel = 0;
                    MagicData.MagicAbilityPoints = 0;

                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.InnerFire);
                    if (flag2)
                    {
                        Log.Message("Initializing Inner Fire Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if(Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_RayofHope);
                            }
                            else
                            {
                                MagicPower mpIF = this.MagicData.MagicPowersIF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_RayofHope);
                                mpIF.learned = false;
                            }
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Firebolt);
                            }
                            else
                            {
                                MagicPower mpIF = this.MagicData.MagicPowersIF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Firebolt);
                                mpIF.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Fireclaw);
                            }
                            else
                            {
                                MagicPower mpIF = this.MagicData.MagicPowersIF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Fireclaw);
                                mpIF.learned = false;
                            }
                            if (Rand.Chance(.2f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Fireball);
                            }
                            else
                            {
                                MagicPower mpIF = this.MagicData.MagicPowersIF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Fireball);
                                mpIF.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_RayofHope);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Firebolt);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Fireclaw);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Fireball);
                        }                       
                    }
                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.HeartOfFrost);
                    if (flag2)
                    {
                        Log.Message("Initializing Heart of Frost Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Soothe);
                            }
                            else
                            {
                                MagicPower mpHoF = this.MagicData.MagicPowersHoF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Soothe);
                                mpHoF.learned = false;
                            }
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Icebolt);
                            }
                            else
                            {
                                MagicPower mpHoF = this.MagicData.MagicPowersHoF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Icebolt);
                                mpHoF.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Snowball);
                            }
                            else
                            {
                                MagicPower mpHoF = this.MagicData.MagicPowersHoF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Snowball);
                                mpHoF.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_FrostRay);
                            }
                            else
                            {
                                MagicPower mpHoF = this.MagicData.MagicPowersHoF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_FrostRay);
                                mpHoF.learned = false;
                            }
                            if (Rand.Chance(.7f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Rainmaker);
                                this.spell_Rain = true;
                            }
                            else
                            {
                                MagicPower mpHoF = this.MagicData.MagicPowersHoF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Rainmaker);
                                mpHoF.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_Soothe);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Icebolt);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Snowball);
                            this.AddPawnAbility(TorannMagicDefOf.TM_FrostRay);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Rainmaker);
                            this.spell_Rain = true;
                        }                        
                    }
                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.StormBorn);
                    if (flag2)
                    {
                        Log.Message("Initializing Storm Born Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_AMP);
                            }
                            else
                            {
                                MagicPower mpSB = this.MagicData.MagicPowersSB.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_AMP);
                                mpSB.learned = false;
                            }
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_LightningBolt);
                            }
                            else
                            {
                                MagicPower mpSB = this.MagicData.MagicPowersSB.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_LightningBolt);
                                mpSB.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_LightningCloud);
                            }
                            else
                            {
                                MagicPower mpSB = this.MagicData.MagicPowersSB.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_LightningCloud);
                                mpSB.learned = false;
                            }
                            if (Rand.Chance(.2f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_LightningStorm);
                            }
                            else
                            {
                                MagicPower mpSB = this.MagicData.MagicPowersSB.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_LightningStorm);
                                mpSB.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_AMP);
                            this.AddPawnAbility(TorannMagicDefOf.TM_LightningBolt);
                            this.AddPawnAbility(TorannMagicDefOf.TM_LightningCloud);
                            this.AddPawnAbility(TorannMagicDefOf.TM_LightningStorm);
                        }
                    }
                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Arcanist);
                    if (flag2)
                    {
                        Log.Message("Initializing Arcane Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Shadow);
                            }
                            else
                            {
                                MagicPower mpA = this.MagicData.MagicPowersA.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Shadow);
                                mpA.learned = false;
                            }
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_MagicMissile);
                            }
                            else
                            {
                                MagicPower mpA = this.MagicData.MagicPowersA.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_MagicMissile);
                                mpA.learned = false;
                            }
                            if (Rand.Chance(.7f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Blink);
                                this.spell_Blink = true;
                            }
                            else
                            {
                                MagicPower mpA = this.MagicData.MagicPowersA.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Blink);
                                mpA.learned = false;
                            }
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Summon);
                            }
                            else
                            {
                                MagicPower mpA = this.MagicData.MagicPowersA.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Summon);
                                mpA.learned = false;
                            }
                            if (Rand.Chance(.2f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Teleport);
                                this.spell_Teleport = true;
                            }
                            else
                            {
                                MagicPower mpA = this.MagicData.MagicPowersA.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Teleport);
                                mpA.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_Shadow);
                            this.AddPawnAbility(TorannMagicDefOf.TM_MagicMissile);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Blink);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Summon);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Teleport);  //Pending Redesign (graphics?)
                            this.spell_Blink = true;
                            this.spell_Teleport = true;
                        }
                    }
                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Paladin);
                    if (flag2)
                    {
                        Log.Message("Initializing Paladin Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Heal);
                                this.spell_Heal = true;
                            }
                            else
                            {
                                MagicPower mpP = this.MagicData.MagicPowersP.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Heal);
                                mpP.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Shield);
                            }
                            else
                            {
                                MagicPower mpP = this.MagicData.MagicPowersP.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Shield);
                                mpP.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_ValiantCharge);
                            }
                            else
                            {
                                MagicPower mpP = this.MagicData.MagicPowersP.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_ValiantCharge);
                                mpP.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Overwhelm);
                            }
                            else
                            {
                                MagicPower mpP = this.MagicData.MagicPowersP.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Overwhelm);
                                mpP.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_Heal);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Shield);
                            this.AddPawnAbility(TorannMagicDefOf.TM_ValiantCharge);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Overwhelm);
                            this.spell_Heal = true;
                        }
                    }
                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Summoner);
                    if (flag2)
                    {
                        Log.Message("Initializing Summoner Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_SummonMinion);
                                this.spell_SummonMinion = true;
                            }
                            else
                            {
                                MagicPower mpS = this.MagicData.MagicPowersS.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SummonMinion);
                                mpS.learned = false;
                            }
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_SummonPylon);
                            }
                            else
                            {
                                MagicPower mpS = this.MagicData.MagicPowersS.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SummonPylon);
                                mpS.learned = false;
                            }
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_SummonExplosive);
                            }
                            else
                            {
                                MagicPower mpS = this.MagicData.MagicPowersS.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SummonExplosive);
                                mpS.learned = false;
                            }
                            if (Rand.Chance(.2f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_SummonElemental);
                            }
                            else
                            {
                                MagicPower mpS = this.MagicData.MagicPowersS.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SummonElemental);
                                mpS.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_SummonMinion);
                            this.AddPawnAbility(TorannMagicDefOf.TM_SummonPylon);
                            this.AddPawnAbility(TorannMagicDefOf.TM_SummonExplosive);
                            this.AddPawnAbility(TorannMagicDefOf.TM_SummonElemental);
                            this.spell_SummonMinion = true;
                        }
                    }
                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Druid);
                    if (flag2)
                    {
                        Log.Message("Initializing Druid Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Poison);
                            }
                            else
                            {
                                MagicPower mpD = this.MagicData.MagicPowersD.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Poison);
                                mpD.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_SootheAnimal);
                            }
                            else
                            {
                                MagicPower mpD = this.MagicData.MagicPowersD.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SootheAnimal);
                                mpD.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Regenerate);
                            }
                            else
                            {
                                MagicPower mpD = this.MagicData.MagicPowersD.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Regenerate);
                                mpD.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_CureDisease);
                            }
                            else
                            {
                                MagicPower mpD = this.MagicData.MagicPowersD.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_CureDisease);
                                mpD.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_Poison);
                            this.AddPawnAbility(TorannMagicDefOf.TM_SootheAnimal);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Regenerate);
                            this.AddPawnAbility(TorannMagicDefOf.TM_CureDisease);
                        }
                    }
                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Necromancer);
                    if (flag2)
                    {
                        Log.Message("Initializing Necromancer Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_RaiseUndead);
                            }
                            else
                            {
                                MagicPower mpN = this.MagicData.MagicPowersN.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_RaiseUndead);
                                mpN.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_DeathMark);
                            }
                            else
                            {
                                MagicPower mpN = this.MagicData.MagicPowersN.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_DeathMark);
                                mpN.learned = false;
                            }
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_FogOfTorment);
                            }
                            else
                            {
                                MagicPower mpN = this.MagicData.MagicPowersN.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_FogOfTorment);
                                mpN.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_ConsumeCorpse);
                            }
                            else
                            {
                                MagicPower mpN = this.MagicData.MagicPowersN.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_ConsumeCorpse);
                                mpN.learned = false;
                            }
                            if (Rand.Chance(.2f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_CorpseExplosion);
                            }
                            else
                            {
                                MagicPower mpN = this.MagicData.MagicPowersN.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_CorpseExplosion);
                                mpN.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_RaiseUndead);
                            this.AddPawnAbility(TorannMagicDefOf.TM_DeathMark);
                            this.AddPawnAbility(TorannMagicDefOf.TM_FogOfTorment);
                            this.AddPawnAbility(TorannMagicDefOf.TM_ConsumeCorpse);
                            this.AddPawnAbility(TorannMagicDefOf.TM_CorpseExplosion);
                        }
                    }
                    flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Priest);
                    if (flag2)
                    {
                        Log.Message("Initializing Priest Abilities");
                        if (!abilityUser.health.hediffSet.HasHediff(TorannMagicDefOf.TM_Uncertainty, false))
                        {
                            if (Rand.Chance(.5f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_AdvancedHeal);
                            }
                            else
                            {
                                MagicPower mpPR = this.MagicData.MagicPowersPR.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_AdvancedHeal);
                                mpPR.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_Purify);
                            }
                            else
                            {
                                MagicPower mpPR = this.MagicData.MagicPowersPR.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Purify);
                                mpPR.learned = false;
                            }
                            if (Rand.Chance(.3f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_HealingCircle);
                            }
                            else
                            {
                                MagicPower mpPR = this.MagicData.MagicPowersPR.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_HealingCircle);
                                mpPR.learned = false;
                            }
                            if (Rand.Chance(.4f))
                            {
                                this.AddPawnAbility(TorannMagicDefOf.TM_BestowMight);
                            }
                            else
                            {
                                MagicPower mpPR = this.MagicData.MagicPowersPR.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_BestowMight);
                                mpPR.learned = false;
                            }
                        }
                        else
                        {
                            this.AddPawnAbility(TorannMagicDefOf.TM_AdvancedHeal);
                            this.AddPawnAbility(TorannMagicDefOf.TM_Purify);
                            this.AddPawnAbility(TorannMagicDefOf.TM_HealingCircle);
                            this.AddPawnAbility(TorannMagicDefOf.TM_BestowMight);
                        }
                    }                    
                }
                this.magicPowersInitialized = true;
                base.UpdateAbilities();                                
            }
        }

        public void InitializeSpell()
        {
            Pawn abilityUser = base.AbilityUser;
            if(this.IsMagicUser)
            {             
                if (this.spell_Rain == true && !abilityUser.story.traits.HasTrait(TorannMagicDefOf.HeartOfFrost))
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Rainmaker);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Rainmaker);

                }
                if (this.spell_Blink == true && !abilityUser.story.traits.HasTrait(TorannMagicDefOf.Arcanist))
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Blink);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Blink);
                }
                if (this.spell_Teleport == true && !abilityUser.story.traits.HasTrait(TorannMagicDefOf.Arcanist))
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Teleport);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Teleport);
                }
                if (this.spell_Heal == true && !abilityUser.story.traits.HasTrait(TorannMagicDefOf.Paladin))
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Heal);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Heal);
                }
                if (this.spell_Heater == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Heater);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Heater);
                }
                if (this.spell_Cooler == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Cooler);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Cooler);
                }
                if (this.spell_PowerNode == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_PowerNode);
                    this.AddPawnAbility(TorannMagicDefOf.TM_PowerNode);
                }
                if (this.spell_DryGround == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_DryGround);
                    this.AddPawnAbility(TorannMagicDefOf.TM_DryGround);
                }
                if (this.spell_WetGround == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_WetGround);
                    this.AddPawnAbility(TorannMagicDefOf.TM_WetGround);
                }
                if (this.spell_ChargeBattery == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_ChargeBattery);
                    this.AddPawnAbility(TorannMagicDefOf.TM_ChargeBattery);
                }
                if (this.spell_SmokeCloud == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_SmokeCloud);
                    this.AddPawnAbility(TorannMagicDefOf.TM_SmokeCloud);
                }
                if (this.spell_Extinguish == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Extinguish);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Extinguish);
                }
                if (this.spell_EMP == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_EMP);
                    this.AddPawnAbility(TorannMagicDefOf.TM_EMP);
                }
                if (this.spell_Blizzard == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Blizzard);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Blizzard);
                }
                if (this.spell_Firestorm == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Firestorm);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Firestorm);
                }
                if (this.spell_SummonMinion == true && !abilityUser.story.traits.HasTrait(TorannMagicDefOf.Summoner))
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_SummonMinion);
                    this.AddPawnAbility(TorannMagicDefOf.TM_SummonMinion);
                }
                if (this.spell_TransferMana == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_TransferMana);
                    this.AddPawnAbility(TorannMagicDefOf.TM_TransferMana);
                }
                if (this.spell_SiphonMana == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_SiphonMana);
                    this.AddPawnAbility(TorannMagicDefOf.TM_SiphonMana);
                }
                if (this.spell_RegrowLimb == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_RegrowLimb);
                    this.AddPawnAbility(TorannMagicDefOf.TM_RegrowLimb);
                }
                if (this.spell_EyeOfTheStorm == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_EyeOfTheStorm);
                    this.AddPawnAbility(TorannMagicDefOf.TM_EyeOfTheStorm);
                }
                if (this.spell_ManaShield == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_ManaShield);
                    this.AddPawnAbility(TorannMagicDefOf.TM_ManaShield);
                }
                if (this.spell_FoldReality == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_FoldReality);
                    this.AddPawnAbility(TorannMagicDefOf.TM_FoldReality);
                }
                if (this.spell_Resurrection == true)
                {
                    this.RemovePawnAbility(TorannMagicDefOf.TM_Resurrection);
                    this.AddPawnAbility(TorannMagicDefOf.TM_Resurrection);
                }
                //this.UpdateAbilities();
            }            
        }

        public void FixPowers()
        {
            Pawn abilityUser = base.AbilityUser;
            if (this.magicPowersInitialized == true)
            {
                bool flag2;
                flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.InnerFire);
                if (flag2)
                {
                    Log.Message("Fixing Inner Fire Abilities");
                    foreach (MagicPower currentIF in this.MagicData.MagicPowersIF)
                    {
                        if (currentIF.abilityDef.defName == "TM_RayofHope" || currentIF.abilityDef.defName == "TM_RayofHope_I" || currentIF.abilityDef.defName == "TM_RayofHope_II" || currentIF.abilityDef.defName == "TM_RayofHope_III")
                        {
                            if (currentIF.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_III);
                            }
                            else if (currentIF.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_III);
                            }
                            else if (currentIF.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_III);
                            }
                            else if (currentIF.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_RayofHope_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                    }

                }
                flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.HeartOfFrost);
                if (flag2)
                {
                    Log.Message("Fixing Heart of Frost Abilities");
                    foreach (MagicPower currentHoF in this.MagicData.MagicPowersHoF)
                    {
                        if (currentHoF.abilityDef.defName == "TM_Soothe" || currentHoF.abilityDef.defName == "TM_Soothe_I" || currentHoF.abilityDef.defName == "TM_Soothe_II" || currentHoF.abilityDef.defName == "TM_Soothe_III")
                        {
                            if (currentHoF.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_III);
                            }
                            else if( currentHoF.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_III);
                            }
                            else if (currentHoF.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_III);
                            }
                            else if (currentHoF.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Soothe_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                        if (currentHoF.abilityDef.defName == "TM_FrostRay" || currentHoF.abilityDef.defName == "TM_FrostRay_I" || currentHoF.abilityDef.defName == "TM_FrostRay_II" || currentHoF.abilityDef.defName == "TM_FrostRay_III")
                        {
                            if (currentHoF.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_III);
                            }
                            else if (currentHoF.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_III);
                            }
                            else if (currentHoF.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_III);
                            }
                            else if (currentHoF.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_FrostRay_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                    }
                }
                flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.StormBorn);
                if (flag2)
                {
                    Log.Message("Fixing Storm Born Abilities");
                    foreach (MagicPower currentSB in this.MagicData.MagicPowersSB)
                    {
                        if (currentSB.abilityDef.defName == "TM_AMP" || currentSB.abilityDef.defName == "TM_AMP_I" || currentSB.abilityDef.defName == "TM_AMP_II" || currentSB.abilityDef.defName == "TM_AMP_III")
                        {
                            if (currentSB.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_III);
                            }
                            else if (currentSB.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_III);
                            }
                            else if (currentSB.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_III);
                            }
                            else if (currentSB.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_AMP_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                    }
                }
                flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Arcanist);
                if (flag2)
                {
                    Log.Message("Fixing Arcane Abilities");
                    foreach (MagicPower currentA in this.MagicData.MagicPowersA)
                    {
                        if (currentA.abilityDef.defName == "TM_Shadow" || currentA.abilityDef.defName == "TM_Shadow_I" || currentA.abilityDef.defName == "TM_Shadow_II" || currentA.abilityDef.defName == "TM_Shadow_III")
                        {
                            if (currentA.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_III);
                            }
                            else if (currentA.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_III);
                            }
                            else if (currentA.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_III);
                            }
                            else if (currentA.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shadow_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                        if (currentA.abilityDef.defName == "TM_MagicMissile" || currentA.abilityDef.defName == "TM_MagicMissile_I" || currentA.abilityDef.defName == "TM_MagicMissile_II" || currentA.abilityDef.defName == "TM_MagicMissile_III")
                        {
                            if (currentA.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_III);
                            }
                            else if (currentA.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_III);
                            }
                            else if (currentA.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_III);
                            }
                            else if (currentA.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_MagicMissile_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                        if (currentA.abilityDef.defName == "TM_Blink" || currentA.abilityDef.defName == "TM_Blink_I" || currentA.abilityDef.defName == "TM_Blink_II" || currentA.abilityDef.defName == "TM_Blink_III")
                        {
                            if (currentA.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_III);
                            }
                            else if (currentA.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_III);
                            }
                            else if (currentA.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_III);
                            }
                            else if (currentA.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Blink_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                        if (currentA.abilityDef.defName == "TM_Summon" || currentA.abilityDef.defName == "TM_Summon_I" || currentA.abilityDef.defName == "TM_Summon_II" || currentA.abilityDef.defName == "TM_Summon_III")
                        {
                            if (currentA.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_III);
                            }
                            else if (currentA.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_III);
                            }
                            else if (currentA.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_III);
                            }
                            else if (currentA.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Summon_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                    }

                }
                flag2 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Paladin);
                if (flag2)
                {
                    Log.Message("Fixing Paladin Abilities");
                    foreach (MagicPower currentA in this.MagicData.MagicPowersA)
                    {
                        if (currentA.abilityDef.defName == "TM_Shield" || currentA.abilityDef.defName == "TM_Shield_I" || currentA.abilityDef.defName == "TM_Shield_II" || currentA.abilityDef.defName == "TM_Shield_III")
                        {
                            if (currentA.level == 0)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_III);
                            }
                            else if (currentA.level == 1)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_III);
                            }
                            else if (currentA.level == 2)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_I);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_III);
                            }
                            else if (currentA.level == 3)
                            {
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_II);
                                this.RemovePawnAbility(TorannMagicDefOf.TM_Shield_I);
                            }
                            else
                            {
                                Log.Message("Ability level not found to fix");
                            }
                        }
                    }
                }
            }
            //this.UpdateAbilities();
            //base.UpdateAbilities();
        }

        public override bool TryTransformPawn()
        {
            return this.IsMagicUser;
        }        

        public bool TryAddPawnAbility(TMAbilityDef ability)
        {
            //add check to verify no ability is already added
            bool result = false;
            base.AddPawnAbility(ability, true, -1f);
            result = true;
            return result;
        }

        private void ClearPower(MagicPower current)
        {
            Log.Message("Removing ability: " + current.abilityDef.defName.ToString());
            base.RemovePawnAbility(current.abilityDef);
            base.UpdateAbilities();
        }

        public void ClearPowers()
        {
            int tmpLvl = this.MagicUserLevel;
            int tmpExp = this.MagicUserXP;
            base.IsInitialized = false;
            this.magicData = null;
            this.CompTick();
            this.MagicUserLevel = tmpLvl;
            this.MagicUserXP = tmpExp;
            this.magicData.MagicAbilityPoints = tmpLvl;
        }

        private void LoadPowers()
        {
            foreach (MagicPower currentA in this.MagicData.MagicPowersA)
            {
                //Log.Message("Removing ability: " + currentA.abilityDef.defName.ToString());
                currentA.level = 0;
                base.RemovePawnAbility(currentA.abilityDef);
            }
            foreach (MagicPower currentHoF in this.MagicData.MagicPowersHoF)
            {
                //Log.Message("Removing ability: " + currentHoF.abilityDef.defName.ToString());
                currentHoF.level = 0;
                base.RemovePawnAbility(currentHoF.abilityDef);
            }
            foreach (MagicPower currentSB in this.MagicData.MagicPowersSB)
            {
                //Log.Message("Removing ability: " + currentSB.abilityDef.defName.ToString());
                currentSB.level = 0;
                base.RemovePawnAbility(currentSB.abilityDef);
            }
            foreach (MagicPower currentIF in this.MagicData.MagicPowersIF)
            {
                //Log.Message("Removing ability: " + currentIF.abilityDef.defName.ToString());
                currentIF.level = 0;
                base.RemovePawnAbility(currentIF.abilityDef);
            }
            foreach (MagicPower currentP in this.MagicData.MagicPowersP)
            {
                //Log.Message("Removing ability: " + currentP.abilityDef.defName.ToString());
                currentP.level = 0;
                base.RemovePawnAbility(currentP.abilityDef);
            }
            foreach (MagicPower currentS in this.MagicData.MagicPowersS)
            {
                //Log.Message("Removing ability: " + currentP.abilityDef.defName.ToString());
                currentS.level = 0;
                base.RemovePawnAbility(currentS.abilityDef);
            }
            foreach (MagicPower currentD in this.MagicData.MagicPowersD)
            {
                //Log.Message("Removing ability: " + currentP.abilityDef.defName.ToString());
                currentD.level = 0;
                base.RemovePawnAbility(currentD.abilityDef);
            }
            foreach (MagicPower currentN in this.MagicData.MagicPowersN)
            {
                //Log.Message("Removing ability: " + currentP.abilityDef.defName.ToString());
                currentN.level = 0;
                base.RemovePawnAbility(currentN.abilityDef);
            }
        }

        public void ClearTraits()
        {
            List<Trait> traits = this.AbilityUser.story.traits.allTraits;
            for (int i = 0; i < traits.Count; i++)
            {
                if (traits[i].Label == "Inner Fire")
                {
                    Log.Message("Removing trait " + traits[i].Label);
                    traits.Remove(traits[i]);
                    i--;
                }
                if (traits[i].Label == "Heart of Frost")
                {
                    Log.Message("Removing trait " + traits[i].Label);
                    traits.Remove(traits[i]);
                    i--;
                }
                if (traits[i].Label == "Storm Born")
                {
                    Log.Message("Removing trait " + traits[i].Label);
                    traits.Remove(traits[i]);
                    i--;
                }
                if (traits[i].Label == "Arcanist")
                {
                    Log.Message("Removing trait " + traits[i].Label);
                    traits.Remove(traits[i]);
                    i--;
                }
                if (traits[i].Label == "Paladin")
                {
                    Log.Message("Removing trait " + traits[i].Label);
                    traits.Remove(traits[i]);
                    i--;
                }
                if (traits[i].Label == "Summoner")
                {
                    Log.Message("Removing trait " + traits[i].Label);
                    traits.Remove(traits[i]);
                    i--;
                }
                if (traits[i].Label == "Druid")
                {
                    Log.Message("Removing trait " + traits[i].Label);
                    traits.Remove(traits[i]);
                    i--;
                }
                if (traits[i].Label == "Necromancer")
                {
                    Log.Message("Removing trait " + traits[i].Label);
                    traits.Remove(traits[i]);
                    i--;
                }
            }
        }

        public int MagicAttributeEffeciencyLevel(string attributeName)
        {
            int result = 0;

            if (attributeName == "TM_RayofHope_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_RayofHope.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Firebolt_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Firebolt.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Fireclaw_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Fireclaw.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Fireball_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Fireball.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Firestorm_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Firestorm.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }

            if (attributeName == "TM_Soothe_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Soothe.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Icebolt_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Icebolt.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_FrostRay_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FrostRay.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Snowball_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Snowball.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Rainmaker_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Rainmaker.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Blizzard_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Blizzard.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }

            if (attributeName == "TM_AMP_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_AMP.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_LightningBolt_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningBolt.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_LightningCloud_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningCloud.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_LightningStorm_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningStorm.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }

            if (attributeName == "TM_Shadow_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Shadow.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_MagicMissile_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_MagicMissile.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Blink_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Blink.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Summon_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Summon.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Teleport_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Teleport.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_FoldReality_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FoldReality.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Heal_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Heal.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Shield_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Shield.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_ValiantCharge_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_ValiantCharge.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Overwhelm_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Overwhelm.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_SummonMinion_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonMinion.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_SummonPylon_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonPylon.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_SummonExplosive_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonExplosive.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_SummonElemental_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonElemental.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Poison_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Poison.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_SootheAnimal_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SootheAnimal.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Regenerate_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Regenerate.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_CureDisease_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_CureDisease.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_RegrowLimb_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_RegrowLimb.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_EyeOfTheStorm_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_EyeOfTheStorm.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_RaiseUndead_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_RaiseUndead.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_DeathMark_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_DeathMark.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_FogOfTorment_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FogOfTorment.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_ConsumeCorpse_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_ConsumeCorpse.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_CorpseExplosion_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_CorpseExplosion.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_AdvancedHeal_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_AdvancedHeal.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Purify_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Purify.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_HealingCircle_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_HealingCircle.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_BestowMight_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_BestowMight.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            if (attributeName == "TM_Resurrection_eff")
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Resurrection.FirstOrDefault((MagicPowerSkill x) => x.label == attributeName);
                bool flag = magicPowerSkill != null;
                if (flag)
                {
                    result = magicPowerSkill.level;
                }
            }
            return result;
        }

        public float ActualManaCost(TMAbilityDef magicDef)
        {
            float adjustedManaCost = magicDef.manaCost;
            if (magicDef == TorannMagicDefOf.TM_RayofHope || magicDef == TorannMagicDefOf.TM_RayofHope_I || magicDef == TorannMagicDefOf.TM_RayofHope_II || magicDef == TorannMagicDefOf.TM_RayofHope_III)
            {
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.IF_RayofHope_eff * (float)this.MagicAttributeEffeciencyLevel("TM_RayofHope_eff"));
            }
            if (magicDef == TorannMagicDefOf.TM_Firebolt)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Firebolt.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Firebolt_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.IF_Firebolt_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Fireclaw)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Fireclaw.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Fireclaw_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.IF_Fireclaw_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Fireball)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Fireball.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Fireball_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.IF_Fireball_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Firestorm)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Firestorm.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Firestorm_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.IF_Firestorm_eff * (float)magicPowerSkill.level);
            }

            if (magicDef == TorannMagicDefOf.TM_Soothe || magicDef == TorannMagicDefOf.TM_Soothe_I || magicDef == TorannMagicDefOf.TM_Soothe_II || magicDef == TorannMagicDefOf.TM_Soothe_III)
            {
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.HoF_Soothe_eff * (float)this.MagicAttributeEffeciencyLevel("TM_Soothe_eff"));
            }
            if (magicDef == TorannMagicDefOf.TM_Icebolt)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Icebolt.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Icebolt_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.HoF_Icebolt_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_FrostRay || magicDef == TorannMagicDefOf.TM_FrostRay_I || magicDef == TorannMagicDefOf.TM_FrostRay_II || magicDef == TorannMagicDefOf.TM_FrostRay_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FrostRay.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_FrostRay_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.HoF_FrostRay_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Snowball)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Snowball.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Snowball_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.HoF_Snowball_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Rainmaker)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Rainmaker.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Rainmaker_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.HoF_Rainmaker_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Blizzard)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Blizzard.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Blizzard_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.HoF_Blizzard_eff * (float)magicPowerSkill.level);
            }

            if (magicDef == TorannMagicDefOf.TM_AMP || magicDef == TorannMagicDefOf.TM_AMP_I || magicDef == TorannMagicDefOf.TM_AMP_II || magicDef == TorannMagicDefOf.TM_AMP_III)
            {
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.SB_AMP_eff * (float)this.MagicAttributeEffeciencyLevel("TM_AMP_eff"));
            }
            if (magicDef == TorannMagicDefOf.TM_LightningBolt)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningBolt.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_LightningBolt_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.SB_LightningBolt_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_LightningCloud)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningCloud.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_LightningCloud_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.SB_LightningCloud_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_LightningStorm)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_LightningStorm.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_LightningStorm_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.SB_LightningStorm_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_EyeOfTheStorm)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_EyeOfTheStorm.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_EyeOfTheStorm_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.SB_EyeOfTheStorm_eff * (float)magicPowerSkill.level);
            }

            if (magicDef == TorannMagicDefOf.TM_Shadow || magicDef == TorannMagicDefOf.TM_Shadow_I || magicDef == TorannMagicDefOf.TM_Shadow_II || magicDef == TorannMagicDefOf.TM_Shadow_III)
            {
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.A_Shadow_eff * (float)this.MagicAttributeEffeciencyLevel("TM_Shadow_eff"));
            }
            if (magicDef == TorannMagicDefOf.TM_MagicMissile || magicDef == TorannMagicDefOf.TM_MagicMissile_I || magicDef == TorannMagicDefOf.TM_MagicMissile_II || magicDef == TorannMagicDefOf.TM_MagicMissile_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_MagicMissile.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_MagicMissile_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.A_MagicMissile_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Blink || magicDef == TorannMagicDefOf.TM_Blink_I || magicDef == TorannMagicDefOf.TM_Blink_II || magicDef == TorannMagicDefOf.TM_Blink_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Blink.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Blink_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.A_Blink_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Summon || magicDef == TorannMagicDefOf.TM_Summon_I || magicDef == TorannMagicDefOf.TM_Summon_II || magicDef == TorannMagicDefOf.TM_Summon_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Summon.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Summon_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.A_Summon_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Teleport)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Teleport.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Teleport_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.A_Teleport_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_FoldReality)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FoldReality.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_FoldReality_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.A_FoldReality_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Heal)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Heal.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Heal_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.P_Heal_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Shield || magicDef == TorannMagicDefOf.TM_Shield_I || magicDef == TorannMagicDefOf.TM_Shield_II || magicDef == TorannMagicDefOf.TM_Shield_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Shield.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Shield_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.P_Shield_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_ValiantCharge)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_ValiantCharge.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_ValiantCharge_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.P_ValiantCharge_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Overwhelm)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Overwhelm.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Overwhelm_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.P_Overwhelm_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_SummonMinion)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonMinion.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_SummonMinion_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.S_SummonMinion_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_SummonPylon )
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonPylon.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_SummonPylon_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.S_SummonPylon_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_SummonExplosive)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonExplosive.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_SummonExplosive_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.S_SummonExplosive_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_SummonElemental)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SummonElemental.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_SummonElemental_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.S_SummonElemental_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Poison)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Poison.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Poison_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.D_Poison_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_SootheAnimal || magicDef == TorannMagicDefOf.TM_SootheAnimal_I || magicDef == TorannMagicDefOf.TM_SootheAnimal_II || magicDef == TorannMagicDefOf.TM_SootheAnimal_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_SootheAnimal.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_SootheAnimal_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.D_SootheAnimal_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Regenerate)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Regenerate.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Regenerate_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.D_Regenerate_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_CureDisease)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_CureDisease.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_CureDisease_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.D_CureDisease_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_RegrowLimb)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_RegrowLimb.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_RegrowLimb_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.D_RegrowLimb_eff * (float)magicPowerSkill.level);
            }            
            if (magicDef == TorannMagicDefOf.TM_RaiseUndead)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_RaiseUndead.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_RaiseUndead_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.N_RaiseUndead_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_DeathMark || magicDef == TorannMagicDefOf.TM_DeathMark_I || magicDef == TorannMagicDefOf.TM_DeathMark_II || magicDef == TorannMagicDefOf.TM_DeathMark_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_DeathMark.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_DeathMark_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.N_DeathMark_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_FogOfTorment)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_FogOfTorment.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_FogOfTorment_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.N_FogOfTorment_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_ConsumeCorpse || magicDef == TorannMagicDefOf.TM_ConsumeCorpse_I || magicDef == TorannMagicDefOf.TM_ConsumeCorpse_II || magicDef == TorannMagicDefOf.TM_ConsumeCorpse_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_ConsumeCorpse.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_ConsumeCorpse_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.N_ConsumeCorpse_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_CorpseExplosion || magicDef == TorannMagicDefOf.TM_CorpseExplosion_I || magicDef == TorannMagicDefOf.TM_CorpseExplosion_II || magicDef == TorannMagicDefOf.TM_CorpseExplosion_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_CorpseExplosion.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_CorpseExplosion_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.N_CorpseExplosion_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_AdvancedHeal)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_AdvancedHeal.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_AdvancedHeal_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.PR_AdvancedHeal_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Purify)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Purify.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Purify_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.PR_Purify_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_HealingCircle || magicDef == TorannMagicDefOf.TM_HealingCircle_I || magicDef == TorannMagicDefOf.TM_HealingCircle_II || magicDef == TorannMagicDefOf.TM_HealingCircle_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_HealingCircle.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_HealingCircle_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.PR_HealingCircle_eff * (float)magicPowerSkill.level);
            }            
            if (magicDef == TorannMagicDefOf.TM_BestowMight || magicDef == TorannMagicDefOf.TM_BestowMight_I || magicDef == TorannMagicDefOf.TM_BestowMight_II || magicDef == TorannMagicDefOf.TM_BestowMight_III)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_BestowMight.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_BestowMight_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.PR_BestowMight_eff * (float)magicPowerSkill.level);
            }
            if (magicDef == TorannMagicDefOf.TM_Resurrection)
            {
                MagicPowerSkill magicPowerSkill = this.MagicData.MagicPowerSkill_Resurrection.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_Resurrection_eff");
                adjustedManaCost = magicDef.manaCost - magicDef.manaCost * (this.PR_Resurrection_eff * (float)magicPowerSkill.level);
            }
            if (this.mpCost != 1f)
            {
                adjustedManaCost = adjustedManaCost * this.mpCost;
            }
            MagicPowerSkill globalSkill = this.MagicData.MagicPowerSkill_global_eff.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_global_eff_pwr");
            if (globalSkill != null)
            {
                return (adjustedManaCost - (adjustedManaCost * (global_eff * globalSkill.level)));
            }
            else
            {
                return adjustedManaCost;
            }

        }

        public override List<HediffDef> IgnoredHediffs()
        {
            return new List<HediffDef>
            {
                TorannMagicDefOf.TM_MightUserHD
            };
        }

        public override void PostPreApplyDamage(DamageInfo dinfo, out bool absorbed)
        {
            Pawn abilityUser = base.AbilityUser;

            List<Hediff> list = new List<Hediff>();
            List<Hediff> arg_32_0 = list;
            IEnumerable<Hediff> arg_32_1;
            if (abilityUser == null)
            {
                arg_32_1 = null;
            }
            else
            {
                Pawn_HealthTracker expr_1A = abilityUser.health;
                if (expr_1A == null)
                {
                    arg_32_1 = null;
                }
                else
                {
                    HediffSet expr_26 = expr_1A.hediffSet;
                    arg_32_1 = ((expr_26 != null) ? expr_26.hediffs : null);
                }
            }
            arg_32_0.AddRange(arg_32_1);
            Pawn expr_3E = abilityUser;
            int? arg_84_0;
            if (expr_3E == null)
            {
                arg_84_0 = null;
            }
            else
            {
                Pawn_HealthTracker expr_52 = expr_3E.health;
                if (expr_52 == null)
                {
                    arg_84_0 = null;
                }
                else
                {
                    HediffSet expr_66 = expr_52.hediffSet;
                    arg_84_0 = ((expr_66 != null) ? new int?(expr_66.hediffs.Count<Hediff>()) : null);
                }
            }
            bool flag = (arg_84_0 ?? 0) > 0;
            if (flag)
            {
                foreach (Hediff current in list)
                {
                    if (current.def.defName == "TM_HediffInvulnerable") 
                    {
                        absorbed = true;
                        MoteMaker.MakeStaticMote(AbilityUser.Position, AbilityUser.Map, ThingDefOf.Mote_ExplosionFlash, 10);
                        dinfo.SetAmount(0);
                        return;
                    }
                    if (current.def.defName == "TM_HediffShield")
                    {
                        float sev = current.Severity;
                        absorbed = true;
                        int actualDmg = 0;
                        float dmgAmt = (float)dinfo.Amount;
                        float dmgToSev = 0.0075f;
                        ModOptions.SettingsRef settingsRef = new ModOptions.SettingsRef();
                        if (!abilityUser.IsColonistPlayerControlled)
                        {
                            if (settingsRef.AIHardMode)
                            {
                                dmgToSev = 0.0010f;
                            }
                            else
                            {
                                dmgToSev = 0.0020f;
                            }
                        }
                        sev = sev - (dmgAmt * dmgToSev);
                        if (sev < 0)
                        {
                            actualDmg = (int)Mathf.RoundToInt(Mathf.Abs(sev / dmgToSev));
                            BreakShield(abilityUser);
                        }
                        DisplayShield(abilityUser, dinfo, sev);
                        current.Severity = sev;
                        dinfo.SetAmount(actualDmg);
                
                        return;
                    }
                    if (current.def.defName == "TM_ManaShieldHD")
                    {
                        float sev = this.Mana.CurLevel;
                        absorbed = true;
                        int actualDmg = 0;
                        float dmgAmt = (float)dinfo.Amount;
                        float dmgToSev = 0.01f;
                        sev = sev - (dmgAmt * dmgToSev);
                        this.Mana.CurLevel = sev;
                        if (sev < 0)
                        {
                            actualDmg = (int)Mathf.RoundToInt(Mathf.Abs(sev / dmgToSev));
                            BreakShield(abilityUser);
                            current.Severity = sev;
                            abilityUser.health.RemoveHediff(current);
                        }
                        DisplayShield(abilityUser, dinfo, sev);
                        dinfo.SetAmount(actualDmg);
                        return;
                    }

                }
                
                list.Clear();
                list = null;
            }
            base.PostPreApplyDamage(dinfo, out absorbed);
        }

        private void BreakShield(Pawn pawn)
        {
            SoundDefOf.EnergyShieldBroken.PlayOneShot(new TargetInfo(pawn.Position, pawn.Map, false));
            MoteMaker.MakeStaticMote(pawn.TrueCenter(), pawn.Map, ThingDefOf.Mote_ExplosionFlash, 12f);
            for (int i = 0; i < 6; i++)
            {
                Vector3 loc = pawn.TrueCenter() + Vector3Utility.HorizontalVectorFromAngle((float)Rand.Range(0, 360)) * Rand.Range(0.3f, 0.6f);
                MoteMaker.ThrowDustPuff(loc, pawn.Map, Rand.Range(0.8f, 1.2f));
            }
        }

        private void DisplayShield(Pawn shieldedPawn, DamageInfo dinfo, float sev)
        {
            Vector3 impactAngleVect;
            SoundDefOf.EnergyShieldAbsorbDamage.PlayOneShot(new TargetInfo(shieldedPawn.Position, shieldedPawn.Map, false));
            impactAngleVect = Vector3Utility.HorizontalVectorFromAngle(dinfo.Angle);
            Vector3 loc = shieldedPawn.TrueCenter() + impactAngleVect.RotatedBy(180f) * 0.5f;
            float num = Mathf.Min(10f, 2f + (float)dinfo.Amount / 10f);
            MoteMaker.MakeStaticMote(loc, shieldedPawn.Map, ThingDefOf.Mote_ExplosionFlash, num);
            int num2 = (int)num;
            for (int i = 0; i < num2; i++)
            {
                MoteMaker.ThrowDustPuff(loc, shieldedPawn.Map, Rand.Range(0.8f, 1.2f));
                this.DrawShieldHit(shieldedPawn, dinfo.Amount, impactAngleVect);
            }
        }

        private void DrawShieldHit(Pawn shieldedPawn, int magnitude, Vector3 impactAngleVect)
        {
            bool flag = !shieldedPawn.Dead && !shieldedPawn.Downed;
            if (flag)
            {
                float num = Mathf.Lerp(1.2f, 1.55f, magnitude);
                Vector3 vector = shieldedPawn.Drawer.DrawPos;
                vector.y = Altitudes.AltitudeFor(AltitudeLayer.MoteOverhead);

                float angle = (float)Rand.Range(0, 360);
                Vector3 s = new Vector3(1.7f, 1f, 1.7f);
                Matrix4x4 matrix = default(Matrix4x4);
                matrix.SetTRS(vector, Quaternion.AngleAxis(angle, Vector3.up), s);
                if(shieldedPawn.health.hediffSet.HasHediff(TorannMagicDefOf.TM_HediffShield))
                {
                    Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.shieldMat, 0);
                }
                else
                {
                    Graphics.DrawMesh(MeshPool.plane10, matrix, CompAbilityUserMagic.manaShieldMat, 0);
                }              
            }
        }

        public void ResolveUndead()
        {
            int undeadCount = 0;
            foreach (Pawn current in this.Pawn.Map.mapPawns.PawnsInFaction(this.Pawn.Faction))
            {
                if (current.health.hediffSet.HasHediff(TorannMagicDefOf.TM_UndeadHD) || current.health.hediffSet.HasHediff(TorannMagicDefOf.TM_UndeadAnimalHD))
                {
                    undeadCount++;
                }
            }
            if(undeadCount > 0 && this.dismissUndeadSpell == false)
            {
                this.AddPawnAbility(TorannMagicDefOf.TM_DismissUndead);
                this.dismissUndeadSpell = true;
            }
            if(undeadCount <= 0 && this.dismissUndeadSpell == true)
            {
                this.RemovePawnAbility(TorannMagicDefOf.TM_DismissUndead);
                this.dismissUndeadSpell = false;
            }
            
        }

        public void ResolveMinions()
        {
            if(this.summonedMinions.Count > 0 && dismissMinionSpell == false)
            {
                this.AddPawnAbility(TorannMagicDefOf.TM_DismissMinion);
                dismissMinionSpell = true;
            }

            if(this.summonedMinions.Count <= 0 && dismissMinionSpell == true)
            {
                this.RemovePawnAbility(TorannMagicDefOf.TM_DismissMinion);
                dismissMinionSpell = false;                    
            }
        }

        public void ResolveMana()
        {
            bool flag = this.Mana == null;
            if (flag)
            {
                Hediff firstHediffOfDef = base.AbilityUser.health.hediffSet.GetFirstHediffOfDef(TorannMagicDefOf.TM_MagicUserHD, false);
                bool flag2 = firstHediffOfDef != null;
                if (flag2)
                {
                    firstHediffOfDef.Severity = 1f;
                }
                else
                {
                    Hediff hediff = HediffMaker.MakeHediff(TorannMagicDefOf.TM_MagicUserHD, base.AbilityUser, null);
                    hediff.Severity = 1f;
                    base.AbilityUser.health.AddHediff(hediff, null, null);
                }
            }
        }
        public void ResolveMagicPowers()
        {
            bool flag = this.magicPowersInitialized;
            if (!flag)
            {
                this.magicPowersInitialized = true;
            }
        }
        public void ResolveMagicTab()
        {
            InspectTabBase inspectTabsx = base.AbilityUser.GetInspectTabs().FirstOrDefault((InspectTabBase x) => x.labelKey == "TM_TabMagic");
            IEnumerable<InspectTabBase> inspectTabs = base.AbilityUser.GetInspectTabs();
            bool flag = inspectTabs != null && inspectTabs.Count<InspectTabBase>() > 0;
            if (flag)
            {
                if (inspectTabsx == null)
                {
                    try
                    {
                        base.AbilityUser.def.inspectorTabsResolved.Add(InspectTabManager.GetSharedInstance(typeof(ITab_Pawn_Magic)));
                    }
                    catch (Exception ex)
                    {
                        Log.Error(string.Concat(new object[]
                        {
                            "Could not instantiate inspector tab of type ",
                            typeof(ITab_Pawn_Magic),
                            ": ",
                            ex
                        }));
                    }
                }
            }
        }

        public void ResolveEnchantments()
        {
            float _maxMP = 0;
            float _mpRegenRate = 0;
            float _coolDown = 0;
            float _xpGain = 0;
            float _mpCost = 0;
            List<Apparel> apparel = this.Pawn.apparel.WornApparel;
            for (int i = 0; i < this.Pawn.apparel.WornApparelCount; i++)
            {
                Enchantment.CompEnchantedItem item = apparel[i].GetComp<Enchantment.CompEnchantedItem>();
                if (item != null)
                {
                    if (item.Props.HasEnchantment)
                    {
                        _maxMP += item.Props.maxMP;
                        _mpRegenRate += item.Props.mpRegenRate;
                        _coolDown += item.Props.coolDown;
                        _xpGain += item.Props.xpGain;
                        _mpCost += item.Props.mpCost;
                    }
                }
            }
            if (this.Pawn.equipment.Primary != null)
            {
                Enchantment.CompEnchantedItem item = this.Pawn.equipment.Primary.GetComp<Enchantment.CompEnchantedItem>();
                if (item != null)
                {
                    if (item.Props.HasEnchantment)
                    {
                        _maxMP += item.Props.maxMP;
                        _mpRegenRate += item.Props.mpRegenRate;
                        _coolDown += item.Props.coolDown;
                        _xpGain += item.Props.xpGain;
                        _mpCost += item.Props.mpCost;
                    }
                }
            }
            MagicPowerSkill spirit= this.MagicData.MagicPowerSkill_global_spirit.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_global_spirit_pwr");
            this.maxMP = 1f + (spirit.level * .02f) + _maxMP;
            this.mpRegenRate = 1f + _mpRegenRate;
            this.coolDown = 1f + _coolDown;
            this.xpGain = 1f + _xpGain;
            this.mpCost = 1f + _mpCost;
            if (_maxMP != 0)
            {
                HealthUtility.AdjustSeverity(this.Pawn, HediffDef.Named("TM_HediffEnchantment_maxMP"), .5f);
            }
            if (_mpRegenRate != 0)
            {
                HealthUtility.AdjustSeverity(this.Pawn, HediffDef.Named("TM_HediffEnchantment_mpRegenRate"), .5f);
            }
            if (_coolDown != 0)
            {
                HealthUtility.AdjustSeverity(this.Pawn, HediffDef.Named("TM_HediffEnchantment_coolDown"), .5f);
            }
            if (_xpGain != 0)
            {
                HealthUtility.AdjustSeverity(this.Pawn, HediffDef.Named("TM_HediffEnchantment_xpGain"), .5f);
            }
            if (_mpCost != 0)
            {
                HealthUtility.AdjustSeverity(this.Pawn, HediffDef.Named("TM_HediffEnchantment_mpCost"), .5f);
            }

            using (IEnumerator<Hediff> enumerator = this.Pawn.health.hediffSet.GetHediffs<Hediff>().GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Hediff rec = enumerator.Current;
                    if (rec.def.defName == "TM_HediffEnchantment_maxMP" && this.maxMP == 1)
                    {
                        Pawn.health.RemoveHediff(rec);
                    }
                    if (rec.def.defName == "TM_HediffEnchantment_coolDown" && this.coolDown == 1)
                    {
                        Pawn.health.RemoveHediff(rec);
                    }
                    if (rec.def.defName == "TM_HediffEnchantment_mpCost" && this.mpCost == 1)
                    {
                        Pawn.health.RemoveHediff(rec);
                    }
                    if (rec.def.defName == "TM_HediffEnchantment_mpRegenRate" && this.mpRegenRate == 1)
                    {
                        Pawn.health.RemoveHediff(rec);
                    }
                    if (rec.def.defName == "TM_HediffEnchantment_xpGain" && this.xpGain == 1)
                    {
                        Pawn.health.RemoveHediff(rec);
                    }
                }
            }
        }

        public override void PostExposeData()
        {
            //base.PostExposeData();            
            Scribe_Values.Look<bool>(ref this.magicPowersInitialized, "magicPowersInitialized", false, false);            
            Scribe_Values.Look<bool>(ref this.spell_Rain, "spell_Rain", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Blink, "spell_Blink", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Teleport, "spell_Teleport", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Heal, "spell_Heal", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Heater, "spell_Heater", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Cooler, "spell_Cooler", false, false);
            Scribe_Values.Look<bool>(ref this.spell_PowerNode, "spell_PowerNode", false, false);
            Scribe_Values.Look<bool>(ref this.spell_DryGround, "spell_DryGround", false, false);
            Scribe_Values.Look<bool>(ref this.spell_WetGround, "spell_WetGround", false, false);
            Scribe_Values.Look<bool>(ref this.spell_ChargeBattery, "spell_ChargeBattery", false, false);
            Scribe_Values.Look<bool>(ref this.spell_SmokeCloud, "spell_SmokeCloud", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Extinguish, "spell_Extinguish", false, false);
            Scribe_Values.Look<bool>(ref this.spell_EMP, "spell_EMP", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Blizzard, "spell_Blizzard", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Firestorm, "spell_Firestorm", false, false);
            Scribe_Values.Look<bool>(ref this.spell_EyeOfTheStorm, "spell_EyeOfTheStorm", false, false);
            Scribe_Values.Look<bool>(ref this.spell_SummonMinion, "spell_SummonMinion", false, false);
            Scribe_Values.Look<bool>(ref this.spell_TransferMana, "spell_TransferMana", false, false);
            Scribe_Values.Look<bool>(ref this.spell_SiphonMana, "spell_SiphonMana", false, false);
            Scribe_Values.Look<bool>(ref this.spell_RegrowLimb, "spell_RegrowLimb", false, false);
            Scribe_Values.Look<bool>(ref this.spell_ManaShield, "spell_ManaShield", false, false);
            Scribe_Values.Look<bool>(ref this.spell_FoldReality, "spell_FoldReality", false, false);
            Scribe_Values.Look<bool>(ref this.spell_Resurrection, "spell_Resurrection", false, false);
            Scribe_Values.Look<bool>(ref this.doOnce, "doOnce", true, false);
            Scribe_Collections.Look<Thing>(ref this.summonedMinions, "summonedMinions", LookMode.Reference);
            Scribe_Deep.Look<MagicData>(ref this.magicData, "magicData", new object[]
            {
                this
            });
            bool flag11 = Scribe.mode == LoadSaveMode.PostLoadInit;
            if (flag11)
            {
                Pawn abilityUser = base.AbilityUser;
                
                bool flag40 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.InnerFire);
                if (flag40)
                {
                    bool flag14 = !this.MagicData.MagicPowersIF.NullOrEmpty<MagicPower>();
                    if (flag14)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current3 in this.MagicData.MagicPowersIF)
                        {
                            bool flag15 = current3.abilityDef != null;
                            if (flag15)
                            {
                                if (current3.learned == true && (current3.abilityDef == TorannMagicDefOf.TM_RayofHope || current3.abilityDef == TorannMagicDefOf.TM_RayofHope_I || current3.abilityDef == TorannMagicDefOf.TM_RayofHope_II || current3.abilityDef == TorannMagicDefOf.TM_RayofHope_III))
                                {
                                    if (current3.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_RayofHope);
                                    }
                                    else if (current3.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_RayofHope_I);
                                    }
                                    else if (current3.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_RayofHope_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_RayofHope_III);
                                    }
                                }                             
                            }
                        }
                    }
                }
                bool flag41 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.HeartOfFrost);
                if (flag41)
                {
                    bool flag17 = !this.MagicData.MagicPowersHoF.NullOrEmpty<MagicPower>();
                    if (flag17)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current4 in this.MagicData.MagicPowersHoF)
                        {
                            bool flag18 = current4.abilityDef != null;
                            if (flag18)
                            {
                                if (current4.learned == true && (current4.abilityDef == TorannMagicDefOf.TM_Soothe || current4.abilityDef == TorannMagicDefOf.TM_Soothe_I || current4.abilityDef == TorannMagicDefOf.TM_Soothe_II || current4.abilityDef == TorannMagicDefOf.TM_Soothe_III))
                                {
                                    if (current4.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Soothe);
                                    }
                                    else if (current4.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Soothe_I);
                                    }
                                    else if (current4.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Soothe_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Soothe_III);
                                    }
                                }
                                if (current4.learned == true && (current4.abilityDef == TorannMagicDefOf.TM_FrostRay || current4.abilityDef == TorannMagicDefOf.TM_FrostRay_I || current4.abilityDef == TorannMagicDefOf.TM_FrostRay_II || current4.abilityDef == TorannMagicDefOf.TM_FrostRay_III))
                                {
                                    if (current4.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_FrostRay);
                                    }
                                    else if (current4.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_FrostRay_I);
                                    }
                                    else if (current4.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_FrostRay_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_FrostRay_III);
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag42 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.StormBorn);
                if (flag42)
                {
                    bool flag20 = !this.MagicData.MagicPowersSB.NullOrEmpty<MagicPower>();
                    if (flag20)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current5 in this.MagicData.MagicPowersSB)
                        {
                            bool flag21 = current5.abilityDef != null;
                            if (current5.learned == true && (current5.abilityDef == TorannMagicDefOf.TM_AMP || current5.abilityDef == TorannMagicDefOf.TM_AMP_I || current5.abilityDef == TorannMagicDefOf.TM_AMP_II || current5.abilityDef == TorannMagicDefOf.TM_AMP_III))
                            {
                                if (current5.level == 0)
                                {
                                    base.AddPawnAbility(TorannMagicDefOf.TM_AMP);
                                }
                                else if (current5.level == 1)
                                {
                                    base.AddPawnAbility(TorannMagicDefOf.TM_AMP_I);
                                }
                                else if (current5.level == 2)
                                {
                                    base.AddPawnAbility(TorannMagicDefOf.TM_AMP_II);
                                }
                                else
                                {
                                    base.AddPawnAbility(TorannMagicDefOf.TM_AMP_III);
                                }
                            }
                        }
                    }
                }
                bool flag43 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Arcanist);
                if (flag43)
                {
                    bool flag23 = !this.MagicData.MagicPowersA.NullOrEmpty<MagicPower>();
                    if (flag23)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current6 in this.MagicData.MagicPowersA)
                        {
                            bool flag24 = current6.abilityDef != null;
                            if (flag24)
                            {
                                if (current6.learned == true && (current6.abilityDef == TorannMagicDefOf.TM_Shadow || current6.abilityDef == TorannMagicDefOf.TM_Shadow_I || current6.abilityDef == TorannMagicDefOf.TM_Shadow_II || current6.abilityDef == TorannMagicDefOf.TM_Shadow_III))
                                {
                                    if (current6.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Shadow);
                                    }
                                    else if (current6.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Shadow_I);
                                    }
                                    else if (current6.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Shadow_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Shadow_III);
                                    }
                                }
                                if (current6.learned == true && (current6.abilityDef == TorannMagicDefOf.TM_MagicMissile || current6.abilityDef == TorannMagicDefOf.TM_MagicMissile_I || current6.abilityDef == TorannMagicDefOf.TM_MagicMissile_II || current6.abilityDef == TorannMagicDefOf.TM_MagicMissile_III))
                                {
                                    if (current6.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_MagicMissile);
                                    }
                                    else if (current6.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_MagicMissile_I);
                                    }
                                    else if (current6.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_MagicMissile_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_MagicMissile_III);
                                    }
                                }
                                if (current6.learned == true && (current6.abilityDef == TorannMagicDefOf.TM_Blink || current6.abilityDef == TorannMagicDefOf.TM_Blink_I || current6.abilityDef == TorannMagicDefOf.TM_Blink_II || current6.abilityDef == TorannMagicDefOf.TM_Blink_III))
                                {
                                    if (current6.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Blink);
                                    }
                                    else if (current6.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Blink_I);
                                    }
                                    else if (current6.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Blink_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Blink_III);
                                    }
                                }
                                if (current6.learned == true && (current6.abilityDef == TorannMagicDefOf.TM_Summon || current6.abilityDef == TorannMagicDefOf.TM_Summon_I || current6.abilityDef == TorannMagicDefOf.TM_Summon_II || current6.abilityDef == TorannMagicDefOf.TM_Summon_III))
                                {
                                    if (current6.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Summon);
                                    }
                                    else if (current6.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Summon_I);
                                    }
                                    else if (current6.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Summon_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Summon_III);
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag44 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Paladin);
                if (flag44)
                {
                    bool flag26 = !this.MagicData.MagicPowersP.NullOrEmpty<MagicPower>();
                    if (flag26)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current7 in this.MagicData.MagicPowersP)
                        {
                            bool flag27 = current7.abilityDef != null;
                            if (flag27)
                            {
                                if (current7.learned == true && (current7.abilityDef == TorannMagicDefOf.TM_Shield || current7.abilityDef == TorannMagicDefOf.TM_Shield_I || current7.abilityDef == TorannMagicDefOf.TM_Shield_II || current7.abilityDef == TorannMagicDefOf.TM_Shield_III))
                                {
                                    if (current7.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Shield);
                                    }
                                    else if (current7.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Shield_I);
                                    }
                                    else if (current7.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Shield_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_Shield_III);
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag45 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Summoner);
                if (flag45)
                {
                    bool flag28 = !this.MagicData.MagicPowersS.NullOrEmpty<MagicPower>();
                    if (flag28)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current8 in this.MagicData.MagicPowersS)
                        {
                            bool flag29 = current8.abilityDef != null;
                            if (flag29)
                            {
                                //if ((current7.abilityDef == TorannMagicDefOf.TM_Shield || current7.abilityDef == TorannMagicDefOf.TM_Shield_I || current7.abilityDef == TorannMagicDefOf.TM_Shield_II || current7.abilityDef == TorannMagicDefOf.TM_Shield_III))
                                //{
                                //    if (current7.level == 0)
                                //    {
                                //        base.AddPawnAbility(TorannMagicDefOf.TM_Shield);
                                //    }
                                //    else if (current7.level == 1)
                                //    {
                                //        base.AddPawnAbility(TorannMagicDefOf.TM_Shield_I);
                                //    }
                                //    else if (current7.level == 2)
                                //    {
                                //        base.AddPawnAbility(TorannMagicDefOf.TM_Shield_II);
                                //    }
                                //    else
                                //    {
                                //        base.AddPawnAbility(TorannMagicDefOf.TM_Shield_III);
                                //    }
                                //}
                            }
                        }
                    }
                }
                bool flag46 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Druid);
                if (flag46)
                {
                    bool flag30 = !this.MagicData.MagicPowersD.NullOrEmpty<MagicPower>();
                    if (flag30)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current9 in this.MagicData.MagicPowersD)
                        {
                            bool flag31 = current9.abilityDef != null;
                            if (flag31)
                            {
                                if (current9.learned == true && (current9.abilityDef == TorannMagicDefOf.TM_SootheAnimal || current9.abilityDef == TorannMagicDefOf.TM_SootheAnimal_I || current9.abilityDef == TorannMagicDefOf.TM_SootheAnimal_II || current9.abilityDef == TorannMagicDefOf.TM_SootheAnimal_III))
                                {
                                    if (current9.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_SootheAnimal);
                                    }
                                    else if (current9.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_SootheAnimal_I);
                                    }
                                    else if (current9.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_SootheAnimal_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_SootheAnimal_III);
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag47 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Necromancer);
                if (flag47)
                {
                    bool flag32 = !this.MagicData.MagicPowersN.NullOrEmpty<MagicPower>();
                    if (flag32)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current10 in this.MagicData.MagicPowersN)
                        {
                            bool flag33 = current10.abilityDef != null;
                            if (flag33)
                            {
                                if (current10.learned == true && (current10.abilityDef == TorannMagicDefOf.TM_DeathMark || current10.abilityDef == TorannMagicDefOf.TM_DeathMark_I || current10.abilityDef == TorannMagicDefOf.TM_DeathMark_II || current10.abilityDef == TorannMagicDefOf.TM_DeathMark_III))
                                {
                                    if (current10.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_DeathMark);
                                    }
                                    else if (current10.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_DeathMark_I);
                                    }
                                    else if (current10.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_DeathMark_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_DeathMark_III);
                                    }
                                }
                                if (current10.learned == true && (current10.abilityDef == TorannMagicDefOf.TM_ConsumeCorpse || current10.abilityDef == TorannMagicDefOf.TM_ConsumeCorpse_I || current10.abilityDef == TorannMagicDefOf.TM_ConsumeCorpse_II || current10.abilityDef == TorannMagicDefOf.TM_ConsumeCorpse_III))
                                {
                                    if (current10.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_ConsumeCorpse);
                                    }
                                    else if (current10.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_ConsumeCorpse_I);
                                    }
                                    else if (current10.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_ConsumeCorpse_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_ConsumeCorpse_III);
                                    }
                                }
                                if (current10.learned == true && (current10.abilityDef == TorannMagicDefOf.TM_CorpseExplosion || current10.abilityDef == TorannMagicDefOf.TM_CorpseExplosion_I || current10.abilityDef == TorannMagicDefOf.TM_CorpseExplosion_II || current10.abilityDef == TorannMagicDefOf.TM_CorpseExplosion_III))
                                {
                                    if (current10.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_CorpseExplosion);
                                    }
                                    else if (current10.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_CorpseExplosion_I);
                                    }
                                    else if (current10.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_CorpseExplosion_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_CorpseExplosion_III);
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag48 = abilityUser.story.traits.HasTrait(TorannMagicDefOf.Priest);
                if (flag48)
                {
                    bool flag34 = !this.MagicData.MagicPowersPR.NullOrEmpty<MagicPower>();
                    if (flag34)
                    {
                        //this.LoadPowers();
                        foreach (MagicPower current11 in this.MagicData.MagicPowersPR)
                        {
                            bool flag33 = current11.abilityDef != null;
                            if (flag33)
                            {
                                if (current11.learned == true && (current11.abilityDef == TorannMagicDefOf.TM_HealingCircle || current11.abilityDef == TorannMagicDefOf.TM_HealingCircle_I || current11.abilityDef == TorannMagicDefOf.TM_HealingCircle_II || current11.abilityDef == TorannMagicDefOf.TM_HealingCircle_III))
                                {
                                    if (current11.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_HealingCircle);
                                    }
                                    else if (current11.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_HealingCircle_I);
                                    }
                                    else if (current11.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_HealingCircle_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_HealingCircle_III);
                                    }
                                }
                                if (current11.learned == true && (current11.abilityDef == TorannMagicDefOf.TM_BestowMight || current11.abilityDef == TorannMagicDefOf.TM_BestowMight_I || current11.abilityDef == TorannMagicDefOf.TM_BestowMight_II || current11.abilityDef == TorannMagicDefOf.TM_BestowMight_III))
                                {
                                    if (current11.level == 0)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_BestowMight);
                                    }
                                    else if (current11.level == 1)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_BestowMight_I);
                                    }
                                    else if (current11.level == 2)
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_BestowMight_II);
                                    }
                                    else
                                    {
                                        base.AddPawnAbility(TorannMagicDefOf.TM_BestowMight_III);
                                    }
                                }                                
                            }
                        }
                    }
                }
                if (flag40)
                {
                    Log.Message("Loading Inner Fire Abilities");
                    MagicPower mpIF = this.MagicData.MagicPowersIF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Firebolt);
                    if(mpIF.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Firebolt);
                    }
                    mpIF = this.MagicData.MagicPowersIF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Fireclaw);
                    if (mpIF.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Fireclaw);
                    }
                    mpIF = this.MagicData.MagicPowersIF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Fireball);
                    if (mpIF.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Fireball);
                    }
                }
                if (flag41)
                {
                    Log.Message("Loading Heart of Frost Abilities");
                    MagicPower mpHoF = this.MagicData.MagicPowersHoF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Icebolt);
                    if (mpHoF.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Icebolt);
                    }
                    mpHoF = this.MagicData.MagicPowersHoF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Snowball);
                    if (mpHoF.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Snowball);
                    }
                    mpHoF = this.MagicData.MagicPowersHoF.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Rainmaker);
                    if (mpHoF.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Rainmaker);
                    }

                }
                if (flag42)
                {
                    Log.Message("Loading Storm Born Abilities");
                    MagicPower mpSB = this.MagicData.MagicPowersSB.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_LightningBolt);
                    if (mpSB.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_LightningBolt);
                    }
                    mpSB = this.MagicData.MagicPowersSB.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_LightningCloud);
                    if (mpSB.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_LightningCloud);
                    }
                    mpSB = this.MagicData.MagicPowersSB.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_LightningStorm);
                    if (mpSB.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_LightningStorm);
                    }
                }
                if (flag43)
                {
                    Log.Message("Loading Arcane Abilities");
                    MagicPower mpA = this.MagicData.MagicPowersA.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Teleport);
                    if (mpA.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Teleport);
                    }
                }
                if (flag44)
                {
                    Log.Message("Loading Paladin Abilities");
                    MagicPower mpP = this.MagicData.MagicPowersP.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Heal);
                    if (mpP.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Heal);
                    }
                    mpP = this.MagicData.MagicPowersP.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_ValiantCharge);
                    if (mpP.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_ValiantCharge);
                    }
                    mpP = this.MagicData.MagicPowersP.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Overwhelm);
                    if (mpP.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Overwhelm);
                    }
                }
                if (flag45)
                {
                    Log.Message("Loading Summoner Abilities");
                    MagicPower mpS = this.MagicData.MagicPowersS.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SummonMinion);
                    if (mpS.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_SummonMinion);
                    }
                    mpS = this.MagicData.MagicPowersS.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SummonPylon);
                    if (mpS.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_SummonPylon);
                    }
                    mpS = this.MagicData.MagicPowersS.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SummonExplosive);
                    if (mpS.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_SummonExplosive);
                    }
                    mpS = this.MagicData.MagicPowersS.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_SummonElemental);
                    if (mpS.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_SummonElemental);
                    }
                }
                if (flag46)
                {
                    Log.Message("Loading Druid Abilities");
                    MagicPower mpD = this.MagicData.MagicPowersD.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Poison);
                    if (mpD.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Poison);
                    }
                    mpD = this.MagicData.MagicPowersD.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Regenerate);
                    if (mpD.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Regenerate);
                    }
                    mpD = this.MagicData.MagicPowersD.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_CureDisease);
                    if (mpD.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_CureDisease);
                    }
                }
                if (flag47)
                {
                    Log.Message("Loading Necromancer Abilities");
                    MagicPower mpN = this.MagicData.MagicPowersN.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_RaiseUndead);
                    if (mpN.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_RaiseUndead);
                    }
                    mpN = this.MagicData.MagicPowersN.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_FogOfTorment);
                    if (mpN.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_FogOfTorment);
                    }
                }
                if (flag48)
                {
                    Log.Message("Loading Priest Abilities");
                    MagicPower mpPR = this.MagicData.MagicPowersPR.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_AdvancedHeal);
                    if (mpPR.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_AdvancedHeal);
                    }
                    mpPR = this.MagicData.MagicPowersPR.FirstOrDefault<MagicPower>((MagicPower x) => x.abilityDef == TorannMagicDefOf.TM_Purify);
                    if (mpPR.learned == true)
                    {
                        this.AddPawnAbility(TorannMagicDefOf.TM_Purify);
                    }
                }

                this.InitializeSpell();
                //base.UpdateAbilities();
            }
        }
    }
}
