using _Project.Logic.Core.Controllers;
using _Project.Logic.Tower;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Tower.Tower _tower;
        [SerializeField] private Enemy _enemyPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemiesFactory>().AsSingle().WithArguments(_enemyPrefab, _tower, transform);
            Container.BindInterfacesTo<EnemiesRepository>().AsSingle();
            Container.BindInterfacesTo<SpawnController>().AsSingle();
            Container.BindInterfacesTo<EndGameController>().AsSingle().WithArguments(_tower);
        }
    }
}