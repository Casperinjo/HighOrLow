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
            Console.WriteLine(kortNummer + " " + kortAttribut);
        }

        static public SkapaKortlek[,] CreateCards()
        {
            SkapaKortlek[,] kort = new SkapaKortlek[4, 13];
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    kort[j, i] = new SkapaKortlek((kortStorlek)i, (kortTyp)j);
                }
            }
            return kort;
        }
    }
}