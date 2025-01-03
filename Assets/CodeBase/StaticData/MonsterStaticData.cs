﻿using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Static Data/Monster")]
    public class MonsterStaticData : ScriptableObject
    {
        public MonsterTypeId MonsterTypeId;

        public int Hp;
        public float Damage;

        public int MinLoot;

        public int MaxLoot;

        [Range(0.5f,10)]
        public float EffectiveDistance;

        [Range(0.5f,1)]
        public float Cleavage;

        [Range(1f, 10)] 
        public float MoveSpeed;

        public AssetReferenceGameObject PrefabReference;
    }
}