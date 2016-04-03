using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikachusPearls.Code.GameStates.IngameElements
{
    public enum Existing_Pearlmon
    {
        None = -1,

        T_Rex,
        Knight,

        Count
    }


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

        public void BeAttackedByWith(Pearlmon opponent, Attack attack)
        {
            float dmg = ((opponent.Typing.Contains(attack.Type)) ? (1.5f) : (1)) * opponent.Attack * attack.Strength - Defense;
            float effectivness = Typing.GetEffectivness(attack.Type);

            CurrentHp -= dmg * effectivness;
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

    class T_Rex : Pearlmon
    {
        public T_Rex(uint level)
        {
            sprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.TRexFront));
            SpeciesName = "T-Rex";
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
