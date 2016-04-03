using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikachusPearls.Code.GameStates.IngameElements
{
    public class Typing
    {
        public enum Type
        {
            None = -1,

            Normal,

            Intelligence,
            Strength,
            Charisma,

            Count
        }

        static float[,] Effectiveness =  
            { 
            //      Nrm, Int, Str, Cha
            /*Nrm*/{1  , 1  , 1  , 1  },
            /*Int*/{1  , 1  ,0.5f, 2  },
            /*Str*/{1  , 2  , 1  ,0.5f},
            /*Cha*/{1  ,0.5f, 2  , 1  }
            };

        Type type1;
        Type type2;

        public bool Contains(Type t)
        {
            return type1 == t || type2 == t;
        }

        public Typing() : this(Type.Normal) { }

        public Typing(Type type) : this(type, Type.None) { }

        public Typing(Type type1, Type type2)
        {
            this.type1 = type1;
            this.type2 = type2;
        }

        public float GetEffectivness(Type AttackType)
        {
            float effectivnessType1 = Effectiveness[(int)AttackType, (int)type1];
            float effectivnessType2 = (type2 != Type.None) ? (Effectiveness[(int)AttackType, (int)type2]) : (1);

            return effectivnessType1 * effectivnessType2;
        }
    }
}
