using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class MasterMindConsolView
    {
        //ANROP:    bool ok = SelfTest();
        //UPPGIFT:  Används vid debugning. Metoden anropar ala metoder i
        //          klassen och returnerar true om ingen bug hittades.
        public static bool SelfTest()
        {
            bool ok = true;
            ok = ok && ((stripSpaces("1 2   3 4")) == ("1234"));
            ok = ok && ((insertSpaces("1234")) == ("1 2 3 4"));
            ok = ok && (toString(new MatchResult(4, 0)) == ("@@@@"));
            ok = ok && (toString(new MatchResult(0, 4)) == ("0000"));
            ok = ok && (toString(new MatchResult(3, 0)) == ("@@@."));
            ok = ok && (toString(new MatchResult(0, 3)) == ("000."));
            ok = ok && (toString(new MatchResult(3, 1)) == ("@@@0"));
            ok = ok && (toString(new MatchResult(1, 3)) == ("@000"));
            ok = ok && (toString(new MatchResult(2, 1)) == ("@@0."));
            ok = ok && (toString(new MatchResult(1, 2)) == ("@00."));
            ok = ok && (toString(new MatchResult(2, 2)) == ("@@00"));
            ok = ok && (toString(new MatchResult(0, 0)) == ("...."));
            return ok;
        }

        //ANROP:    string str = stripSpaces(string testKey);
        //UPPGIFT:  ta bort mellanslag och returnera sträng
        public static string stripSpaces(string testKey)
        {
            string str;
            StringBuilder sb = new StringBuilder();
            foreach (char ch in testKey)
            {
                if (ch != ' ')
                    sb.Append(ch);
            }
            str = sb.ToString();
            return str;
        }

        //ANROP:    string str = insertSpaces(string testKey);
        //UPPGIFT:  lägger in mellanslag mellan varje tecken och returnerar strängen
        public static string insertSpaces(string testKey)
        {
            string str;
            StringBuilder sb = new StringBuilder();
            foreach (char ch in testKey)
            {
                sb.Append(ch);
                if (sb.Length < 7)
                    sb.Append(' ');
            }
            str = sb.ToString();
            return str;
            
        }

        //ANROP:    string str = toString(MatchResult mr);
        //UPPGIFT:  lägger in symboler som motsvara utfall i sträng och returner sträng
        public static string toString(MatchResult mr)
        {
            string str;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mr.NumCorrect; i++)
            {
                sb.Append('@');
            }
            for (int i = 0; i < mr.NumSemiCorrect; i++)
            {
                sb.Append('0');
            }
            for (int i = mr.NumCorrect+mr.NumSemiCorrect; i < 4; i++)
            {
                sb.Append('.');
            }
                str = sb.ToString();
            return str;
        }
        
        //ANROP:    Reset();
        //UPPGIFT:  Rensar skärmen;
        public void Reset()
        {
            Console.Clear();
        }
        
        //ANROP:    ShowTestKey(int pos, string testKey);
        //UPPGIFT:  SKriver ut gissning som gissning
        public void ShowTestKey(int pos, string testKey)
        {
            Console.SetCursorPosition(10, pos);
            insertSpaces(testKey);
            Console.Write(testKey);
        }

        
        //ANROP:    ShowTestResult(int pos, MatchResult mr, bool animated);
        //UPPGIFT:  Skriver ut resultatet av gissningen
        public void ShowTestResult(int pos, MatchResult mr, bool animated)
        {
            Console.SetCursorPosition(20,pos);
            string result = toString(mr);
            foreach (char ch in result)
            {
                Console.Write(ch);
                System.Threading.Thread.Sleep(500);               
            }
        }

        //ANROP:    string str = GetUsersTestKey();
        //UPPGIFT:  läser in gissningen och returerar den i en sträng
        public string GetUsersTestKey()
        {
            Console.SetCursorPosition(10, 14);
            Console.Write("Your test key: ");
            Console.SetCursorPosition(25, 14);
            string testKey = Console.ReadLine();
            return stripSpaces(testKey);
        }

        //ANROP:    EraseUsersTestKey();
        //UPPGIFT:  Blankar föregående gissning
        public void EraseUsersTestKey()
        {
            Console.SetCursorPosition(25, 14);
            Console.Write("                                                ");
        }
       
        
    }
}
