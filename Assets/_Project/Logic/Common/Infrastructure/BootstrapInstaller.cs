using _Project.Logic.Common.Domain;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Common.Infrastructure
{
    internal class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private TowerDataContainer _towerDataContainer;

        public override void InstallBindings()
        {
            Container.Bind<TowerData>().FromInstance(_towerDataContainer.Value).AsSingle().MoveIntoAllSubContainers();
            Container.BindInterfacesTo<BootstrapEntryPoint>().AsSingle();
        }
    }
}