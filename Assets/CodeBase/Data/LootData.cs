using System;
using CodeBase.Enemy;

namespace CodeBase.Data
{
    [Serializable]
    public class LootData
    {
        public int Collected;
        public Action Changed;
        public LootPieceDataDictionary LootPiecesOnScene = new LootPieceDataDictionary();

        public void Collect(Loot loot)
        {
            Collected += loot.Value;
            Changed?.Invoke();
        }
        public void Add(int loot)
        {
            Collected += loot;
            Changed?.Invoke();
        }
    }
}