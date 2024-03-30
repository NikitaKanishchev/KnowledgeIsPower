using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICorotineRunner corotineRunner, LoadingCurtain curtain)
        {
        StateMachine = new GameStateMachine(new SceneLoader(corotineRunner), curtain, AllServices.Cantainer);  
        }
        
    }
}
