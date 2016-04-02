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
        Sprite tileSprite;
        bool walkable;

        public Sprite getSprite { get { return tileSprite; } }

        public bool getWalkable()
        {
            return walkable;
        }

        public Tiles(int tileType1, int tileType2, Vector2f position)
        {
            switch(tileType1)
            {
                case 0:
                    {
                        switch(tileType2)
                        {
                            case 0:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_bottom.png"));
                                    break;
                                }
                        }
                        tileSprite.Position = position;
                        walkable = false;
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
