using System;
using System.Threading.Tasks;
using _Project.Logic.Common.UI;
using Zenject;

namespace _Project.Logic.Common.Infrastructure
{
    internal class BootstrapEntryPoint : IInitializable
    {
        private readonly IScenesManager _scenesManager;

        public BootstrapEntryPoint(IScenesManager scenesManager) => 
            _scenesManager = scenesManager;

        public async void Initialize()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            
            _scenesManager.GoToMenu();
        }
    }
}