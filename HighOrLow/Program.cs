using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SkapaKortlek[,] kortlek = SkapaKortlek.CreateCards();
            List<string> speladeKort = new List<string>();
            Random randNummer = new Random();
            Random randTyp = new Random();
            int kortNummer;
            int kortTyp;
            string spelatKort;

            for (int i = 0; i < 52; i++)
            {
                while (true)
                {
                    kortNummer = randNummer.Next(0, 13);
                    kortTyp = randTyp.Next(0, 4);
                    spelatKort = kortTyp.ToString() + kortNummer.ToString();

                    if (speladeKort.Contains(spelatKort) == true)
                    {
                        Console.WriteLine(spelatKort);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                kortlek[kortTyp, kortNummer].ShowCards();
                speladeKort.Add(spelatKort);

                Console.ReadLine();

                Console.WriteLine(i + " = i");
            }

            Console.ReadLine();
        }
    }
}