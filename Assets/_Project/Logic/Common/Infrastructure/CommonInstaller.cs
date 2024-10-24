using _Project.Logic.Common.SceneManagement;
using Zenject;

namespace _Project.Logic.Common.Infrastructure
{
    internal class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.BindInterfacesTo<ScenesManager>().AsSingle();
    }
}
