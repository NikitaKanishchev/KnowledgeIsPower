﻿using CodeBase.Infrastructure.Ads;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.UI.Windows.Shop;
using TMPro;

namespace CodeBase.UI.Windows
{
    public class ShopWindow : WindowBase
    {
        public TextMeshProUGUI SkullText;
        public RewardedAdItem AdItem;
        
        public void Construct(IAdsService adsService, IPersistentProgressService progressService)
        {
            base.Construct(progressService);
            AdItem.Construct(adsService, progressService);
        }

        protected override void Initialize()
        {
            AdItem.Initialize();
            RefreshSkullText();
        }

        protected override void SubscribeUpdates()
        {
            AdItem.Subscribe();
            Progress.WorldData.LootData.Changed += RefreshSkullText;
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            AdItem.CleanUp();
            Progress.WorldData.LootData.Changed -= RefreshSkullText;         
        }

        private void RefreshSkullText() => 
            SkullText.text = Progress.WorldData.LootData.Collected.ToString();
    }
}