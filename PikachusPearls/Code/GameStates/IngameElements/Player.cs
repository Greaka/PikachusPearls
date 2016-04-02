using System;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.GameStates.IngameElements
{
    public class Player
    {
        Sprite playerSprite;
        Texture playerTex;
        Pearlmon[] Pearlmons;

        public Player(Vector2f position)
        {
           
        }

        public Pearlmon GetFirstMon()
        {
            return Pearlmons[0];
        }

        public void Update()
        {
            
        }

        public void Draw(RenderWindow win)
        {
            //win.Draw(playerSprite);
        }
    }
}
