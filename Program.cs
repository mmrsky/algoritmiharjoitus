using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // stopwatch

/// <summary>
/// Tietorakenteiden ja algoritmien harjoitustyö - Järjestämisalgoritmit
/// 28.11.2019 Mika Mörsky
/// 
/// </summary>
namespace AlgoritmiHarjoitustyo
{
    class Program
    {

        public delegate void SortDelegate(int[] num);
        public delegate int[] CreateArrayDelegate(int size);

        /// <summary>
        /// Bubble sort algorithm
        /// </summary>
        /// <param name="arr"></param>
        private static void BubbleSort(int[] arr)
        {
            int temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }
        private static void InsertionSort(int[] arr)
        {
            // https://www.geeksforgeeks.org/insertion-sort/ 
            int i, key, j;
            int n = arr.Length;

            for (i = 1; i < n; i++)
            {
                key = arr[i];
                j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        private static void SelectionSort(int[] num)
        {
            int i, j, first, temp;
            for (i = num.Length - 1; i > 0; i--)
            {
                first = 0;   //initialize to subscript of first element
                for (j = 1; j <= i; j++)   //locate smallest element between positions 1 and i.
                {
                    if (num[j] > num[first])
                        first = j;
                }
                temp = num[first];   //swap smallest found with element in position i.
                num[first] = num[i];
                num[i] = temp;
            }
        }


        static int[] CreateTable(int size)
        {
            // luo ensin taulukko, missä alkiot ei ole järjestyksessä
            int[] taulukko = new int[size];
            // täytetään taulukko satunnaisluvuilla
            Random generaattori = new Random();

            for (int i = 0; i < taulukko.Length; i++)
            {
                taulukko[i] = generaattori.Next(size);
            }

            return taulukko;
        }


        static void Metodi(SortDelegate del)
        {
            int[] taulukko = CreateTable(10000);

            // käynnistä ajastin
            Stopwatch kello = Stopwatch.StartNew();

            // ota aika ja tulosta se
            del(taulukko);

            var elapsedTime = kello.Elapsed;
            Console.WriteLine("Sort: {0}", elapsedTime);
        }

        static void Main(string[] args)
        {

            SortDelegate dinsert = new SortDelegate(InsertionSort);
            SortDelegate dselect = new SortDelegate(SelectionSort);
            SortDelegate dbubble = new SortDelegate(BubbleSort);


            Metodi(dinsert);
            Metodi(dselect);
            Metodi(dbubble);

          
            Console.ReadKey();

        }
    }
}
