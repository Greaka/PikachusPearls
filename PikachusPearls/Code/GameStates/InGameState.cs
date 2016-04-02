using PikachusPearls.Code.GameStates.IngameElements;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.GameStates
{
    class InGameState : IGameState
    {
        enum EInGameState
        {
            Overworld,
            InFight
        }

        Player player;
        EInGameState state;
        FightState fightState;

        public InGameState()
        {
            player = new Player(new Vector2f(10F, 10F));
            state = EInGameState.Overworld;
            fightState = new FightState();
        }

        void EnterFightState()
        {
            //fightState.EnterState(AssetManager.TextureName.MainMenuBackground, player, new Pearlmon());
        }

        public GameState Update()
        {
            if(fightState.State != FightState.EFightState.None)
            {
                fightState.Update();
            }
            else
            {
                player.update();
            }
            return GameState.InGame;
        }

        public void Draw(RenderWindow win)
        {
            if(fightState.State != FightState.EFightState.None)
            {
                fightState.Draw(win);
            }
            else
            {
                player.draw(win);
            }
        }

        public void DrawGUI(GUI gui)
        {
            if (fightState.State == FightState.EFightState.Main)
                fightState.DrawGUI(gui);
        }
    }
}
