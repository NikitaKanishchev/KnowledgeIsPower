using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
    public NavMeshAgent Agent;

    private Transform _heroTransform;
    private IGameFactory _gameFactory;
    
    private const float MinimalDistance = 1;

    private void Start()
    {
        _gameFactory = AllServices.Cantainer.Single<IGameFactory>();

        if (_gameFactory.HeroGameObject != null)
            InitializeHeroTransform();
        else
            _gameFactory.HeroCreated += HeroCreated;
    }

    private void Update()
    {
        if (Initialized() && HeroNotReached())
            Agent.destination = _heroTransform.position;
    }

    private bool Initialized() => 
        _heroTransform != null;

    private void HeroCreated() => 
        InitializeHeroTransform();

    private void InitializeHeroTransform() => 
        _heroTransform = _gameFactory.HeroGameObject.transform;

    private bool HeroNotReached() => 
        Vector3.Distance(Agent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}