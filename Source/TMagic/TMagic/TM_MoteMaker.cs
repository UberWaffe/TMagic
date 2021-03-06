﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace TorannMagic
{
    public static class TM_MoteMaker
    {
        public static void ThrowManaPuff(Vector3 loc, Map map, float scale)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.SaturatedLowPriority)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_ManaPuff, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = (float)Rand.Range(-60, 60);
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(0.6f, 0.75f));
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
        }

        public static void ThrowEnchantingMote(Vector3 loc, Map map, float scale)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.SaturatedLowPriority)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_Enchanting, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = (float)Rand.Range(150, 200);
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(-0.35f, -0.75f));
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
        }

        public static void ThrowSiphonMote(Vector3 loc, Map map, float scale)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.SaturatedLowPriority)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_Siphon, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = (float)Rand.Range(-60, 60);
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(0.4f, 0.5f));
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
        }

        public static void ThrowPoisonMote(Vector3 loc, Map map, float scale)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.SaturatedLowPriority)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_Poison, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = (float)Rand.Range(-60, 60);
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(0.4f, 0.5f));
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
        }

        public static void ThrowRegenMote(Vector3 loc, Map map, float scale)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.SaturatedLowPriority)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_Regen, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = (float)Rand.Range(-60, 60);
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(0.2f, 0.3f));
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
        }

        public static void ThrowCrossStrike(Vector3 loc, Map map, float scale)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.Saturated)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_CrossStrike, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = 0f;
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(0.05f, 0.1f));
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
        }

        public static void ThrowBloodSquirt(Vector3 loc, Map map, float scale)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.SaturatedLowPriority)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_BloodSquirt, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = (float)Rand.Range(-60, 60);
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(1f, 2f));
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
        }

        public static void ThrowMultiStrike(Vector3 loc, Map map, float scale)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.Saturated)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_MultiStrike, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = (float)Rand.Range(-60, 60);
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(0.05f, 0.1f));
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
        }

        public static void ThrowScreamMote(Vector3 loc, Map map, float scale, int r, int g, int b)
        {
            if (!loc.ShouldSpawnMotesAt(map) || map.moteCounter.Saturated)
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(TorannMagicDefOf.Mote_ScreamMote, null);
            moteThrown.Scale = 1.9f * scale;
            moteThrown.rotationRate = (float)Rand.Range(-5, 5);
            moteThrown.exactPosition = loc;
            moteThrown.SetVelocity((float)Rand.Range(0, 360), Rand.Range(0.2f, 0.5f));
            ColorInt colorInt = new ColorInt(r, g, b);
            Color arg_50_0 = colorInt.ToColor;
            moteThrown.SetColor(arg_50_0, false);
            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map);
            
        }

        public static void MakePowerBeamMote(IntVec3 cell, Map map, float scale, float rot, float duration)
        {
            Mote mote = (Mote)ThingMaker.MakeThing(ThingDefOf.Mote_PowerBeam, null);
            MakePowerBeamMote(cell, map, scale, rot, duration, mote.def.mote.fadeInTime, mote.def.mote.fadeOutTime);
        }

        public static void MakePowerBeamMote(IntVec3 cell, Map map, float scale, float rot, float duration, float fadeIn, float fadeOut)
        {
            Mote mote = (Mote)ThingMaker.MakeThing(TorannMagicDefOf.Mote_PowerBeamBlue, null);
            mote.exactPosition = cell.ToVector3Shifted();
            mote.Scale = scale;
            mote.rotationRate = rot;
            mote.def.mote.solidTime = (duration - fadeIn - fadeOut);
            mote.def.mote.fadeInTime = fadeIn;
            mote.def.mote.fadeOutTime = fadeOut;
            GenSpawn.Spawn(mote, cell, map);
        }

        public static void MakePowerBeamMoteColor(IntVec3 cell, Map map, float scale, float rot, float duration, float fadeIn, float fadeOut, Color color)
        {
            
            Mote mote = (Mote)ThingMaker.MakeThing(TorannMagicDefOf.Mote_PowerBeamGold, null);            
            mote.exactPosition = cell.ToVector3Shifted();
            mote.Scale = scale;
            mote.rotationRate = rot;
            mote.def.mote.solidTime = (duration - fadeIn - fadeOut);
            mote.def.mote.fadeInTime = fadeIn;
            mote.def.mote.fadeOutTime = fadeOut;
            //mote.Graphic.color = color;
            GenSpawn.Spawn(mote, cell, map);
        }

        public static void MakeBombardmentMote(IntVec3 cell, Map map, float scale, float rot, float duration)
        {
            Mote mote = (Mote)ThingMaker.MakeThing(ThingDefOf.Mote_Bombardment, null);
            MakeBombardmentMote(cell, map, scale, rot, duration, mote.def.mote.fadeInTime, mote.def.mote.fadeOutTime);
        }

        public static void MakeBombardmentMote(IntVec3 cell, Map map, float scale, float rot, float duration, float fadeIn, float fadeOut)
        {
            Mote mote = (Mote)ThingMaker.MakeThing(ThingDefOf.Mote_Bombardment, null);
            mote.exactPosition = cell.ToVector3Shifted();
            mote.Scale = scale * 6f;
            mote.rotationRate = rot;       
            mote.def.mote.solidTime = (duration - fadeIn - fadeOut);
            GenSpawn.Spawn(mote, cell, map);
        }
    }
}
