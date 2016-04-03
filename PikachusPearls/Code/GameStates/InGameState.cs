using System;
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
        Random rnd = new Random();

        public InGameState()
        {
            map = new Map(new Bitmap("Map/Map.bmp"));
            player = new Player(map, new Vector2(40, 40));
            fightState = new FightState();
            player.OnNewPlayerPosition += WildCreatureAppearance;
        }

        private void WildCreatureAppearance(Vector2i position)
        {
            var foreground = map.GetForeground(position);
            if (foreground == null) return;
            if (foreground.Texture.CPointer != AssetManager.getTexture(AssetManager.TextureName.GrassHigh).CPointer) return;
            if (rnd.Next(1, 20) == 1)
            {
                EnterFightState();
            }
        }

        void EnterFightState()
        {
            Console.Out.WriteLine("FIGHT!");
            Existing_Pearlmon encountered = (Existing_Pearlmon) rnd.Next(0, (int)Existing_Pearlmon.Count);

            switch (encountered)
            {
                case Existing_Pearlmon.T_Rex:
                    fightState.EnterState(AssetManager.TextureName.MainMenuBackground, player, new T_Rex((uint)rnd.Next(1, 10)));
                    break;

                case Existing_Pearlmon.Knight:
                    fightState.EnterState(AssetManager.TextureName.MainMenuBackground, player, new Knight((uint)rnd.Next(1, 10)));
                    break;

                default:
                    fightState.EnterState(AssetManager.TextureName.MainMenuBackground, player, new T_Rex(2));
                    break;
            }
        }

        public GameState Update(GameTime gameTime)
        {
            if(fightState.State != FightState.EFightState.None)
            {
                fightState.Update();
            }
            else
            {
                player.Update(gameTime);
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
                map.Draw(win, player.Draw(win));
            }
        }

        public void DrawGUI(GUI gui)
        {
            
        }
    }
}
