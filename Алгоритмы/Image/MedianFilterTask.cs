using System;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		/* 
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
		public static double[,] MedianFilter(double[,] original)
		{
			var xLength = original.GetLength(0);
			var yLength = original.GetLength(1);
			var median = new double[xLength, yLength];
			if (xLength + yLength != 2)
			{
				if (xLength == 1 || yLength == 1)
					FillVector(median, original);
				else
				{
					FillCenter(median, original);
					FillAngle(median, original);
					FillЦindow(median, original);
				}
			}
			else
				return original;

			return median;	
		}

		private static void FillVector(double[,] median, double[,] original)
        {
			var xLength = original.GetLength(0);
			var yLength = original.GetLength(1);
			

			if (xLength == 1)
			{
				median[0, 0] = (original[0, 0] + original[0, 1]) / 2;
				median[0, yLength - 1] = (original[0, yLength - 2] + original[0, yLength - 1]) / 2;
				for (int y = 1; y < yLength - 1; y++)
					median[0, y] = GetMedian(new[] { original[0, y - 1], original[0, y], original[0, y + 1] });
			}
            else
            {
				median[0, 0] = (original[0, 0] + original[1, 0]) / 2;
				median[xLength - 1, 0] = (original[xLength - 2, 0] + original[xLength - 1, 0]) / 2;
				for (int x = 1; x < xLength - 1; x++)
					median[x, 0] = GetMedian(new[] { original[x - 1, 0], original[x, 0], original[x + 1, 0] });
			}
        }

		private static double GetMedian(double[] original)
        {
			Array.Sort(original);
			if (original.Length%2 == 1)
				return original[original.Length / 2];
			else
				return (original[original.Length / 2] + original[original.Length / 2 - 1]) / 2;
		}

		private static void FillCenter(double[,] median, double[,] original)
        {
			var xLength = original.GetLength(0);
			var yLength = original.GetLength(1);
			for (int x = 1; x < xLength - 1; x++)
				for(int y = 1; y < yLength - 1; y++)
					median[x, y] = GetMedian(new []{original[x - 1, y - 1], original[x - 1, y], original[x - 1, y + 1],
														  original[x    , y - 1], original[x    , y], original[x    , y + 1],
														  original[x + 1, y - 1], original[x + 1, y], original[x + 1, y + 1] });
        }

		private static void FillAngle(double[,] median, double[,] original)
        {
			var xLength = original.GetLength(0);
			var yLength = original.GetLength(1);

			median[0, 0] = GetMedian(FillAngleMedanArray(original, 0, 0));
			median[0, yLength -1] = GetMedian(FillAngleMedanArray(original, 0, yLength - 2));			
			median[xLength - 1, 0] = GetMedian(FillAngleMedanArray(original, xLength - 2, 0));
			median[xLength - 1, yLength - 1] = GetMedian(FillAngleMedanArray(original, xLength - 2, yLength - 2));
		}

		private static void FillЦindow(double[,] median, double[,] original)
        {
			var xLength = original.GetLength(0);
			var yLength = original.GetLength(1);

			for (int y = 1; y < yLength - 1; y++)
			{
				median[0, y] = GetMedian(FillVerticalBordMedianArray(original, 0, y));
				median[xLength - 1, y] = GetMedian(FillVerticalBordMedianArray(original, xLength - 2, y));
			}
			for (int x = 1; x < xLength - 1; x++)
			{
				median[x, 0] = GetMedian(FillHorizontalBordMedianArray(original, x, 0));
				median[x, yLength - 1] = GetMedian(FillHorizontalBordMedianArray(original, x, yLength - 2));
			}
        }

		private static double[] FillHorizontalBordMedianArray(double[,] original, int x, int y)
        {
			return new[]{ original[x - 1, y], original[x - 1, y + 1],
						 original[x    , y], original[x    , y + 1],
						 original[x + 1, y], original[x + 1, y + 1] };
		}

		private static double[] FillVerticalBordMedianArray(double[,] original, int x, int y)
        {
			return new[]{ original[x    , y - 1], original[x   , y], original[x    , y + 1], 
				         original[x + 1, y -1], original[x + 1, y], original[x + 1, y + 1] };
		}

		private static double[] FillAngleMedanArray(double[,] original, int x, int y)
		{
			return new[]{ original[x    , y], original[x    , y + 1], 
				         original[x + 1, y], original[x + 1, y + 1]};
		}
	}
}