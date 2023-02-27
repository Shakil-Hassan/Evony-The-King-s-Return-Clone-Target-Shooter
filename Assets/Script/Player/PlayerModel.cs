using Script.ScriptableObject;

namespace Script.Player
{
    public class PlayerModel
    {
        private PlayerController _playerController;
        public PlayerSO PlayerSo ;
        public float PlayerHealth;

        public PlayerModel(PlayerSO playerSo)
        {
            PlayerSo = playerSo;
            PlayerHealth = PlayerSo.playerHealth;
        }
        
        public void SetPlayerController(PlayerController playerController)
        {
            _playerController = playerController;
        }
    }
}