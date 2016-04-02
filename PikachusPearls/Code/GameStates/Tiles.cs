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
            switch (tileType1)
            {
                case 0:
                    {
                        walkable = false;

                        switch (tileType2)
                        {
                            case 0:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_bottom.png"));
                                    
                                    break;
                                }
                            case 1:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_bottomLeft.png"));
                                    break;
                                }
                            case 2:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_bottomRight.png"));
                                    break;
                                }
                            case 3:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_innerBottomLeft.png"));
                                    break;
                                }
                            case 4:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_innerBottomRight.png"));
                                    break;
                                }
                            case 5:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_innerTopLeft.png"));
                                    break;
                                }
                            case 6:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_innerTopRight.png"));
                                    break;
                                }
                            case 7:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_left.png"));
                                    break;
                                }
                            case 8:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_middle.png"));
                                    break;
                                }
                            case 9:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_right.png"));
                                    break;
                                }
                            case 10:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_top.png"));
                                    break;
                                }
                            case 11:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_topLeft.png"));
                                    break;
                                }
                            case 12:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/water_topRight.png"));
                                    break;
                                }
                        }
                        break;
                    }
                case 1:
                    {
                        walkable = true;

                        switch(tileType2)
                        {
                            case 0:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_bottom.png"));
                                    break;
                                }
                            case 1:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_bottomLeft.png"));
                                    break;
                                }
                            case 2:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_bottomRight.png"));
                                    break;
                                }
                            case 3:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_left.png"));
                                    break;
                                }
                            case 4:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_middle.png"));
                                    break;
                                }
                            case 5:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_right.png"));
                                    break;
                                }
                            case 6:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_top.png"));
                                    break;
                                }
                            case 7:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_topLeft.png"));
                                    break;
                                }
                            case 8:
                                {
                                    tileSprite = new Sprite(new Texture("Textures/sand_topRight.png"));
                                    break;
                                }
                        }
                        break;
                    }

                case 2:
                    {
                        tileSprite = new Sprite(new Texture("Textures/tree.png"));
                        walkable = false;
                        break;
                    }

                case 3:
                    {
                        tileSprite = new Sprite(new Texture("Textures/grass_high.png"));
                        walkable = true;
                        break;
                    }

                case 4:
                    {
                        tileSprite = new Sprite(new Texture("Textures/grass_plain.png"));
                        walkable = true;
                        break;
                    }
            }
            tileSprite.Position = position;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(tileSprite);
        }
    }
}
