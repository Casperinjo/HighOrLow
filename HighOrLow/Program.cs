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
            string spelatKortId;

            for (int i = 0; i < 52; i++)
            {
                while (true)
                {
                    kortNummer = randNummer.Next(0, 13);
                    kortTyp = randTyp.Next(0, 4);
                    spelatKortId = "#" + kortTyp.ToString() + kortNummer.ToString();

                    if (speladeKort.Contains(spelatKortId) == true)
                    {
                        continue;
                    }
                    else
                    {
                        kortlek[kortTyp, kortNummer].ShowCards();
                        speladeKort.Add(spelatKortId);

                        Console.WriteLine("i = " + i);
                        break;
                    }
                }
            }

            Console.ReadLine();
        }
    }
}