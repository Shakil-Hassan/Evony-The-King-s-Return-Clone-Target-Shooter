
namespace Script.Enemy
{
    public class EnemyController 
    {
        public EnemyModel EnemyModel;
        public EnemyView EnemyView;

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
        {
            EnemyModel = enemyModel;
            EnemyView = enemyView;
            EnemyModel.SetEnemyController(this);
            EnemyView.SetEnemyController(this);
        }
    }
}