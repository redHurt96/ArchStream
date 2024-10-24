using System;
using _Project.Logic.Common.UI;
using _Project.Logic.Meta.Infrastructure;
using Zenject;

namespace _Project.Logic.Meta.Controllers
{
    internal class MenuController : IInitializable, IDisposable
    {
        private readonly Menu _menu;
        private readonly IScenesManager _scenesManager;

        internal MenuController(Menu menu, IScenesManager scenesManager)
        {
            _menu = menu;
            _scenesManager = scenesManager;
        }

        public void Initialize() => 
            _menu.OnStartGame.AddListener(_scenesManager.GoToGame);

        public void Dispose() => 
            _menu.OnStartGame.RemoveListener(_scenesManager.GoToGame);
    }
}