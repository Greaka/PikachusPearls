using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikachusPearls.Code.GameStates.IngameElements
{
    class Knight : Pearlmon
    {
        public Knight(uint level)
        {
            sprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.KnightFront));
            SpeciesName = "Knight";
            MaxHp = 100;
            CurrentHp = MaxHp;
            Attack = 10;
            Defense = 10;
            Speed = 10;
            Lvl = level;
            Exp = 10;
            Typing = new Typing(Typing.Type.Strength);
            Attacks[0] = new Headbutt();
            Attacks[1] = new Scratch();
            Attacks[2] = new Bite();
            CountOfKnownAttacks = 3;
        }
    }
}
