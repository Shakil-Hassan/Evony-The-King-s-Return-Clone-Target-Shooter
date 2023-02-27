using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Core
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private SceneAsset mainGameLevelScene;

        public void OnPLayBtnPress()
        {
            SceneManager.LoadScene(mainGameLevelScene.name);
        }
        
    }
}