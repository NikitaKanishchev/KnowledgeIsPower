﻿using System.Collections;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using TMPro;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class LootPiece : MonoBehaviour , ISavedProgress
    {
        public GameObject Skull;
        public GameObject PickupFxPrefab;
        public GameObject PickupPopup;
        public TextMeshPro LootText;

        private WorldData _worldData;
        private Loot _loot;
        
        private string _id;
        private bool _picked;

        public void Construct(WorldData worldData) => 
            _worldData = worldData;

        public void Initialize(Loot loot) => 
                _loot = loot;

        private void Start() => 
            _id = GetComponent<UniqueId>().Id;

        private void OnTriggerEnter(Collider other)
        {
            if (!_picked)
            {
                _picked = true;
                Pickup();
            }
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            if (_picked)
                return;

            LootPieceDataDictionary lootPiecesOnScene = progress.WorldData.LootData.LootPiecesOnScene;

            if (!lootPiecesOnScene.Dictionary.ContainsKey(_id))
                lootPiecesOnScene.Dictionary
                    .Add(_id, new LootPieceData(transform.position.AsVectorData(), _loot));
        }

        private void Pickup()
        {
            
            UpdateWorldData();
            HideSkull();
            PlayPickupFx();
            ShowText();    
            StartCoroutine(StartDestroyTimer());
            
        }

        private void UpdateWorldData()
        {
            UpdateCollectedLootAmount();
            RemoveLootPieceFromSavedPieces();
        }

        private void UpdateCollectedLootAmount()
        {
            _worldData.LootData.Collect(_loot);
        }

        private void RemoveLootPieceFromSavedPieces()
        {
            LootPieceDataDictionary savedLootPieces = _worldData.LootData.LootPiecesOnScene;

            if (savedLootPieces.Dictionary.ContainsKey(_id))
                savedLootPieces.Dictionary.Remove(_id);
        }

        private void HideSkull() => 
            Skull.SetActive(false);

        private void PlayPickupFx() => 
            Instantiate(PickupFxPrefab, transform.position, Quaternion.identity);

        private void ShowText()
        {
            LootText.text = $"{_loot.Value}";
            PickupPopup.SetActive(true);
        }

        private IEnumerator StartDestroyTimer()
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }

        public void LoadProgress(PlayerProgress progress)
        {
        }
    }
}