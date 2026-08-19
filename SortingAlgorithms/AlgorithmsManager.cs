using System.Diagnostics;

namespace SortingAlgorithms
{
    internal class AlgorithmsManager
    {
        readonly int[] vector;
        public string executionTime;

        public AlgorithmsManager(int vectorLength, int minNumber, int maxNumber)
        {
            vector = new int[vectorLength];
            Random rand = new();

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = rand.Next(minNumber, maxNumber + 1);
            }
        }

        void CalculateExecutionTime(Stopwatch stopwatch)
        {
            TimeSpan ts = stopwatch.Elapsed;
            executionTime = $"Execution time - {ts.Hours}:{ts.Minutes}:{ts.Seconds}.{ts.Milliseconds}";
        }

        public string ExecutionTime
        {
            get { return executionTime; }
        }

        public void SelectionSort()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            int lowerPosition;
            int temp;

            for (int i = 0; i < vector.Length - 1; i++)
            {
                lowerPosition = i;
                for (int j = i + 1; j < vector.Length; j++)
                {
                    if (vector[lowerPosition] > vector[j])
                    {
                        lowerPosition = j;
                    }
                }
                if (lowerPosition != i)
                {
                    temp = vector[i];
                    vector[i] = vector[lowerPosition];
                    vector[lowerPosition] = temp;
                }
            }

            stopwatch.Stop();
            CalculateExecutionTime(stopwatch);
        }

        public void BubbleSort()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            bool swap = true;
            int end = vector.Length - 1;
            int temp;

            while (swap == true)
            {
                swap = false;
                for (int i = 0; i < end; i++)
                {
                    if (vector[i] > vector[i + 1])
                    {
                        temp = vector[i];
                        vector[i] = vector[i + 1];
                        vector[i + 1] = temp;

                        swap = true;
                    }
                }
                end--;
            }

            stopwatch.Stop();
            CalculateExecutionTime(stopwatch);
        }

        public void InsertionSort()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            for (int i = 1; i < vector.Length; i++)
            {
                int insertion = vector[i];
                int index = i - 1;

                while (index >= 0 && vector[index] > insertion)
                {
                    vector[index + 1] = vector[index];
                    index--;
                }

                vector[index + 1] = insertion;
            }

            stopwatch.Stop();
            CalculateExecutionTime(stopwatch);
        }

        public void ShellSort()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            for (int gap = vector.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < vector.Length; i++)
                {
                    int j;
                    int temp = vector[i];
                    for (j = i; j >= gap && temp < vector[j - gap]; j -= gap)
                    {
                        vector[j] = vector[j - gap];
                    }
                    vector[j] = temp;
                }
            }

            stopwatch.Stop();
            CalculateExecutionTime(stopwatch);
        }
    }
}
