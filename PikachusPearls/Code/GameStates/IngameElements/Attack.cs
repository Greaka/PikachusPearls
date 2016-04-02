using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikachusPearls.Code.GameStates.IngameElements
{
    public abstract class Attack
    {
        public string Name { get; protected set; }
        public int Strength { get; protected set; }
        public Typing.Type Type { get; protected set; }
        Text text;

        public void Draw(RenderWindow win, Vector2f Position, bool selected)
        {
            if(text == null)
            {
                text = new Text(Name, Program.Font, 20);
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
            Strength = 15;
            Type = Typing.Type.Strength;
        }
    }

    public class Headbutt : Attack
    {
        public Headbutt()
        {
            Name = "Headbutt";
            Strength = 15;
            Type = Typing.Type.Strength;
        }
    }

    public class Scratch : Attack
    {
        public Scratch()
        {
            Name = "Scratch";
            Strength = 15;
            Type = Typing.Type.Normal;
        }
    }

}
