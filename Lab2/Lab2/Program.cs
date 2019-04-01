using System;

namespace Lab2
{
    class Vector
    {
        private float[] arr;                        // The vector we processing

        /// <summary>
        /// Constructor by default
        /// </summary>
        public Vector()
        {
            arr = new float[0];
        }

        /// <summary>
        /// Random constructor by the length
        /// </summary>
        /// <param name="size">The length of the random array</param>
        public Vector(int size)
        {
            arr = new float[size];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (float)(100 - random.NextDouble() * 200);
            }
        }

        /// <summary>
        /// The constructor by values
        /// </summary>
        /// <param name="x">The array we want to copy</param>
        public Vector(float[] x)
        {
            arr = new float[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                arr[i] = x[i];
            }
        }

        /// <summary>
        /// Changes positions of two negative numbers which are situated in succession
        /// </summary>
        public void ChangePositionOfNegativeNumbers()
        {
            int position = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (position == -1 && arr[i] < 0)
                {
                    position = i;
                }
                else if (position != -1 && arr[i] < 0)
                {
                    arr[i] += arr[position];
                    arr[position] = arr[i] - arr[position];
                    arr[i] -= arr[position];
                    position = -1;
                }
            }
        }

        /// <summary>
        /// Searches for the maximum and the minimum value of the array
        /// </summary>
        /// <returns>The array, where the first number is the maximum value and the second one is the minimum</returns>
        public float[] FindMaxAndMin()
        {
            float[] maxMin = { 0, 0 };
            foreach (var number in arr)
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
            int[] mMPositions = { -1, -1 };
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == maxMin[0])
                {
                    mMPositions[0] = i + 1;
                }
                else if (arr[i] == maxMin[1])
                {
                    mMPositions[1] = i + 1;
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
            foreach (var number in arr)
            {
                Console.Write("{0}; ", number);
            }
            float[] maxMin = FindMaxAndMin();
            int[] positionMaxMin = PositionOfMaxAndMin(maxMin);
            Console.WriteLine("\n\rThe maximum and the minimum of this array:\n\rMAX: {0}[{1}], MIN: {2}[{3}]", maxMin[0], positionMaxMin[0], maxMin[1], positionMaxMin[1]);

            ChangePositionOfNegativeNumbers();
            Console.WriteLine("The new array: ");
            foreach (var number in arr)
            {
                Console.Write("{0}; ", number);
            }
            Console.WriteLine();
            positionMaxMin = PositionOfMaxAndMin(maxMin);
            Console.WriteLine("Positions of maximum and minumum in the new array are:\n\rMAX: {0}, MIN: {1}\n\r", positionMaxMin[0], positionMaxMin[1]);
            Console.WriteLine("========================================================================================================================");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector();
            float[] vs = { 1, -4, 5, -7, 25, -32, 44, 56, 100, -200 };
            Vector v2 = new Vector(vs);
            v1.Output();
            v2.Output();
        }
    }
}
