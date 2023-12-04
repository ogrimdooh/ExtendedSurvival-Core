using System.Linq;
using System.Text;
using VRageMath;

namespace ExtendedSurvival.Core
{
    public abstract class SimpleDefinition
    {

        public UniqueEntityId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Volume { get; set; }
        public float Mass { get; set; }
        public Vector2I AcquisitionAmount { get; set; } = Vector2I.Zero;
        public Vector2I OrderAmount { get; set; } = Vector2I.Zero;
        public Vector2I OfferAmount { get; set; } = Vector2I.Zero;
        public int MinimalPricePerUnit { get; set; }
        public bool CanPlayerOrder { get; set; } = false;

        public virtual float GetVolume()
        {
            return Volume / 1000;
        }

        public virtual float GetMass()
        {
            return Mass;
        }

        public virtual string GetFullDescription()
        {
            return Description;
        }

        public virtual string GetPropertiesDescription()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_MASS)}: {Mass.ToString("#0.00")}Kg");
            sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_VOLUME)}: {Volume.ToString("#0.00")}L");
            if (SpaceStationController.SHOP_ITENS.ContainsKey(Id))
            {
                var shopInfo = SpaceStationController.SHOP_ITENS[Id];
                if (shopInfo.IsLoaded)
                {
                    sb.AppendLine("");
                    sb.AppendLine(LanguageProvider.GetEntry(LanguageEntries.TERMS_ECONOMY_INFO));
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_RARITY)}: {SpaceStationController.GetItemRarityName(shopInfo.Rarity)}");
                    var canBuy = shopInfo.CanBuy ? LanguageProvider.GetEntry(LanguageEntries.TERMS_YES_NAME) : LanguageProvider.GetEntry(LanguageEntries.TERMS_NO_NAME);
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CANBUY)}: {canBuy}");
                    var canSell = shopInfo.CanSell ? LanguageProvider.GetEntry(LanguageEntries.TERMS_YES_NAME) : LanguageProvider.GetEntry(LanguageEntries.TERMS_NO_NAME);
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CANSELL)}: {canSell}");
                    var canOrder = shopInfo.CanOrder ? LanguageProvider.GetEntry(LanguageEntries.TERMS_YES_NAME) : LanguageProvider.GetEntry(LanguageEntries.TERMS_NO_NAME);
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CANORDER)}: {canOrder}");
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_BASEVALUE)}: ${shopInfo.BaseValue}");
                    var factions = string.Join(", ", shopInfo.TargetFactions.Select(x => SpaceStationController.GetFactionTypeName(x)).ToArray());
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_TARGETFACTIONS)}: {factions}");
                }
            }
            return sb.ToString();
        }

        public virtual string GetHelpDescription()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetPropertiesDescription());
            sb.AppendLine("");
            sb.AppendLine(GetFullDescription());
            return sb.ToString();
        }

    }

}