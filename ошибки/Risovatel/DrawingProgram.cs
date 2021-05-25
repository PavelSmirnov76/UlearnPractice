using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Drawing
    {
        static float x, y;
        static Graphics graphics;

        public static void InitializeGraphics( Graphics newGraphics )
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0; y = y0;
        }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            //Делает шаг длиной length в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle)); 
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        private const float HeightMulti = 0.375f;
        private const float WidthMulti = 0.04f;

        public static void Draw(int width, int height, double angePivot, Graphics graplics)
        {
            Drawing.InitializeGraphics(graplics);
            var resolution = Math.Min(width, height);
            var diagonalLength = Math.Sqrt(2) *
                                 (resolution * HeightMulti + resolution * WidthMulti) / 2;
            Drawing.SetPosition((float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f,
                                (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f);
            //Рисуем 1-ую сторону
            DrawFirstSide(resolution);
            ChangePan(resolution, -Math.PI, 3 * Math.PI / 4);
            //Рисуем 2-ую сторону
            DrawSecondSide(resolution);
            ChangePan(resolution, -Math.PI / 2 - Math.PI, -Math.PI / 2 + 3 * Math.PI / 4);
            //Рисуем 3-ю сторону
            DrawThirdSide(resolution);
            ChangePan(resolution, Math.PI - Math.PI, Math.PI + 3 * Math.PI / 4);
            //Рисуем 4-ую сторону
            DrawFourthSide(resolution);
            ChangePan(resolution, Math.PI / 2 - Math.PI, Math.PI / 2 + 3 * Math.PI / 4);
        }

        private static void ChangePan(int resolution, double firstAnge, double secondAngle)
        {
            Drawing.Change(resolution * WidthMulti, firstAnge);
            Drawing.Change(resolution * WidthMulti * Math.Sqrt(2), secondAngle);
        }

        private static void DrawFourthSide(int resolution)
        {
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti, Math.PI / 2);
            Drawing.MakeIt(Pens.Yellow, resolution * WidthMulti * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti, Math.PI / 2 + Math.PI);
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti - resolution * WidthMulti, Math.PI / 2 + Math.PI / 2);
        }

        private static void DrawThirdSide(int resolution)
        {
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti, Math.PI);
            Drawing.MakeIt(Pens.Yellow, resolution * WidthMulti * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti, Math.PI + Math.PI);
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti - resolution * WidthMulti, Math.PI + Math.PI / 2);
        }

        private static void DrawFirstSide(int resolution)
        {
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti, 0);
            Drawing.MakeIt(Pens.Yellow, resolution * WidthMulti * Math.Sqrt(2), Math.PI / 4);
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti, Math.PI);
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti - resolution * WidthMulti, Math.PI / 2);
        }

        private static void DrawSecondSide(int resolution)
        {
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti, -Math.PI / 2);
            Drawing.MakeIt(Pens.Yellow, resolution * WidthMulti * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti, -Math.PI / 2 + Math.PI);
            Drawing.MakeIt(Pens.Yellow, resolution * HeightMulti - resolution * WidthMulti, -Math.PI / 2 + Math.PI / 2);
        }
    }
}