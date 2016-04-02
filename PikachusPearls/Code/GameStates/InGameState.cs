using PikachusPearls.Code.GameStates.IngameElements;
using PikachusPearls.Code.Utility;
using SFML.Graphics;
using SFML.Window;
using System.Drawing;

namespace PikachusPearls.Code.GameStates
{
    class InGameState : IGameState
    {
        Player player;
        FightState fightState;
        Map map;

        public InGameState()
        {
            player = new Player(new Vector2f(10F, 10F));
            fightState = new FightState();
            map = new Map(new Bitmap("Map/Map.bmp"));
        }

        void EnterFightState()
        {
            //fightState.EnterState(AssetManager.TextureName.MainMenuBackground, player, new Pearlmon());
        }

        public GameState Update(GameTime gameTime)
        {
            if(fightState.State != FightState.EFightState.None)
            {
                fightState.Update();
            }
            else
            {
                player.Update();
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
                map.Draw(win);
                player.Draw(win);
            }
        }

        public void DrawGUI(GUI gui)
        {
            if (fightState.State == FightState.EFightState.Main)
                fightState.DrawGUI(gui);

            else
            {
                
            }
        }
    }
}
