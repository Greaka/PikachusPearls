using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.GameStates
{
    class Map
    {
        Tiles[,] map;
        int tileSize = 64;

        public Vector2f MapSize
        {
            get
            {
                return new Vector2f(map.GetLength(0) * tileSize, map.GetLength(1) * tileSize);
            }
        }

        public Map()
        {
            map = new Tiles[256, 256];

            for (int i=0; i<map.GetLength(0); i++)
            {
                for(int j=0; i<map.GetLength(1); j++)
                {

                }
            }
        }
    }
}
