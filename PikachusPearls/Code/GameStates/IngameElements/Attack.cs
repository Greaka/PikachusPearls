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
    }
}
