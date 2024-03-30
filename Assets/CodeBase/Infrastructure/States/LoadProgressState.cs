﻿using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }
    
        public void Enter()
        {
            LoadProgressInitNew();
            
            _gameStateMachine.Enter<LoadLevelState,string>(_progressService.Progress.WorldData.PositionOnLevel.Level);
        }

        public void Exit()
        {
                        
        }

        private void LoadProgressInitNew() =>
            _progressService.Progress = 
                _saveLoadService.LoadProgress()  
                ?? NewProgress();

        private PlayerProgress NewProgress()
        {
            var progress =  new PlayerProgress(initialLevel: "Main");

            progress.HeroState.MaxHP = 50;
            progress.HeroState.ResetHp();

            return progress;
        }
    }
}