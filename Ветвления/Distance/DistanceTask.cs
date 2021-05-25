using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			var a = Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
			var b = Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));
			var c = Math.Sqrt((bx - ax) * (bx - ax) + (by - ay) * (by - ay));

			if (c == 0)
				return a;

			if (Math.Round(a + b,3) == Math.Round(c,3))
				return 0;

			if (CheckForObtuseAngle(a, b, c))
				return a > b ? b : a;

			return Math.Abs((by - ay) * x - (bx - ax) * y + bx * ay - by*ax) 
							 / Math.Sqrt((by - ay) * (by - ay) + (bx - ax) * (bx - ax));
		}

		private static bool CheckForObtuseAngle(double a, double b, double c)
        {
			if (a > b && a > c)
				return a * a > b * b + c * c;
			if (b > a && b > c)
				return b * b > a * a + c * c;
			return false;
        }
	}
}