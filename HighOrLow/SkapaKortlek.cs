using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow
{
    public enum kortStorlek { två, tre, fyra, fem, sex, sju, åtta, nio, tio, knekt, dam, kung, ess };

    public enum kortTyp { spader, hjärter, ruter, klöver };

    internal class SkapaKortlek
    {
        private kortStorlek kortNummer;
        private kortTyp kortAttribut;

        public SkapaKortlek(kortStorlek kortNummer, kortTyp kortAttribut)
        {
            this.kortNummer = kortNummer;
            this.kortAttribut = kortAttribut;
        }

        public void ShowCards()
        {
            Console.WriteLine(kortAttribut + " " + kortNummer);
        }

        public kortStorlek GetNumber()
        {
            return kortNummer;
        }

        static public List<SkapaKortlek> CreateCards()
        {
            List<SkapaKortlek> kort = new List<SkapaKortlek>();
            SkapaKortlek[,] temporärKortlek = new SkapaKortlek[4, 13];
            

            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 13; k++)
                {
                    temporärKortlek[j, k] = new SkapaKortlek((kortStorlek)k, (kortTyp)j);
                    kort.Add(temporärKortlek[j, k]);
                    
                }
            }

            Array.Clear(temporärKortlek, 0, temporärKortlek.Length);
            return kort;
        }
    }
}