using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace _Project.Logic.Meta.Infrastructure
{
    internal class Menu : MonoBehaviour
    {
        public Button.ButtonClickedEvent OnStartGame => _button.onClick;
        
        [SerializeField] private Button _button;
    }
}
