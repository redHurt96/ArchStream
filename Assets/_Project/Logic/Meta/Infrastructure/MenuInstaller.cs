using _Project.Logic.Meta.Controllers;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Meta.Infrastructure
{
    internal class MenuInstaller : MonoInstaller
    {
        [SerializeField] private Menu _menu;
        
        public override void InstallBindings() => 
            Container.BindInterfacesTo<MenuController>().AsSingle().WithArguments(_menu);
    }
}