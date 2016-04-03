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
        Sprite foreGround;
        bool walkable;

        public Sprite getSprite => tileSprite;
        public Sprite getForeGround => foreGround;

        public bool getWalkable()
        {
            return walkable;
        }

        void SetForeGround(AssetManager.TextureName t)
        {
            foreGround = new Sprite(AssetManager.getTexture(t));
            foreGround.Position = tileSprite.Position;
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
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterBottom)); 
                                    
                                    break;
                                }
                            case 1:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterBottomLeft));
                                    break;
                                }
                            case 2:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterBottomRight));
                                    break;
                                }
                            case 3:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterInnerBottomLeft));
                                    break;
                                }
                            case 4:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterInnerBottomRight)); 
                                    break;
                                }
                            case 5:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterInnerTopLeft)); 
                                    break;
                                }
                            case 6:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterInnerTopRight)); 
                                    break;
                                }
                            case 7:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterLeft)); 
                                    break;
                                }
                            case 8:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterMiddle)); 
                                    break;
                                }
                            case 9:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterRight));
                                    break;
                                }
                            case 10:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterTop)); 
                                    break;
                                }
                            case 11:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterTopLeft)); 
                                    break;
                                }
                            case 12:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.WaterTopRight)); 
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
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandBottom)); 
                                    break;
                                }
                            case 1:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandBottomLeft)); 
                                    break;
                                }
                            case 2:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandBottomRight));
                                    break;
                                }
                            case 3:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandLeft));
                                    break;
                                }
                            case 4:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandMiddle)); 
                                    break;
                                }
                            case 5:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandRight)); 
                                    break;
                                }
                            case 6:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandTop)); 
                                    break;
                                }
                            case 7:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandTopLeft)); 
                                    break;
                                }
                            case 8:
                                {
                                    tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SandTopRight));
                                    break;
                                }
                        }
                        break;
                    }

                case 2:
                    {
                        tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.Tree)); 
                        walkable = false;
                        break;
                    }

                case 3:
                    {
                        tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.GrassPlain));
                        foreGround = new Sprite(AssetManager.getTexture(AssetManager.TextureName.GrassHigh));
                        foreGround.Position = position;
                        walkable = true;
                        break;
                    }

                case 4:
                    {
                        tileSprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.GrassPlain));
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

        public void DrawForeGround(RenderWindow win)
        {
            if (foreGround != null)
                win.Draw(foreGround);
        }
    }
}
