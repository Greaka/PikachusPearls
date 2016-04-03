using System;
using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.IngameElements
{
    public enum Existing_Pearlmon
    {
        None = -1,

        T_Rex,
        Knight,
        Steuerberater,
        Shakespeare,
        Triops,

        Count
    }


    public abstract class Pearlmon
    {
        public string SpeciesName { get; protected set; }
        public string Name { get; protected set; }

        public float MaxHp { get; protected set; }

        private float _currentHp;
        public float CurrentHp
        {
            get { return _currentHp; }
            protected set
            {
                _currentHp = value;
                HpBar_Current.Scale = new Vector2f((2 + (HpBar_Current.TextureRect.Width - 4) * CurrentHp / MaxHp) / HpBar_Current.TextureRect.Width, 1);
            }
        }

        public float Attack { get; protected set; }
        public float Defense { get; protected set; }
        public float Speed { get; protected set; }
        public uint Lvl { get; protected set; }
        public uint Exp { get; protected set; }
        public int CountOfKnownAttacks { get; protected set; }
        public Typing Typing { get; protected set; }
        protected Attack[] Attacks = new Attack[4];
        protected Sprite sprite;

        public Sprite HpBar_Base { get; protected set; }
        public Sprite HpBar_Current { get; protected set; }

        public Pearlmon(uint level)
        {
            Lvl = level;
            HpBar_Base = new Sprite(AssetManager.getTexture(AssetManager.TextureName.Hp_Base));
            HpBar_Current = new Sprite(AssetManager.getTexture(AssetManager.TextureName.Hp_Current));
        }

        public void Dispose()
        {
            foreach (Attack a in Attacks)
                if (a != null)
                    a.Dispose();
            Attacks = null;
            sprite.Dispose();
            HpBar_Current.Dispose();
            HpBar_Base.Dispose();
        }

        public Attack GetRandomAttack()
        {
            Random rand = new Random();
            return Attacks[rand.Next(0, CountOfKnownAttacks)];
        }

        public Attack GetAttack(int index)
        {
            return Attacks[index];
        }

        public Sprite GetSprite()
        {
            return sprite;
        }

        public void BeAttackedByWith(Pearlmon opponent, Attack attack)
        {
            float dmg = Math.Max(1, ((opponent.Typing.Contains(attack.Type)) ? (1.5f) : (1)) * opponent.Attack * ((float)attack.Strength/100f) - Defense);
            float effectivness = Typing.GetEffectivness(attack.Type);

            CurrentHp -= dmg * effectivness;
        }

        protected void Rename(string newName)
        {
            Name = newName;
        }

        public float StatCalculation(float stat)
        {
            return 2 * stat * Lvl / 100 + 5;
        }

        public float HpCalculation(float Hp)
        {
            return (2 * Hp + 100) * Lvl / 100 + 10;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
            win.Draw(HpBar_Base);
            win.Draw(HpBar_Current);
        }
    }

   

    class T_Rex : Pearlmon
    {
        public T_Rex(uint level) : base(level)
        {
            sprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.TRexFront));
            SpeciesName = "T-Rex";
            MaxHp = HpCalculation(82);
            CurrentHp = MaxHp;
            Attack = StatCalculation(121);
            Defense = StatCalculation(119);
            Speed = StatCalculation(71);
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
        public Knight(uint level) : base(level)
        {
            sprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.KnightFront));
            SpeciesName = "Knight";
            MaxHp = HpCalculation(76);
            CurrentHp = MaxHp;
            Attack = StatCalculation(113);
            Defense = StatCalculation(106);
            Speed = StatCalculation(95);
            Exp = 10;
            Typing = new Typing(Typing.Type.Strength);
            Attacks[0] = new Headbutt();
            Attacks[1] = new RazorWind();
            Attacks[2] = new SwordCut();
            CountOfKnownAttacks = 3;
        }
    }

    class Shakespeare : Pearlmon
    {
        public Shakespeare(uint level) : base(level)
        {
            sprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.ShakespeareFront));
            SpeciesName = "Shakespeare";
            MaxHp = HpCalculation(62);
            CurrentHp = MaxHp;
            Attack = StatCalculation(103);
            Defense = StatCalculation(86);
            Speed = StatCalculation(135);
            Exp = 10;
            Typing = new Typing(Typing.Type.Charisma);
            Attacks[0] = new BeOrNotToBe();
            Attacks[1] = new RomeoAndJuliet();
            Attacks[2] = new SkullThrow();
            CountOfKnownAttacks = 3;
        }
    }

    class Steuerberater : Pearlmon
    {
        public Steuerberater(uint level) : base(level)
        {
            sprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.SteuerberaterFront));
            SpeciesName = "Steuerberater";
            MaxHp = HpCalculation(74);
            CurrentHp = MaxHp;
            Attack = StatCalculation(96);
            Defense = StatCalculation(111);
            Speed = StatCalculation(124);
            Exp = 10;
            Typing = new Typing(Typing.Type.Intelligence);
            Attacks[0] = new PayDay();
            Attacks[1] = new Trick();
            Attacks[2] = new Bureaucracy();
            CountOfKnownAttacks = 3;
        }
    }

    class Triops : Pearlmon
    {
        public Triops(uint level) : base(level)
        {
            sprite = new Sprite(AssetManager.getTexture(AssetManager.TextureName.TriopsFront));
            SpeciesName = "Triops";
            MaxHp = HpCalculation(74);
            CurrentHp = MaxHp;
            Attack = StatCalculation(134);
            Defense = StatCalculation(165);
            Speed = StatCalculation(74);
            Exp = 10;
            Typing = new Typing(Typing.Type.Normal);
            Attacks[0] = new RockTomb();
            Attacks[1] = new RockSlide();
            Attacks[2] = new Bite();
            CountOfKnownAttacks = 3;
        }
    }
}
