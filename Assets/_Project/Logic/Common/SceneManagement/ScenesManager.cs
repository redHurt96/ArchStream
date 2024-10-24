using _Project.Logic.Common.UI;
using static UnityEngine.SceneManagement.LoadSceneMode;
using static UnityEngine.SceneManagement.SceneManager;

namespace _Project.Logic.Common.SceneManagement
{
    internal class ScenesManager : IScenesManager
    {
        private const string GAME = "Game";
        private const string MENU = "Menu";

        public void GoToGame()
        {
            if (loadedSceneCount > 1)
                UnloadSceneAsync(MENU);
            
            LoadScene(GAME, Additive);
        }

        public void GoToMenu()
        {
            if (loadedSceneCount > 1)
                UnloadSceneAsync(GAME);
            
            LoadScene(MENU, Additive);
        }
    }
}