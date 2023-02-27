using UnityEngine;
using UnityEngine.UI;
namespace Script.UI
{
    public class UIManager : MonoSingletonGeneric<UIManager>
    {
        //[SerializeField] private Text currentBulletsText;
        //[SerializeField] private Text scoreText;
        //[SerializeField] private GameObject gameOverPanel;
        //[SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject[] _bullets;

        private int _currentBullets;
        private int _score;

        public void UpdateCurrentBullets(int bullets)
        {
            _currentBullets = bullets;
            if (_currentBullets >= 0 && _currentBullets < _bullets.Length)
            {
                _bullets[_currentBullets].SetActive(false);
            }
        }


        public void UpdateScore(int newScore)
        {
            _score += newScore;
            //scoreText.text = "Score: " + _score.ToString();
        }

        public void ShowGameOverPanel()
        {
            //gameOverPanel.SetActive(true);
        }

        public void ShowWinPanel()
        {
            //winPanel.SetActive(true);
        }
    }

}