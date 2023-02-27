using Script.ScriptableObject;

namespace Script.Enemy
{
    public class EnemyModel
    {
        private EnemyController _enemyController;
        public EnemySO EnemySo;
        public float EnemyHealth;

        public EnemyModel(EnemySO enemySo)
        {
            EnemySo = enemySo;
            EnemyHealth = EnemySo.enemyHealth;
        }

        public void SetEnemyController(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }
    }
}