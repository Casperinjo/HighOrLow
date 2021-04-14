using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HighOrLow
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<SkapaKortlek> kortlek = SkapaKortlek.CreateCards();
            List<SkapaKortlek> temporärKortlek = new List<SkapaKortlek>();

            Random randKort = new Random();

            int kort;

            for (int i = 0; i < kortlek.Count; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    kort = randKort.Next(0, kortlek.Count - 1);
                    temporärKortlek.Add(kortlek[kort]);
                    kortlek.Remove(kortlek[kort]);
                    temporärKortlek[j].ShowCards();
                }
            }

            Console.ReadLine();
        }
    }
}