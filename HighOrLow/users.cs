using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HighOrLow
{
    internal class users
    {
        private string username;
        private string highscore;
        private int poäng;

        public users(string username, string highscore, int poäng)
        {
            this.username = username;
            this.highscore = highscore;
            this.poäng = poäng;
        }

        public int addPoints()
        {
            poäng++;
            return poäng;
        }

        public void Highscore(string points)
        {
            string path = @"C:\Users\CASPER\source\repos\HighOrLow\HighOrLow\bin\Debug\HOLusers\";
            string schoolPath = @"C:\Users\casper.karlsson3\Documents\GitHub\HighOrLow\HighOrLow\bin\Debug\HOLusers\";

            int totalPoängHeltal = int.Parse(highscore);
            int pointsHeltal = int.Parse(points);

            if (totalPoängHeltal < pointsHeltal)
            {
                File.WriteAllText(schoolPath + username, points);
            }
        }

        static public users CreateOrUseUser()
        {
            List<users> användare = new List<users>();

            string path = @"C:\Users\CASPER\source\repos\HighOrLow\HighOrLow\bin\Debug\HOLusers\";
            string schoolPath = @"C:\Users\casper.karlsson3\Documents\GitHub\HighOrLow\HighOrLow\bin\Debug\HOLusers\";

            string[] myFiles = Directory.GetFiles(schoolPath);

            foreach (string myFile in myFiles)
            {
                användare.Add(new users(myFile, File.ReadAllText(myFile), 0));
            }

            int userChoice;
            string användarnamn;

            Console.WriteLine("Vill du använda en existerande användare eller skapa en ny?");
            Console.WriteLine("Tryck 1 för att använda en existerande!");
            Console.WriteLine("Tryck 2 för att skapa en ny användare!");
            while (true)
            {
                try
                {
                    userChoice = int.Parse(Console.ReadLine());
                    if (userChoice < 1 || userChoice > 2)
                    {
                        Console.WriteLine("Ogitigt svar, Prova igen!");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Ogiltigt svar, Prova igen!");
                }
            }

            if (userChoice == 1)
            {
                while (true)
                {
                    Console.Write("Skriv in din användare : ");
                    användarnamn = Console.ReadLine();

                    foreach (users user in användare)
                    {
                        if (schoolPath + användarnamn + ".txt" == user.GetUserName())
                        {
                            return user;
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Denna användare finns inte, Prova igen!");
                }
            }
            else
            {
                Console.Write("Skriv vad din användare ska ha för användar namn : ");
                användarnamn = Console.ReadLine();

                File.Create(schoolPath + användarnamn + ".txt");
                users newUser = new users(användarnamn + ".txt", "0", 0);
                return newUser;
            }
        }

        public string GetUserName()
        {
            return username;
        }

        public string GetHighscore()
        {
            return highscore;
        }

        public int GetPoints()
        {
            return poäng;
        }
    }
}