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
        //Fältvariabler
        private string username;
        private string highscore;
        private int poäng;

        //Contructor
        public users(string username, string highscore, int poäng)
        {
            this.username = username;
            this.highscore = highscore;
            this.poäng = poäng;
        }

        /// <summary>
        /// Denna metod adderar poängen som användaren har det här spelet
        /// </summary>
        /// <returns></returns>
        public void addPoints(int roundPoints)
        {
            poäng += roundPoints;
            
        }

        /// <summary>
        /// Denna metod sparar highscoren, om användaren har slagit ett nytt rekord eller om det fortfarande är de gammla
        /// </summary>
        /// <param name="points"></param>
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

        
        /// <summary>
        /// Metoden låter användaren välja om hen vill använda en existerande användare eller skapa en ny
        /// </summary>
        /// <returns></returns>
        static public users CreateOrUseUser()
        {
            List<users> användare = new List<users>();

            string path = @"Holusers\";
            
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
                    användarnamn = "";
                bool existingUser = true;

                while (existingUser)
                {
                    användarnamn = Console.ReadLine();
                    foreach (users user in användare)
                    {


                        if (path + användarnamn + ".txt" == user.GetUserName())
                        {
                            Console.WriteLine("Denna användare finns redan! Välj ett annant användarnamn.");
                            break;
                        }
                        else
                        {
                            existingUser = false;
                            break;
                        }


                    }
                }
                    
                    
                    
                


                string pathFile = @"C:\Users\CASPER\source\repos\HighOrLow\HighOrLow\bin\Debug\HOLusers\" + användarnamn + ".txt";

                //Detta skapar en fil med namnet som användaren har valt och även lägger till en 0:a för att inte programmet ska krascha efter
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

        public void ResetPoint()
        {
            poäng = 0;
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