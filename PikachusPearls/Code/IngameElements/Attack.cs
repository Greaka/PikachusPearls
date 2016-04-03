using SFML.Graphics;
using SFML.Window;

namespace PikachusPearls.Code.IngameElements
{
    public abstract class Attack
    {
        public string Name { get; protected set; }
        public int Strength { get; protected set; }
        public Typing.Type Type { get; protected set; }
        Text text;

        public void Dispose()
        {
            if (text != null)
                text.Dispose();
        }

        public void Draw(RenderWindow win, Vector2f Position, bool selected)
        {
            if(text == null)
            {
                text = new Text(Name, Program.Font, 50);
            }
            text.Position = Position;
            text.Color = (selected) ? (Color.Red) : (Color.Black);

            win.Draw(text);
        }
    }

    public class Bite : Attack
    {
        public Bite()
        {
            Name = "Bite";
            Strength = 40;
            Type = Typing.Type.Strength;
        }
    }

    public class Headbutt : Attack
    {
        public Headbutt()
        {
            Name = "Headbutt";
            Strength = 60;
            Type = Typing.Type.Strength;
        }
    }

    public class Scratch : Attack
    {
        public Scratch()
        {
            Name = "Scratch";
            Strength = 45;
            Type = Typing.Type.Normal;
        }
    }

    public class Bureaucracy : Attack
    {
        public Bureaucracy()
        {
            Name = "Bureaucracy";
            Strength = 120;
            Type = Typing.Type.Intelligence;
        }
    }

    public class PayDay : Attack
    {
        public PayDay()
        {
            Name = "Pay Day";
            Strength = 55;
            Type = Typing.Type.Intelligence;
        }
    }

    public class BeOrNotToBe : Attack
    {
        public BeOrNotToBe()
        {
            Name = "BeOrNotToBe";
            Strength = 60;
            Type = Typing.Type.Charisma;
        }
    }

    public class SwordCut : Attack
    {
        public SwordCut()
        {
            Name = "Sword Cut";
            Strength = 65;
            Type = Typing.Type.Strength;
        }
    }

    public class RazorWind : Attack
    {
        public RazorWind()
        {
            Name = "Razor Wind";
            Strength = 80;
            Type = Typing.Type.Strength;
        }
    }

    public class Trick : Attack
    {
        public Trick()
        {
            Name = "Trick";
            Strength = 40;
            Type = Typing.Type.Intelligence;
        }
    }

    public class RomeoAndJuliet : Attack
    {
        public RomeoAndJuliet()
        {
            Name = "Romeo And Juliet";
            Strength = 90;
            Type = Typing.Type.Charisma;
        }
    }

    public class RockTomb : Attack
    {
        public RockTomb()
        {
            Name = "Rock Tomb";
            Strength = 70;
            Type = Typing.Type.Strength;
        }
    }

    public class RockSlide : Attack
    {
        public RockSlide()
        {
            Name = "Rock Slide";
            Strength = 65;
            Type = Typing.Type.Normal;
        }
    }

    public class SkullThrow : Attack
    {
        public SkullThrow()
        {
            Name = "Skull Throw";
            Strength = 40;
            Type = Typing.Type.Normal;
        }
    }
}
