using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace PikachusPearls.Code.Utility
{
    class Helper
    {
        public static float RadianToDegree = 180F / (float)Math.PI;
        public static float DegreeToRadian = (float)Math.PI / 180F;

        public static float PI = (float)Math.PI;

        public static float Lerp(float from, float to, float t)
        {
            return (1F - t) * from + t * to;
        }
        public static float LerpClamp(float from, float to, float t)
        {
            return Lerp(from, to, Clamp(t, 0F, 1F));
        }

        public static float Median(List<int> array)
        {
            float median = 0;
            for (int i = 0; i < array.Count; i++)
            {
                median += array[i];
            }
            return median/array.Count;
        }

        public static Color Lerp(Color from, Color to, float t)
        {
            Color res;
            res.R = (byte)((1F - t) * from.R + t * to.R);
            res.G = (byte)((1F - t) * from.G + t * to.G);
            res.B = (byte)((1F - t) * from.B + t * to.B);
            res.A = (byte)((1F - t) * from.A + t * to.A);
            return res;
        }
        public static Color LerpClamp(Color from, Color to, float t)
        {
            return Lerp(from, to, Clamp(t, 0F, 1F));
        }

        public static float Clamp(float f, float min, float max)
        {
            if (f < min)
                return min;
            else if (f > max)
                return max;
            else
                return f;
        }
    }
}
