using Assets.Script.Menu;
using UnityEngine;

namespace Script.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController _enemyController;

        private void Update()
        {
            if (_enemyController.EnemyModel.EnemyHealth <= 0)
            {
                Destroy(gameObject);
                WinMenu.Instance.ShowWinMenu();
            }
        }

        public void TakeDamage(int damage)
        {
            _enemyController.EnemyModel.EnemyHealth -= damage;
            Debug.Log("Current Health : " + _enemyController.EnemyModel.EnemyHealth);
        }
        
        public void SetEnemyController(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }
    }
}