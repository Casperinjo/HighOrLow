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

        public void Highscore(int points)
        {

            


            int highscoreHeltal = int.Parse(highscore);
           

            FileStream fileStream = File.OpenWrite(username);
            StreamWriter writer = new StreamWriter(fileStream);


            if (highscoreHeltal < points)
            {
                writer.WriteLine(points);
            }
            else
            {
                writer.WriteLine(highscore);
            }
            writer.Close();
        }

        public string ShowUser()
        {
            return username;
        }

        static public users CreateOrUseUser()
        {
            List<users> användare = new List<users>();

            string path = @"C:\Users\CASPER\source\repos\HighOrLow\HighOrLow\bin\Debug\HOLusers\";
            string schoolPath = @"C:\Users\casper.karlsson3\Documents\GitHub\HighOrLow\HighOrLow\bin\Debug\HOLusers\";
            string[] myFiles = Directory.GetFiles(path);

            

                foreach (string myFile in myFiles)
                {
                    FileStream fileStream = File.OpenRead(myFile);
                    StreamReader reader = new StreamReader(fileStream);
                    
                    användare.Add(new users(myFile, reader.ReadLine() , 0));
                     

                    reader.Close();
                    
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
                        if (path + användarnamn + ".txt" == user.GetUserName())
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
                Console.Write("Skriv vad din användare ska ha för användarnamn : ");
                
                string pathFile = @"C:\Users\CASPER\source\repos\HighOrLow\HighOrLow\bin\Debug\HOLusers\" + Console.ReadLine() + ".txt";

                FileStream createFile = File.Create(pathFile);
                createFile.Close();
                FileStream sw = File.OpenWrite(pathFile);
                StreamWriter writer = new StreamWriter(sw);
                
                writer.WriteLine("0");
                writer.Close();
                
                users newUser = new users(pathFile, "0", 0);
                
                
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