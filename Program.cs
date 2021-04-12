using System;

namespace Minefield
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask user to enter the number of people paaing through the area
                Console.Write("How many people will be passing through the area? ");
                double numberOfPeople = double.Parse(Console.ReadLine());
                    while (numberOfPeople < 0)
                    {
                        Console.WriteLine("Please re-enter a positive number: ");
                        numberOfPeople = int.Parse(Console.ReadLine());
                    }

            //aquire data from satellite
                bool [,] array = GetSatelliteData();
            
            //get total count for number of land mines in the area
                double numberOfMines = LandmineCount(array);
            
            //determine whether or not it is safe to pass through the area
                bool safeToPass = SafeToPass(array, numberOfPeople);

            //display output to console
            if (safeToPass == true)
            {
                Console.WriteLine("There are {0} landmines in the area.", numberOfMines);
                Console.WriteLine("It is safe to pass.");
            }
            else
            {
                Console.WriteLine("There are {0} landmines in the area.", numberOfMines);
                Console.WriteLine("It is not safe to pass.");
            }
        }//end main        

        #region GetSatelliteData
        static bool [,] GetSatelliteData()
        {
            Random rand = new Random();
            bool [,] data = new bool[1000,1000];
            int threshold = rand.Next(5, 96);
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    data[x, y] = rand.Next(1, 101) < threshold;
                }
            }
            return data;
        }
        #endregion

        #region LandmineCount
        static double LandmineCount(bool [,] graph)
        {
            int num = 0;
            for (int x = 0; x < graph.GetLength(0); x++)
            {
                for (int y = 0; y < graph.GetLength(1); y++)
                {
                    if (graph[x, y] == true) num++;
                }
            }
            return num;
        }
        #endregion

        #region SafeToPass
        static bool SafeToPass(bool [,] graph, double personCount)
        {
            int landmineCount = 0;
            for (int x = 0; x < graph.GetLength(0); x++)
            {
                for (int y = 0; y < graph.GetLength(1); y++)
                {
                    if (graph[x, y] == true) landmineCount++;
                }
            }

            if (personCount / landmineCount <= .05)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
