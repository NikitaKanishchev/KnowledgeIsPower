using CodeBase.Infrastructure.Ads;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.IAP;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.UI.Windows.Shop;
using TMPro;

namespace CodeBase.UI.Windows
{
    public class ShopWindow : WindowBase
    {
        public TextMeshProUGUI SkullText;
        public RewardedAdItem AdItem;
        public ShopItemsContainer ShopItemsContainer;
        
        public void Construct(
            IAdsService adsService,
            IPersistentProgressService progressService,
            IIAPService iapService,
            IAssets assets)
        {
            base.Construct(progressService);
            AdItem.Construct(adsService, progressService);
            ShopItemsContainer.Construct(iapService, progressService, assets);
        }

        protected override void Initialize()
        {
            AdItem.Initialize();
            ShopItemsContainer.Initialize();
            RefreshSkullText();
        }

        protected override void SubscribeUpdates()
        {
            AdItem.Subscribe();
            ShopItemsContainer.Subscribe();
            Progress.WorldData.LootData.Changed += RefreshSkullText;
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            AdItem.CleanUp();
            ShopItemsContainer.CleanUp();
            Progress.WorldData.LootData.Changed -= RefreshSkullText;         
        }

        private void RefreshSkullText() => 
            SkullText.text = Progress.WorldData.LootData.Collected.ToString();
    }
}