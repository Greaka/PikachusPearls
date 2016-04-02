using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using System.Drawing;
using System.Globalization;
using PikachusPearls.Code.GameStates.IngameElements;
using PikachusPearls.Code.Utility;

namespace PikachusPearls.Code.GameStates
{
    public class Map
    {
        Tiles[,] map;
        int tileSize = 64;

        public static String water = "ff0000ff";
        public static String path = "ffff0000";
        public static String forest = "ff000000";
        public static String highGras = "ff00ff00";
        public static String gras = "ffffffff";

        public Vector2f MapSize
        {
            get
            {
                return new Vector2f(map.GetLength(0) * tileSize, map.GetLength(1) * tileSize);
            }
        }

        public bool IsWalkable(Vector2i v) => map[v.X, v.Y].getWalkable();

        public Map(Bitmap mask)
        {

            map = new Tiles[mask.Width, mask.Height];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (mask.GetPixel(i, j).Name == water)
                    {
                        //water_inner_bottom_left
                        if ((mask.GetPixel(i, j - 1).Name == water) && (mask.GetPixel(i - 1, j).Name == water) && (mask.GetPixel(i + 1, j).Name == water) && (mask.GetPixel(i - 1, j + 1).Name != water) && (mask.GetPixel(i, j + 1).Name == water))
                        {
                            map[i, j] = new Tiles(0, 3, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_inner_top_left
                        if ((mask.GetPixel(i - 1, j - 1).Name != water) && (mask.GetPixel(i, j - 1).Name == water) && (mask.GetPixel(i - 1, j).Name == water) && (mask.GetPixel(i + 1, j).Name == water) && (mask.GetPixel(i, j + 1).Name == water))
                        {
                            map[i, j] = new Tiles(0, 5, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_inner_bottom_right
                        if ((mask.GetPixel(i, j - 1).Name == water) && (mask.GetPixel(i - 1, j).Name == water) && (mask.GetPixel(i + 1, j).Name == water) && (mask.GetPixel(i, j + 1).Name == water) && (mask.GetPixel(i + 1, j + 1).Name != water))
                        {
                            map[i, j] = new Tiles(0, 4, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_inner_top_right
                        if ((mask.GetPixel(i, j - 1).Name == water) && (mask.GetPixel(i + 1, j - 1).Name != water) && (mask.GetPixel(i - 1, j).Name == water) && (mask.GetPixel(i + 1, j).Name == water) && (mask.GetPixel(i, j + 1).Name == water))
                        {
                            map[i, j] = new Tiles(0, 6, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_middle
                        if ((mask.GetPixel(i, j - 1).Name == water) && (mask.GetPixel(i - 1, j).Name == water) && (mask.GetPixel(i + 1, j).Name == water) && (mask.GetPixel(i, j + 1).Name == water))
                        {
                            map[i, j] = new Tiles(0, 8, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_bottom_left
                        if ((mask.GetPixel(i - 1, j).Name != water) && (mask.GetPixel(i, j + 1).Name != water))
                        {
                            map[i, j] = new Tiles(0, 1, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_bottom_right
                        if ((mask.GetPixel(i + 1, j).Name != water) && (mask.GetPixel(i, j + 1).Name != water))
                        {
                            map[i, j] = new Tiles(0, 2, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_top_left
                        if ((mask.GetPixel(i, j - 1).Name != water) && (mask.GetPixel(i - 1, j - 1).Name != water) && (mask.GetPixel(i - 1, j).Name != water))
                        {
                            map[i, j] = new Tiles(0, 11, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_top_right
                        if ((mask.GetPixel(i, j - 1).Name != water) && (mask.GetPixel(i + 1, j).Name != water))
                        {
                            map[i, j] = new Tiles(0, 12, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_bottom
                        if ((mask.GetPixel(i - 1, j).Name == water) && (mask.GetPixel(i + 1, j).Name == water) && (mask.GetPixel(i, j + 1).Name != water))
                        {
                            map[i, j] = new Tiles(0, 0, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_left
                        if ((mask.GetPixel(i, j - 1).Name == water) && (mask.GetPixel(i - 1, j).Name != water) && (mask.GetPixel(i, j + 1).Name == water))
                        {
                            map[i, j] = new Tiles(0, 7, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_right
                        if ((mask.GetPixel(i, j - 1).Name == water) && (mask.GetPixel(i + 1, j).Name != water) && (mask.GetPixel(i, j + 1).Name == water))
                        {
                            map[i, j] = new Tiles(0, 9, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //water_top
                        if ((mask.GetPixel(i, j - 1).Name != water) && (mask.GetPixel(i - 1, j).Name == water) && (mask.GetPixel(i + 1, j).Name == water))
                        {
                            map[i, j] = new Tiles(0, 10, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }
                    }

                    if (mask.GetPixel(i, j).Name == path)
                    {
                        //sand_bottom
                        if ((mask.GetPixel(i - 1, j).Name == path) && (mask.GetPixel(i + 1, j).Name == path) && (mask.GetPixel(i, j + 1).Name != path))
                        {
                            map[i, j] = new Tiles(1, 0, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //sand_bottomLeft
                        if ((mask.GetPixel(i - 1, j).Name != path) && (mask.GetPixel(i, j + 1).Name != path))
                        {
                            map[i, j] = new Tiles(1, 1, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //sand_bottomRight
                        if ((mask.GetPixel(i + 1, j).Name != path) && (mask.GetPixel(i, j + 1).Name != path))
                        {
                            map[i, j] = new Tiles(1, 2, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //sand_left
                        if ((mask.GetPixel(i, j - 1).Name == path) && (mask.GetPixel(i - 1, j).Name != path) && (mask.GetPixel(i, j + 1).Name == path))
                        {
                            map[i, j] = new Tiles(1, 3, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //sand_middle
                        if ((mask.GetPixel(i, j - 1).Name == path) && (mask.GetPixel(i - 1, j).Name == path) && (mask.GetPixel(i + 1, j).Name == path) && (mask.GetPixel(i, j + 1).Name == path))
                        {
                            map[i, j] = new Tiles(1, 4, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //sand_right
                        if ((mask.GetPixel(i, j - 1).Name == path) && (mask.GetPixel(i + 1, j).Name != path) && (mask.GetPixel(i, j + 1).Name == path))
                        {
                            map[i, j] = new Tiles(1, 5, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //sand_top
                        if ((mask.GetPixel(i, j - 1).Name != path) && (mask.GetPixel(i - 1, j).Name == path) && (mask.GetPixel(i + 1, j).Name == path))
                        {
                            map[i, j] = new Tiles(1, 6, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //sand_topLeft
                        if ((mask.GetPixel(i, j - 1).Name != path) && (mask.GetPixel(i - 1, j - 1).Name != path) && (mask.GetPixel(i - 1, j).Name != path))
                        {
                            map[i, j] = new Tiles(1, 7, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }

                        //sand_topRight
                        if ((mask.GetPixel(i, j - 1).Name != path) && (mask.GetPixel(i + 1, j).Name != path))
                        {
                            map[i, j] = new Tiles(1, 8, new Vector2f(i * tileSize, j * tileSize));
                            continue;
                        }
                    }

                    if (mask.GetPixel(i, j).Name == forest)
                    {
                        map[i, j] = new Tiles(2, 0, new Vector2f(i * tileSize, j * tileSize));
                        continue;
                    }

                    if (mask.GetPixel(i, j).Name == highGras)
                    {
                        map[i, j] = new Tiles(3, 0, new Vector2f(i * tileSize, j * tileSize));
                        continue;
                    }

                    if (mask.GetPixel(i, j).Name == gras)
                    {
                        map[i, j] = new Tiles(4, 0, new Vector2f(i * tileSize, j * tileSize));
                        continue;
                    }

                    Console.WriteLine("x: " + i + ", y: " + j + "Color: " + mask.GetPixel(i, j));
                }
            }
        }

        public void Draw(RenderWindow window, Sprite player)
        {
            //Vector2f viewCenter = window.GetView().Center;



            //int viewLeft = (int)(window.GetView().Size.X / 128 + 2);
            //int viewBottom = (int)(window.GetView().Size.Y / 128 + 2);

            //int startLeft = Math.Max(0, (int)(viewCenter.X / 64) - viewLeft);
            //int endRight = Math.Min((int)(viewCenter.X / 64) + viewLeft, map.GetLength(0) - 1);

            //int top = Math.Max(0, (int)(viewCenter.Y / 64) - viewBottom);
            //int bottom = Math.Min((int)(viewCenter.Y / 64 + viewBottom), map.GetLength(1) - 1);

            //for (int i = startLeft; i < endRight; i++)
            //{
            //    for (int j = top; j < bottom; j++)
            //    {
            //        if (map[i, j] != null)
            //            map[i, j].Draw(window);



            //        if (map[i, j] != null)
            //            map[i, j].DrawForeGround(window);
            //    }
            //}

            foreach (Tiles t in map)
                t.Draw(window);

            window.Draw(player);
        }

    }
}
