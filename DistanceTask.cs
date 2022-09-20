using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			double distAB = Math.Abs(Math.Sqrt(Math.Pow(bx - ax, 2) + Math.Pow(by - ay, 2)));
			double distAX = Math.Abs(Math.Sqrt(Math.Pow(x - ax, 2) + Math.Pow(y - ay, 2)));
			double distBX = Math.Abs(Math.Sqrt(Math.Pow(x - bx, 2) + Math.Pow(y - by, 2)));
			double distXA = Math.Abs(Math.Sqrt(Math.Pow(ax - x, 2) + Math.Pow(ay - y, 2)));
			double distXB = Math.Abs(Math.Sqrt(Math.Pow(bx - x, 2) + Math.Pow(by - y, 2)));

			if (x > ax && x < bx && y == ay && y == by) return 0.00;

			if (distAB == 0 || x == ax || y == ay) return distXA;
			
			if (x == bx || y == ay || x > bx) return distXB;
			
			
			
			if ((Math.Pow(distAX , 2) > Math.Pow(distBX , 2) + Math.Pow(distAB, 2)) || (Math.Pow(distBX, 2) > Math.Pow(distAX, 2) + Math.Pow(distAB, 2)))
            {
				return Math.Min(distAX, distBX);
            }
			
			else
			{
				//double productAxAb = (x - ax) * (bx - ax) - (y - ay) * (by - ay);
				//double productBaBx = (ax - bx) * (x - bx) - (ay - by) * (y - by);

				//double angleXab = Math.Acos(productAxAb / (distAX * distAB));
				//double angleXba = Math.Acos(productBaBx / (distBX * distAB));

				//double square = distAB * distAX * Math.Sin(angleXab) * 0.5;
				double halfPerimetr = (distAB + distAX + distBX) * 0.5;
				double square = Math.Sqrt(halfPerimetr * (halfPerimetr - distAB) * (halfPerimetr - distAX) * (halfPerimetr * distBX));

				return square / distAB * 0.5;
			}
		}
	}
}
