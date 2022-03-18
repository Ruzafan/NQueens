//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Queens
//{
//    internal class Helpers
//    {

//        (List<Point>, List<int>, List<int>) GetOccupiedEspaces(int[,] matrix)
//        {
//            List<Point> points = new List<Point>();
//            var x = new List<int>();
//            var y = new List<int>();
//            var z1 = new List<int>();
//            var z2 = new List<int>();
//            for (int i = 1; i < n + 1; i++)
//            {
//                for (int a = 1; a < n + 1; a++)
//                {
//                    if (matrix[i - 1, a - 1] != 0)
//                    {
//                        points.Add(new Point(i, a));
//                        z1.Add(i + a);
//                        z2.Add(i - a);
//                    }
//                }
//            }
//            return (points, z1, z2);
//        }

//        (int, int) GetRandomFreeSpot(int[,] matrix)
//        {
//            var (points, oocZ1, oocZ2) = GetOccupiedEspaces(matrix);
//            var x = GetRandom(n, points.Select(q => q.X).ToList());
//            var y = GetRandom(n, points.Select(q => q.Y).ToList());
//            var retires = 0;
//            while ((oocZ1.Contains(x + y) || oocZ2.Contains(x - y)) && retires < 1000)
//            {
//                x = GetRandom(n, points.Select(q => q.X).ToList());
//                y = GetRandom(n, points.Select(q => q.Y).ToList());
//                retires++;
//            }
//            return (x - 1, y - 1);
//        }

//        int GetRandom(int max, List<int> avoid)
//        {
//            if (avoid.Count >= max) return -1;
//            Random random = new Random();
//            var next = random.Next(max) + 1;
//            while (avoid.Contains(next))
//            {
//                next = random.Next(max);
//            }
//            return next;
//        }
//    }
//}
