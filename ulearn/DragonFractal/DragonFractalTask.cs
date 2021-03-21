using System;
using System.Drawing;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        public static double TransformX(double x, double y, double angle)
        {
            return (x * Math.Cos(angle) - y * Math.Sin(angle)) / Math.Sqrt(2);
        }

        public static double TransformY(double x, double y, double angle)
        {
            return (x * Math.Sin(angle) + y * Math.Cos(angle)) / Math.Sqrt(2);
        }

        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            var x = 1.0;
            var y = 0.0;
            var initRandom = new Random(seed);

            for (int i = 0; i < iterationsCount; ++i)
            {
                var x_temp = x;
                if (initRandom.Next(2) == 0)
                {
                    x = TransformX(x, y, Math.PI / 4);
                    y = TransformY(x_temp, y, Math.PI / 4);
                }
                else
                {
                    x = TransformX(x, y, Math.PI * 3 / 4) + 1;
                    y = TransformY(x_temp, y, Math.PI * 3 / 4);
                }
                pixels.SetPixel(x, y);
            }
        }
    }
}