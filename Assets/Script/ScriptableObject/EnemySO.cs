using UnityEngine;

namespace Script.ScriptableObject
{
    [CreateAssetMenu (fileName = "EnemySO", menuName = "EnemyData/New Enemy")]
    public class EnemySO : UnityEngine.ScriptableObject
    {
        public float enemyHealth;
    }
}