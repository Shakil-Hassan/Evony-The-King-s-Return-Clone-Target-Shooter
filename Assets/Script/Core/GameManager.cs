using Script.Enemy;
using Script.Player;
using Script.ScriptableObject;
using UnityEngine;

public class GameManager : MonoSingletonGeneric<GameManager>
{
    private PlayerController _playerController;
    private EnemyController _enemyController;
    private ProjectileController _projectileController;
    [SerializeField] private EnemyView enemyView;
    [SerializeField] private PlayerView playerView;

    public EnemySO enemySO;
    public PlayerSO playerSO;

    void Start()
    {
        InitPlayerController(playerSO);
        InitEnemyController(enemySO);
    }

    void InitPlayerController(PlayerSO playerSo)
    {
        PlayerModel playerModel = new PlayerModel(playerSo);
        _playerController = new PlayerController(playerModel, playerView);
    }

    void InitEnemyController(EnemySO enemySo)
    {
        EnemyModel enemyModel = new EnemyModel(enemySo);
        _enemyController = new EnemyController(enemyModel, enemyView);
    }
}