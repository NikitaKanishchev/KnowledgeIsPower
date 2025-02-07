﻿using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State HeroState;
        public WorldData WorldData;
        public Stats Stats;
        public KillData KillData;
        public PurchaseData PurchaseData;


        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            HeroState = new State();
            Stats = new Stats();
            KillData = new KillData();
            PurchaseData = new PurchaseData();
        }
    }
}