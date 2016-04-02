using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.GameStates
{
    class Tiles
    {
        AnimatedSprite tileSprite;
        bool walkable;

        public AnimatedSprite getSprite { get { return tileSprite; } }

        public bool getWalkable()
        {
            return walkable;
        }

        public Tiles(int tileType, Vector2f position, Texture tex)
        {
            switch(tileType)
            {
                case 0:
                    {
                        break;
                    }
            }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(tileSprite);
        }
    }
}
