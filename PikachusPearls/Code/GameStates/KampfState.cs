using PikachusPearls.Code.GameStates.IngameElements;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikachusPearls.Code.GameStates
{
    class KampfState : IGameState
    {
        enum FightState
        {
            BeginAnimation,
            Main,
            End
        }

        Sprite Background;
        Pearlmon playersMon;
        Pearlmon enemyMon;
        FightState state;

        public KampfState()
        {
            Background = new Sprite(AssetManager.getTexture(AssetManager.TextureName.MainMenuBackground));
            state = FightState.BeginAnimation;
        }

        public void Draw(RenderWindow win)
        {
            
        }

        public void DrawGUI(GUI gui)
        {

        }

        public GameState Update()
        {

            return GameState.InFight;
        }
    }
}
