using System.Diagnostics;

namespace AlgoritmiOrdinamento
{
    internal class GestoreAlgoritmi
    {
        int[] vettore;
        string tempoEsecuzione;

        public GestoreAlgoritmi(int lunghezzaArray, int numeroMinimo, int numeroMassimo)
        {
            vettore = new int[lunghezzaArray];
            Random rand = new Random();

            for (int i = 0; i < vettore.Length; i++)
            {
                vettore[i] = rand.Next(numeroMinimo, numeroMassimo + 1);
            }
        }

        void CalcolaTempoEsecuzione(Stopwatch stopwatch)
        {
            TimeSpan ts = stopwatch.Elapsed;
            tempoEsecuzione = $"Tempo di esecuzione - {ts.Hours}:{ts.Minutes}:{ts.Seconds}.{ts.Milliseconds}";
        }

        public string TempoEsecuzione
        {
            get { return tempoEsecuzione; }
        }

        public void SelectionSort()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int posizioneMinore;
            for (int i = 0; i < vettore.Length - 1; i++)
            {
                posizioneMinore = i;
                for (int j = i + 1; j < vettore.Length; j++)
                {
                    if (vettore[posizioneMinore] > vettore[j])
                    {
                        posizioneMinore = j;
                    }
                }
                if (posizioneMinore != i)
                {
                    int temp = vettore[i];
                    vettore[i] = vettore[posizioneMinore];
                    vettore[posizioneMinore] = temp;
                }
            }

            stopwatch.Stop();
            CalcolaTempoEsecuzione(stopwatch);
        }

        public void BubbleSort()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bool scambio = true;
            int fine = vettore.Length - 1;

            while (scambio == true)
            {
                scambio = false;
                for (int i = 0; i < fine; i++)
                {
                    if (vettore[i] > vettore[i + 1])
                    {
                        int temp = vettore[i];
                        vettore[i] = vettore[i + 1];
                        vettore[i + 1] = temp;

                        scambio = true;
                    }
                }
                fine--;
            }

            stopwatch.Stop();
            CalcolaTempoEsecuzione(stopwatch);
        }

        public void InsertionSort()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 1; i < vettore.Length; i++)
            {
                int inserimento = vettore[i];
                int indice = i - 1;

                while (indice >= 0 && vettore[indice] > inserimento)
                {
                    vettore[indice + 1] = vettore[indice];
                    indice--;
                }

                vettore[indice + 1] = inserimento;
            }

            stopwatch.Stop();
            CalcolaTempoEsecuzione(stopwatch);
        }

        public void ShellSort()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int gap = vettore.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < vettore.Length; i++)
                {
                    int j;
                    int temp = vettore[i];
                    for (j = i; j >= gap && temp < vettore[j - gap]; j -= gap)
                    {
                        vettore[j] = vettore[j - gap];
                    }
                    vettore[j] = temp;
                }
            }

            stopwatch.Stop();
            CalcolaTempoEsecuzione(stopwatch);
        }
    }
}