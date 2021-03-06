﻿using AbilityUser;
using RimWorld;
using System.Linq;
using Verse;

namespace TorannMagic
{
	public class Projectile_LightningStorm : Projectile_AbilityBase
	{

		private IntVec3 strikeLoc = IntVec3.Invalid;

		private int age = -1;

		private bool primed = true;

		private int duration = 600;

		private int boltDelay = 0;

		private int lastStrike = 0;

		private int strikeInt = 0;

        private int verVal;
        private int pwrVal;

        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
		{
			bool flag = this.age < duration;
			if (!flag)
			{
				base.Destroy(mode);
			}
		}

		protected override void Impact(Thing hitThing)
		{
			Map map = base.Map;
            base.Impact(hitThing);

            Pawn pawn = this.launcher as Pawn;
            CompAbilityUserMagic comp = pawn.GetComp<CompAbilityUserMagic>();
            MagicPowerSkill pwr = pawn.GetComp<CompAbilityUserMagic>().MagicData.MagicPowerSkill_LightningStorm.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_LightningStorm_pwr");
            MagicPowerSkill ver = pawn.GetComp<CompAbilityUserMagic>().MagicData.MagicPowerSkill_LightningStorm.FirstOrDefault((MagicPowerSkill x) => x.label == "TM_LightningStorm_ver");
            ModOptions.SettingsRef settingsRef = new ModOptions.SettingsRef();
            pwrVal = pwr.level;
            verVal = ver.level;
            if (settingsRef.AIHardMode && !pawn.IsColonistPlayerControlled)
            {
                pwrVal = 3;
                verVal = 3;
            }

            duration = 600 + (verVal * 200);
            CellRect cellRect = CellRect.CenteredOn(base.Position, 8 + (verVal * 2));
			cellRect.ClipInsideMap(map);

				if (this.primed == true)
				{
					if (((this.boltDelay + this.lastStrike) < this.age))
					{
						IntVec3 randomCell = cellRect.RandomCell;
						Map.weatherManager.eventHandler.AddEvent(new WeatherEvent_LightningStrike(map, randomCell));
						this.LightningBlast(pwrVal, randomCell, map, 2.2f);
						strikeInt++;
						this.lastStrike = this.age;
						this.boltDelay = Rand.Range(10 - (pwrVal * 2), 50 - (pwrVal * 7));

						bool flag1 = this.age <= duration;
						if (!flag1)
						{
							this.primed = false;
							map.weatherDecider.DisableRainFor(0);
							map.weatherDecider.StartNextWeather();
						}
					}
				}
		}

		protected void LightningBlast(int pwr, IntVec3 pos, Map map, float radius)
		{
			ThingDef def = this.def;
			Explosion(pwr, pos, map, radius, DamageDefOf.EMP, this.launcher, null, def, this.equipmentDef, ThingDefOf.Spark, 4.4f, 1, false, null, 0f, 1);
			Explosion(pwr, pos, map, radius, DamageDefOf.Stun, this.launcher, null, def, this.equipmentDef, ThingDefOf.Mote_Stun, 1.4f, 1, false, null, 0f, 1);
			Explosion(pwr, pos, map, radius, DamageDefOf.Bomb, this.launcher, null, def, this.equipmentDef, ThingDefOf.Mote_Smoke, 0.4f, 1, false, null, 0f, 1);
		}

		public static void Explosion(int pwr, IntVec3 center, Map map, float radius, DamageDef damType, Thing instigator, SoundDef explosionSound = null, ThingDef projectile = null, ThingDef source = null, ThingDef postExplosionSpawnThingDef = null, float postExplosionSpawnChance = 0f, int postExplosionSpawnThingCount = 1, bool applyDamageToExplosionCellsNeighbors = false, ThingDef preExplosionSpawnThingDef = null, float preExplosionSpawnChance = 0f, int preExplosionSpawnThingCount = 1)
		{
			System.Random rnd = new System.Random();
			int modDamAmountRand = modDamAmountRand = GenMath.RoundRandom(rnd.Next(5 + (pwr*2), projectile.projectile.damageAmountBase + (pwr * 5)));
            if (pwr >= 1)
            {
                radius = (float)(rnd.Next(pwr, pwr*2)/1.8);
            }
			if (map == null)
			{
				Log.Warning("Tried to do explosion in a null map.");
				return;
			}
            Explosion explosion = (Explosion)GenSpawn.Spawn(ThingDefOf.Explosion, center, map);
            explosion.dealMoreDamageAtCenter = true;
            explosion.chanceToStartFire = 0.0f;
            explosion.Position = center;
			explosion.radius = radius;
			explosion.damType = damType;
			explosion.instigator = instigator;
			explosion.damAmount = ((projectile == null) ? GenMath.RoundRandom((float)damType.explosionDamage) : modDamAmountRand);
			explosion.weapon = source;
			explosion.preExplosionSpawnThingDef = preExplosionSpawnThingDef;
			explosion.preExplosionSpawnChance = preExplosionSpawnChance;
			explosion.preExplosionSpawnThingCount = preExplosionSpawnThingCount;
			explosion.postExplosionSpawnThingDef = postExplosionSpawnThingDef;
			explosion.postExplosionSpawnChance = postExplosionSpawnChance;
			explosion.postExplosionSpawnThingCount = postExplosionSpawnThingCount;
			explosion.applyDamageToExplosionCellsNeighbors = applyDamageToExplosionCellsNeighbors;
            explosion.StartExplosion(explosionSound);
		}

		public override void Tick()
		{
			base.Tick();
			this.age++;
		}

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<bool>(ref this.primed, "primed", true, false);
            Scribe_Values.Look<int>(ref this.age, "age", -1, false);
            Scribe_Values.Look<int>(ref this.duration, "duration", 600, false);
            Scribe_Values.Look<int>(ref this.boltDelay, "boltDelay", 0, false);
            Scribe_Values.Look<int>(ref this.lastStrike, "lastStrike", 0, false);
            Scribe_Values.Look<int>(ref this.strikeInt, "strikeInt", 0, false);
        }
    }
}
