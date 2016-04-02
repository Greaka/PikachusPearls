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
        public int CountOfKnownAttacks { get; protected set; }
        public Typing Typing { get; protected set; }
        protected Attack[] Attacks = new Attack[4];
        protected Sprite sprite;

        public Attack GetRandomAttack()
        {
            Random rand = new Random();
            return Attacks[rand.Next(0, CountOfKnownAttacks)];
        }

        public Attack GetAttack(int index)
        {
            return Attacks[index];
        }

        public void BeAttackedByWith(Attack attack, Pearlmon opponent)
        {

        }

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
