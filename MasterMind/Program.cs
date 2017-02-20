using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        //ANROP:    bool ok = SelfTest();
        //UPPGIFT:  Kör alla självtesterna och returnerar true om alla lyckas
        static bool SelfTest() 
        {
            bool ok = MasterMindModel.SelfTest()
                    && MasterMindConsolView.SelfTest()
                    && MasterMindController.SelfTest();
            if (ok)
                System.Diagnostics.Debug.WriteLine("Alla självtesterna lyckades");
            else
                System.Diagnostics.Debug.WriteLine("Fel upptäcktes av slälvtest");
            return ok;
        }
        
    
        static void Main(string[] args)
        {
            SelfTest();
            bool play = true;
            while (play)
            {
                MasterMindController c = new MasterMindController();
                c.playGame();
                
                //int result = MasterMindController.playGame();
                int result = c.playGame();

                if (result != 11)
                {
                    Console.SetCursorPosition(16, 18);
                    Console.Write("Grattis, du klarade det på " + result + " försök.");
                }
                else
                {
                    Console.SetCursorPosition(16, 18);
                    Console.Write("Tyvärr looser... du får inte " + result + " försök");
                }
                Console.SetCursorPosition(20, 22);
                Console.Write("Spela igen (j/n) ");
                string str = Console.ReadLine();
                if(str=="n")
                { play = false;}

            }
            
        }
    }
}
