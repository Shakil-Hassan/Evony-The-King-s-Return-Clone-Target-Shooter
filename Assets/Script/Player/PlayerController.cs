namespace Script.Player
{
    public class PlayerController
    {
        public PlayerModel PlayerModel;
        public PlayerView PlayerView;

        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            PlayerModel = playerModel;
            PlayerView = playerView;
            
            PlayerModel.SetPlayerController(this);
            PlayerView.SetPlayerController(this);
        }
    }
}