using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikachusPearls.Code.GameStates.IngameElements
{
    public abstract class Pearlmon
    {
        public string SpeciesName { get; protected set; }
        public string Name { get; protected set; }

        public float MaxHp { get; protected set; }
        public float CurrentHp { get; protected set; }
        public float Attack { get; protected set; }
        public float Defense { get; protected set; }
        public float Speed { get; protected set; }
        public uint Lvl { get; protected set; }
        public uint Exp { get; protected set; }

        public Typing Typing { get; protected set; }

        Sprite sprite;

        protected void Rename(string newName)
        {
            Name = newName;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}
