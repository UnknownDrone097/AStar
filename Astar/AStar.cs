using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class AStar
    {
        //Hardcoded for 2d for my ease of creation
        int Length;
        int Width;
        public int[,] Obstacles;
        Dictionary<int[], int> Open;
        Dictionary<int[], int> Closed;
        Dictionary<int[], int[]> Path;
        public static int WallShade = 0;
        public static int PathShade = 255;

        public void Scaler(int xmax, int ymax)
        {
            int scale = Length > Width ? xmax / Length : ymax / Width;
            int[,] scaled = new int[Length * scale, Width * scale];
            //Foreach int in Obstacles
            for (int j = 0; j < Length; j++)
            {
                for (int jj = 0; jj < Width; jj++)
                {
                    //Scale by scale
                    for (int i = 0; i < scale; i++)
                    {
                        for (int ii = 0; ii < scale; ii++)
                        {
                            scaled[(j * scale) + i, (jj * scale) + ii] = Obstacles[j, jj];
                        }
                    }
                }
            }

            Obstacles = scaled;
        }
        public AStar(int l, int w, int[] start, int[] end)
        {
            ArrayCompare ac = new ArrayCompare();
            Length = l; Width = w; Open = new Dictionary<int[], int>(ac); Closed = new Dictionary<int[], int>(ac);
            Path = new Dictionary<int[], int[]>(ac);
        }

        public int[,] GenerateMaze(int l, int w, int[] start, int[] end, double density)
        {
            //Need to generate a maze
            int[,] tempObstacles = new int[l, w];
            Random r = new Random();
            for (int i = 0; i < l; i++)
            {
                for (int ii = 0; ii < w; ii++)
                {
                    double random = r.NextDouble();
                    if (random > density) { tempObstacles[i, ii] = WallShade; }
                    else { tempObstacles[i, ii] = PathShade; }
                }
            }
            tempObstacles[end[0], end[1]] = PathShade;
            return tempObstacles;
        }

        private List<int[]> Reconstruct(int[] goal)
        {
            List<int[]> path = new List<int[]>();
            int[] current = goal;
            path.Add(current);
            while (true)
            {
                try
                {
                    current = Path[current];
                }
                catch (Exception ex) { break; }
                path.Add(current);
            }
            return path;
        }
        private int CalcDist(int[] start, int[] end)
        {
            //Need to implement Map
            return (int)(Math.Sqrt(Math.Pow(start[0] - end[0], 2) + Math.Pow(start[1] - end[1], 2)));
        }
        //This needs to use an actual maze..?
        public List<int[]> Algorithm(int[] start, int[] end)
        {
            int[] current = start;
            Open.Add(start, 0);
            while (Open.Count > 0)
            {
                //Set current to lowest value in open
                int currentcost = int.MaxValue;
                foreach (KeyValuePair<int[], int> kvp in Open)
                {
                    if (kvp.Value < currentcost) { current = kvp.Key; currentcost = kvp.Value; }
                }
                if (!Closed.ContainsKey(current)) { Closed.Add(current, currentcost); }
                Open.Remove(current);

                //For neighbors of current
                for (int i = -1; i <= 1; i++)
                {
                    for (int ii = -1; ii <= 1; ii++)
                    {
                        //If it is the current node, ignore it
                        if (i == 0 && ii == 0) { continue; }
                        if (current[0] + i < Length && current[1] + ii < Width && current[0] + i >= 0 && current[1] + ii >= 0)
                        {
                            //If impassible, ignore it
                            if (Obstacles[current[0] + i, current[1] + ii] == WallShade) { continue; }

                            int[] neighbor = new int[2] { current[0] + i, current[1] + ii };
                            //Break if we reach the end
                            if (current[0] + i == end[0] && current[1] + ii == end[1])
                            {
                                Path.Add(neighbor, current);
                                return Reconstruct(end);
                            }

                            int tempcost = currentcost + CalcDist(current, neighbor);

                            if (Open.ContainsKey(neighbor) && tempcost < Open[neighbor])
                            { Open[neighbor] = tempcost; }

                            if (Closed.ContainsKey(neighbor) && tempcost < Closed[neighbor])
                            { Closed.Remove(neighbor); Open.Add(neighbor, tempcost); }

                            if (!Open.ContainsKey(neighbor) && !Closed.ContainsKey(neighbor))
                            {
                                Open.Add(neighbor, tempcost);
                                //Set neighbor's parent to current
                                if (Path.ContainsKey(neighbor)) { Path[neighbor] = current; }
                                else { Path.Add(neighbor, current); }
                            }
                        }
                    }
                }
            }
            return new List<int[]>();
            //throw new Exception("Did not find end");
        }
    }
    class ArrayCompare : IEqualityComparer<int[]>
    {
        public bool Equals(int[] i, int[] i2)
        {
            if (i is null || i2 is null) { return false; }
            if (i.Length != i2.Length) { return false; }
            for (int j = 0; j < i.Length; j++)
            {
                if (i[j] != i2[j]) { return false; }
            }
            return true;
        }

        //No idea what this does
        public int GetHashCode(int[] obj)
        {
            int hcode = 1;
            foreach (int i in obj) { hcode *= i; }
            return hcode.GetHashCode();
        }
    }
}
