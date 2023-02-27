using Script.Enemy;
using Script.KillZone;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int damage = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<EnemyView>(out EnemyView enemyView) && enemyView != null)
        {
            enemyView.TakeDamage(damage);
            gameObject.SetActive(false);
        }
        
        if (collision.gameObject.TryGetComponent<KillZone>(out KillZone killZone) && killZone != null)
        {
            gameObject.SetActive(false);
        }
        
    }
}
