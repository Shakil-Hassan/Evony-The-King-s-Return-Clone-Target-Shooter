using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Menu
{
    public class WinMenu : MonoSingletonGeneric<WinMenu>
    {

        public GameObject winMenuUI;

        public void ShowWinMenu()
        {
            winMenuUI.SetActive(true);
            Time.timeScale = 0f; 
        }

        public void PlayNext()
        {
            SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings - 1));
        }

        public void OnHomeButtonPress()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}