using System;
using _Project.Logic.Common.UI;
using Zenject;

namespace _Project.Logic.Core.Controllers
{
    public class EndGameController : IInitializable, IDisposable
    {
        private readonly Tower.Tower _tower;
        private readonly IScenesManager _scenesManager;

        public EndGameController(Tower.Tower tower, IScenesManager scenesManager)
        {
            _tower = tower;
            _scenesManager = scenesManager;
        }

        public void Initialize() => 
            _tower.Dead += ReturnToMenu;

        public void Dispose() => 
            _tower.Dead -= ReturnToMenu;

        private void ReturnToMenu() => 
            _scenesManager.GoToMenu();
    }
}
