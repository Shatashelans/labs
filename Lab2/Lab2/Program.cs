using System;

namespace Lab2
{
    class Vector
    {
        private float[] arr;                        // The vector we processing

        /// <summary>
        /// Constructor by default (if we have no parameters)
        /// </summary>
        public Vector()
        {
            arr = new float[0];                     // Initializes the vector (array) with the length equal to 0
        }

        /// <summary>
        /// Random constructor by the length
        /// </summary>
        /// <param name="size">The length of the random array</param>
        public Vector(int size)
        {
            arr = new float[size];                                  // Initialize the vector by its length (by parameter)
            Random random = new Random();                           // Using the random object
            for (int i = 0; i < arr.Length; i++)    
            {
                arr[i] = (float)(100 - random.NextDouble() * 200);  // creates numbers from -100 to 100
            }
        }

        /// <summary>
        /// The constructor by values
        /// </summary>
        /// <param name="x">The array we want to copy</param>
        public Vector(float[] x)
        {
            arr = new float[x.Length];                              // Initialize the length of the vector with the help of length of the input array we want to copy
            for (int i = 0; i < x.Length; i++)                      // Process of copying
            {                                                       // .
                arr[i] = x[i];                                      // .
            }                                                       // .
        }

        /// <summary>
        /// Changes positions of two negative numbers which are situated in succession
        /// </summary>
        public void ChangePositionOfNegativeNumbers()
        {
            int position = -1;                                      // By default we have a not existing position
            for (int i = 0; i < arr.Length; i++)
            {
                if (position == -1 && arr[i] < 0)                   // If it's the first number of the couple
                {                                                   // and it's lower than 0 (negative number)
                    position = i;                                   // then we remember this position,
                }
                else if (position != -1 && arr[i] < 0)              // else if we met the the second number of the couple
                {                                                   // and it's also negative
                    arr[i] += arr[position];                        // then perform replacing these values:
                    arr[position] = arr[i] - arr[position];         // .
                    arr[i] -= arr[position];                        // .
                    position = -1;                                  // And to find another couples we destroy the position of the first number from the couple
                }
            }
        }

        /// <summary>
        /// Searches for the maximum and the minimum value of the array
        /// </summary>
        /// <returns>The array, where the first number is the maximum value and the second one is the minimum</returns>
        public float[] FindMaxAndMin()
        {
            float[] maxMin = { 0, 0 };                              // Initializing the array of max and min values of the vector
            foreach (var number in arr)                             // Standart way to find the maximum and the minimum values:
            {
                if (number > maxMin[0])
                {
                    maxMin[0] = number;
                }
                else if (number < maxMin[1])
                {
                    maxMin[1] = number;
                }
            }
            return maxMin;
        }

        /// <summary>
        /// Searches for the position of the maximum and the minumum values in the array
        /// </summary>
        /// <param name="maxMin">The values of the maximum and the minimum in the current array</param>
        /// <returns>The array of positions of the maximum and the minimum of current array</returns>
        public int[] PositionOfMaxAndMin(float[] maxMin)
        {
            int[] mMPositions = { -1, -1 };                         // Initialize the position of minimum and maximum values (default positions are not existing)
            for (int i = 0; i < arr.Length; i++)                    // Standart way to perform searching
            {
                if (arr[i] == maxMin[0])
                {
                    mMPositions[0] = i + 1;                         // Adding 1 for the human visibility
                }
                else if (arr[i] == maxMin[1])
                {
                    mMPositions[1] = i + 1;                         // -||-
                }
            }
            return mMPositions;
        }

        /// <summary>
        /// Performs output and uses all fumction before except constructors
        /// </summary>
        public void Output()
        {
            Console.WriteLine("The primary array: ");
            foreach (var number in arr)                             // Loop outputting the values of the initial vector
            {
                Console.Write("{0}; ", number);
            }
            float[] maxMin = FindMaxAndMin();                       // Find values of max and min in the vector
            int[] positionMaxMin = PositionOfMaxAndMin(maxMin);     // and find the initial position of them
            Console.WriteLine("\n\rThe maximum and the minimum of this array:\n\rMAX: {0}[{1}], MIN: {2}[{3}]", maxMin[0], positionMaxMin[0], maxMin[1], positionMaxMin[1]);

            ChangePositionOfNegativeNumbers();                      // Perform the main changes in the program: replacing negative numbers by their couples
            Console.WriteLine("The new array: ");
            foreach (var number in arr)                             // Output the final vector
            {
                Console.Write("{0}; ", number);
            }
            Console.WriteLine();
            positionMaxMin = PositionOfMaxAndMin(maxMin);           // Find the final position of max and min in the vector
            Console.WriteLine("Positions of maximum and minumum in the new array are:\n\rMAX: {0}, MIN: {1}\n\r", positionMaxMin[0], positionMaxMin[1]);
            Console.WriteLine("========================================================================================================================");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector();                                       // Using of constructor by default
            float[] vs = { 1, -4, 5, -7, 25, -32, 44, 56, 100, -200 };      
            Vector v2 = new Vector(vs);                                     // Using of constructor by values
            v1.Output();                                                    // Output of the results
            v2.Output();                                                    // .
        }
    }
}
