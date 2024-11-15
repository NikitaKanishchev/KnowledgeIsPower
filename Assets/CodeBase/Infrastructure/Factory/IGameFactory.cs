using System.Collections.Generic;
using CodeBase.Enemy;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        GameObject CreateMonster(MonsterTypeId typeId, Transform parent);
        GameObject CreateHero(Vector3 at);
        GameObject CreateHud();
        LootPiece CreateLoot();
        void CreateSpawner(string spawnerId, Vector3 at, MonsterTypeId monsterTypeId);
        void CleanUp();
    }
}