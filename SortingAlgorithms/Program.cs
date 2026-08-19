namespace AlgoritmiOrdinamento
{
    internal class Program
    {
        static GestoreAlgoritmi algoritmi;

        static void Main(string[] args)
        {
            string messaggioCreazioneArray =
                "[1] -> lunghezza 10 000\t\tintervallo valori[1 - 100]\n" +
                "[2] -> lunghezza 50 000\t\tintervallo valori[1 - 100]\n" +
                "[3] -> lunghezza 100 000\tintervallo valori[1 - 100]\n" +
                "[4] -> lunghezza 1 000 000\tintervallo valori[1 - 1000]\n" +
                "[9] -> Personalizza dati\n" +
                "[0] -> Esci dal programma\n" +
                "Seleziona un template oppure personalizzalo per creare l'array: ";

            string messaggioSelezioneAlgoritmo =
                "\n[1] -> Selection sort\n" +
                "[2] -> Bubble sort\n" +
                "[3] -> Insertion sort\n" +
                "[4] -> Shell sort\n" +
                "Scegli l'algoritmo di ordinamento: ";

            do
            {
                int lunghezza, nMin, nMax, sceltaAlgoritmo;
                lunghezza = nMin = nMax = 0;

                Console.WriteLine(messaggioCreazioneArray);
                int sceltaCreazioneArray = Convert.ToInt32(Console.ReadLine());
                if (sceltaCreazioneArray == 0)
                {
                    Console.WriteLine("\nProgramma terminato");
                    break;
                }
                switch (sceltaCreazioneArray)
                {
                    case 1:
                        lunghezza = 10000;
                        nMin = 1;
                        nMax = 100;
                        break;
                    case 2:
                        lunghezza = 50000;
                        nMin = 1;
                        nMax = 100;
                        break;
                    case 3:
                        lunghezza = 100000;
                        nMin = 1;
                        nMax = 100;
                        break;
                    case 4:
                        lunghezza = 1000000;
                        nMin = 1;
                        nMax = 1000;
                        break;
                    case 9:
                        Console.WriteLine("\nInserisci la lunghezza dell'array, il numero minimo e massimo generato, tutti separati tra loro da una virgola: ");
                        string caratteristicheVettore = Console.ReadLine();
                        DividiCaratteristicheArray(caratteristicheVettore, ref lunghezza, ref nMin, ref nMax);
                        break;
                    default:
                        Console.WriteLine("Scelta invalida, riavviare il programma");
                        break;
                }
                algoritmi = new GestoreAlgoritmi(lunghezza, nMin, nMax);

                Console.WriteLine(messaggioSelezioneAlgoritmo);
                sceltaAlgoritmo = Convert.ToInt32(Console.ReadLine());
                switch (sceltaAlgoritmo)
                {
                    case 1:
                        MessaggioInizioOrdinamento();
                        algoritmi.SelectionSort();
                        break;
                    case 2:
                        MessaggioInizioOrdinamento();
                        algoritmi.BubbleSort();
                        break;
                    case 3:
                        MessaggioInizioOrdinamento();
                        algoritmi.InsertionSort();
                        break;
                    case 4:
                        MessaggioInizioOrdinamento();
                        algoritmi.ShellSort();
                        break;
                    default:
                        Console.WriteLine("Scelta invalida, riavviare il programma");
                        break;
                }
                MessaggioFineOrdinamento();
                Console.WriteLine(algoritmi.TempoEsecuzione);
                Console.WriteLine("\n------------------------------------------------------------------------------------------\n");
            } while (true);
        }

        static void DividiCaratteristicheArray(string input, ref int length, ref int min, ref int max)
        {
            string[] ris = input.Split(",");
            length = Convert.ToInt32(ris[0]);
            min = Convert.ToInt32(ris[1]);
            max = Convert.ToInt32(ris[2]);
        }

        static void MessaggioInizioOrdinamento()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorVisible = false;
            Console.WriteLine("Ordinamento in corso, attendere...");
        }

        static void MessaggioFineOrdinamento()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = true;
            Console.WriteLine("\nOrdinamento completato");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
