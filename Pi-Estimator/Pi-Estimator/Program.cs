using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

//ESTIMATE PI

namespace RandomStuffs
{
    internal class Program
    {
        public static class PiEstimator
        {
            public static double EstimatePi(int iterations)
            {
                // Validate input
                if (iterations <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(iterations), "Number of iterations must be positive.");
                }

                int insideCircle = 0;
                Random random = new Random();

                for (int i = 0; i < iterations; i++)
                {
                    // Generate random points within a square with side length 1
                    double x = random.NextDouble();
                    double y = random.NextDouble();

                    // Check if the point falls inside the inscribed circle (radius = 0.5)
                    if (Math.Pow(x - 0.5, 2) + Math.Pow(y - 0.5, 2) <= 0.25)
                    {
                        insideCircle++;
                    }
                }

                // Estimate pi based on the ratio of points inside the circle to total points
                return 4.0 * ((double)insideCircle / iterations);
            }
        }

        public static void Main(string[] args)
        {
            //Creating a loop
            bool running = true;        
            while (running)

            {

                Console.Write("Enter the number of iterations: ");
                int iterations = Convert.ToInt32(Console.ReadLine());

                try
                {
                    double estimatedPi = PiEstimator.EstimatePi(iterations);
                    Console.WriteLine("Estimated pi value: {0:0.0000}", estimatedPi);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }

            }
        }
    }
}
