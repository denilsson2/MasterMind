using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class MasterMindController
    {
        //ANROP:    bool ok = SelfTest();
        //UPPGIFT:  Används vid debugning. Metoden anropar alla metoder i
        //          klassen och returnerar true om ingen bug hittades.
        public static bool SelfTest()
        {
            bool ok = true;
            
            return ok;
        }

        //ANROP:    int i  = playGame();
        //UPPGIFT:  returner antal försök uppgiften löstes på;
        //public static int playGame()
        public int playGame()
        {
            
            MasterMindConsolView mv = new MasterMindConsolView();
            MasterMindModel mm = new MasterMindModel();
            mv.Reset();
            
            int guesses = 0;
            string secretKey = mm.SecretKey;
            bool correct = false;
            
            while (!correct)
            {
                
                guesses++;
                mv.EraseUsersTestKey();
                string testKey = mv.GetUsersTestKey();
                bool inputIsValid = MasterMindModel.IsValidKey(testKey);
                while (!inputIsValid)
                {
                    Console.SetCursorPosition(10, 16);
                    Console.Write("Felaktig inmatning");
                    mv.EraseUsersTestKey();
                    testKey = mv.GetUsersTestKey();
                    inputIsValid = MasterMindModel.IsValidKey(testKey);
                }

                Console.SetCursorPosition(10, 16);
                Console.Write("                        ");

                MatchResult mr = MasterMindModel.MatchKeys(secretKey, testKey);
                mv.ShowTestKey(11-guesses, MasterMindConsolView.insertSpaces(testKey));
                mv.ShowTestResult(11-guesses,mr,true);

                if(mr.NumCorrect==4)
                {
                    correct = true;
                }
                if (guesses == 10)
                {
                    guesses++;
                    correct = true;
                }
                
                
            }
            Console.SetCursorPosition(16, 20);
            Console.Write("Rätt svar: " + secretKey);
            
            return guesses;
            

        }
    }
}
