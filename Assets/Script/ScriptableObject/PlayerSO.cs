
using UnityEngine;

namespace Script.ScriptableObject
{
    [CreateAssetMenu (fileName = "PlayerSO", menuName = "PlayerData/New Player Data")]
    public class PlayerSO : UnityEngine.ScriptableObject
    {
        public float playerHealth;
    }
}