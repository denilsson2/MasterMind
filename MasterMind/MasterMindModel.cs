using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{

    class MasterMindModel
    {
        private string _secretKey; // den hemliga nyckeln

        public MasterMindModel()
        {
            _secretKey = createSecretKey();
        }
        public string SecretKey
        {
            get { return _secretKey; }
        }
        //ANROP:    bool ok = SelfTest();
        //UPPGIFT:  Används vid deuggning. Metoden anropar ala metoder i
        //          klassen och returnerar true om ingen bug hittades.
        public static bool SelfTest()
        {

            bool ok = true;

            ok = IsValidKey("2361") && !IsValidKey("2368") && !IsValidKey("ABCD")
                && !IsValidKey("+-*=") && !IsValidKey("2301") && !IsValidKey("23611")
                && !IsValidKey("231");
            System.Diagnostics.Debug.WriteLine("IsValidKey; " + ok);

            for (int i = 0; i < 1000 && ok; ++i)
                ok = IsValidKey(createSecretKey());
            System.Diagnostics.Debug.WriteLine("createSecretKey: " + ok);

            MasterMindModel model = new MasterMindModel();
            ok = IsValidKey(model._secretKey);
            System.Diagnostics.Debug.WriteLine("MasterMindModell konstruktor: " + ok);

            ok = ok && ((MatchKeys("1222", "3111")) == new MatchResult(0, 1));
            ok = ok && ((MatchKeys("1234", "1234")) == new MatchResult(4, 0));
            ok = ok && ((MatchKeys("1234", "4321")) == new MatchResult(0, 4));
            ok = ok && ((MatchKeys("1234", "1243")) == new MatchResult(2, 2));
            ok = ok && ((MatchKeys("1234", "1212")) == new MatchResult(2, 0));
            ok = ok && ((MatchKeys("1234", "5612")) == new MatchResult(0, 2));
            ok = ok && ((MatchKeys("1444", "1144")) == new MatchResult(3, 0));
            ok = ok && ((MatchKeys("5224", "4334")) == new MatchResult(1, 0));
            ok = ok && ((MatchKeys("1223", "2245")) == new MatchResult(1, 1));
            System.Diagnostics.Debug.WriteLine("MatchKeys: " + ok);

            return ok;
        }

        //ANROP:    ok = IValidKey( key );
        //UPPGIFT:  returnerar true om key är giltig nyckel.
        public static bool IsValidKey(string key)
        {
            if (key.Length != 4)
                return false;
            foreach (char value in key)
            {
                if (!(char.IsNumber(value)))
                    return false;
                int val = (int)Char.GetNumericValue(value);
                if (val < 1 || val > 7)
                    return false;
            }
            return true;
        }

        //ANROP:    string secret = createSecretKey();
        //UPPGIFT:  Returnerar en slumpnyckel!
        public static string createSecretKey()
        {

            Random rand = new Random();
            String symbols = "1234567";
            String key;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; ++i)
            {
                char ch = symbols[rand.Next(symbols.Length)];
                sb.Append(ch);
            }
            key = sb.ToString();
            return key;
        }

        //ANROP: MathResult mr = MatchKeys(secretKey, testKey);
        //UPPGIFT: returnerar matchresultat för gissning
        public static MatchResult MatchKeys(string secretKey, string testKey)
        {
            int tempCorrect = 0, tempNumSemiCorrect = 0;

            for (int s = 0; s < secretKey.Length; s++)
            {

                
                if (secretKey[s] == testKey[s])
                {
                    StringBuilder sSb = new StringBuilder();
                    StringBuilder tSb = new StringBuilder();
                    sSb.Append(secretKey);
                    tSb.Append(testKey);
                    sSb.Insert(s, '0');
                    tSb.Insert(s, '0');
                    sSb.Remove(s + 1, 1);
                    tSb.Remove(s + 1, 1);
                    secretKey = sSb.ToString();
                    testKey = tSb.ToString();
                    tempCorrect++;

                }
            }
            if (!(tempCorrect == 4))
            {
                for (int t = 0; t < testKey.Length; t++)
                {
                    if (!(testKey[t] == '0'))
                    {
                        for (int s = 0; s < secretKey.Length; s++)
                        {
                            if (secretKey[s] == testKey[t] && !(testKey[t] == '0'))
                            {
                                StringBuilder sSb = new StringBuilder();
                                StringBuilder tSb = new StringBuilder();
                                sSb.Append(secretKey);
                                tSb.Append(testKey);
                                sSb.Insert(s, '0');
                                tSb.Insert(t, '0');
                                sSb.Remove(s + 1, 1);
                                tSb.Remove(t + 1, 1);
                                secretKey = sSb.ToString();
                                testKey = tSb.ToString();
                                tempNumSemiCorrect++;
                                break;
                            }
                        }
                    }
                }
            }
            return new MatchResult(tempCorrect, tempNumSemiCorrect);
        }//MatchResult MatchKeys(string secretKey, string testKey)
        
    }
}
