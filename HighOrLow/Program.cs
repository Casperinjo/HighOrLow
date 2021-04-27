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
            users användare = users.CreateOrUseUser();

            


            bool restart = true;
            string highscoreText;

            highscoreText = användare.GetHighscore();
            int highscore = int.Parse(highscoreText);

            while (true)
            {
                användare.ResetPoint();
                for (int i = 0; i < 4; i++)
                {
                    kortlek = SkapaKortlek.CreateCards();
                    Console.Clear();
                    Console.WriteLine("Ditt nuvarande highscore : " + användare.GetHighscore() + " poäng!");
                    Console.WriteLine("Omgång : " + (i + 1));
                    Barrier();
                    restart = GameRun(kortlek, temporärKortlek, användare, highscoreText);
                    Console.WriteLine("Total poäng : " + användare.GetPoints());
                    Console.ReadLine();

                    if (i == 3)
                    {
                        Console.WriteLine("Det var sista omgången och du samlade ihop : " + användare.GetPoints() + " poäng");
                        Console.WriteLine("Tryck \"Enter\" för att gå vidare");

                    }

                    if (restart)
                    {
                        användare.Highscore(användare.GetPoints());
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                    
            }
        }

        /// <summary>
        /// Denna metod körs varje runda och slumpar 13 kort från kortleken
        /// </summary>
        /// <param name="kortlek"></param>
        /// <param name="temporärKortlek"></param>
        private static bool GameRun(List<SkapaKortlek> kortlek, List<SkapaKortlek> temporärKortlek, users användare, string highscoreText)
        {
            Random randKort = new Random();


            int roundPoints = 0;
           
            //om användaren vill start om spelet returnerar metoden den här booleanen till false.
            bool restart = false;

            //varibel som kommer slumpas och bestämmer vilket kort från kortleken som kommer att dras ut.
            int kort;
            // Variabeln är till för att spara valet som användaren väljer om hen vill gissa högre eller lägre kort.
            int val;
            //denna variable bestämmer om valet användaren gjort stämmer eller inte
            bool resultat = true;

            int gameChoice;

            //Dennna loop tar ut 13 slumpade kort från huvud kortlek och raderas och läggs till i en temporär kortlek istället.
            for (int i = 0; i < 13; i++)
            {
                kort = randKort.Next(0, kortlek.Count - 1);
                temporärKortlek.Add(kortlek[kort]);
                kortlek.RemoveAt(kort);
            }
            for (int i = 0; i < 12; i++)
            {
                Console.Write("Kort nummer " + (i + 1) + " är: ");
                temporärKortlek[i].ShowCards();

                Console.WriteLine("Är ditt kort högre eller lägre än nästa kort? ");
                Console.WriteLine("Tryck 1 för högre:");
                Console.WriteLine("Tryck 2 för lägre");
                Barrier();
                val = LäsInInt();

                //Om korten är par så förlorar spelare och får välja om hen vill starta om eller avsluta spelet.
                if (/*temporärKortlek[i].GetNumber() == temporärKortlek[i + 1].GetNumber()*/false)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.Write("Tyvärr du förlorade spelade för nästa kort var också : ");
                    temporärKortlek[i + 1].ShowCards();
                    Console.WriteLine("Tryck 1 för att starta om spelet! ");
                    Console.WriteLine("Tryck 2 för att avsluta speler! ");
                    gameChoice = LäsInInt();

                    if (gameChoice == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;

                        temporärKortlek.Clear();
                        restart = true;
                        return restart;
                    }
                    else
                    {
                        //Om användaren väljer att avsluta spelet så kallas metoden för att spara highscore
                        användare.Highscore(användare.GetPoints());
                        Environment.Exit(0);
                    }
                }

                //Om nästa kort är ett ess, det vill säga ett trumf kort så får hen poäng automatiskt.
                else if (/*temporärKortlek[i + 1].GetNumber() == (kortStorlek)12*/true)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    
                    roundPoints++;
                    Console.WriteLine("Nästa kort var ett trumf kort så du får ett poäng ");

                    continue;
                }

                // Detta körs varje gång du inte får par eller trumf kort.
                else
                {
                    resultat = SkrivUtSwitch(val, temporärKortlek[i].GetNumber(), temporärKortlek[i + 1].GetNumber());
                }

                // Denna skriver ut om du hade fel eller om du hade rätt.
                if (resultat)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    roundPoints++;
                    
                    Console.Write("Du hade rätt nästa kort var : ");
                    temporärKortlek[i + 1].ShowCards();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("Det var fel nästa kort var : ");
                    temporärKortlek[i + 1].ShowCards();
                }
            }
            if (roundPoints == 12 )
            {
                Console.WriteLine("Grattis du hade alla rätt och får 50 extra poäng! ");
                roundPoints += 50;
            }
            Console.WriteLine("Omgången är klar du samlade totalt : " + roundPoints + " poäng!");
            Console.WriteLine("Tryck 1 för att fortsätta spelet : ");
            Console.WriteLine("Tryck 2 för att stänga av spelet : ");
            gameChoice = LäsInInt();
            if (gameChoice == 1)
            {
                Console.WriteLine("Spelet fortsätter! ");
            }
            else
            {
                //Om användaren väljer att avsluta spelet så kallas metoden för att spara highscore
                användare.Highscore(användare.GetPoints());

                Environment.Exit(0);
            }

            användare.addPoints(roundPoints);
            Console.BackgroundColor = ConsoleColor.White;
            Barrier();
            Console.ReadLine();

            temporärKortlek.Clear();

            return restart;
        }

        /// <summary>
        /// Denna metod är till för att bestämma om svaret som användaren gissade är rätt eller fel
        /// </summary>
        /// <param name="val"></param>
        /// <param name="kort1"></param>
        /// <param name="kort2"></param>
        /// <returns></returns>
        private static bool SkrivUtSwitch(int val, kortStorlek kort1, kortStorlek kort2)
        {
            bool resultat = true;
            if (kort1 != (kortStorlek)12)
            {
                switch (val)
                {
                    case 1:
                        resultat = kort1 > kort2;
                        break;

                    case 2:
                        resultat = kort1 < kort2;
                        break;
                }
            }
            else
            {
                resultat = true;
            }
            return resultat;
        }

        /// <summary>
        /// För att skapa en gräns mellan text
        /// </summary>
        private static void Barrier()
        {
            Console.WriteLine("----------------");
        }

        /// <summary>
        /// Den här metoden är till för att läsa in all heltal som använder ska slå in, den tillåter inte strings eller double. Och inte heller heltal som är större än 2 mindre än 0.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
         static int LäsInInt()
        {
            int val;
            while (true)
            {
                try
                {
                    val = int.Parse(Console.ReadLine());
                    if (val < 0 || val > 2)
                    {
                        Console.WriteLine("Ogilitgt svar, Prova igen!");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Ogilitgt svar, Prova igen!");
                }
            }
            return val;
        }
    }
}