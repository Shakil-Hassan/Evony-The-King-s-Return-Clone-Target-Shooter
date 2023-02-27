using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Menu
{
    public class LossMenu : MonoSingletonGeneric<LossMenu>
    {
        public GameObject lossMenu;

        public void ShowGameOver()
        {
            lossMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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