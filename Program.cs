using System;
using System.Linq;
using System.Text;

namespace LegendaryInsights
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                Console.WriteLine("Enter the amount of legendary insights you want to have!");
                string _userEntry = Console.ReadLine();
                if (int.TryParse(_userEntry, out int _amount))
                {
                    Console.WriteLine(Calculate(_amount));
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again and enter a number!");
                }
            }


        }
        
        private static string Calculate (int amount)
        {
            //legendary insight = [&AgH2LQEA]
            string _itemCode = "AgH2LQEA";
            // Convert to bytes
            byte[] bytes = Convert.FromBase64String(_itemCode);

            // Convert to hex string
            StringBuilder sb = new StringBuilder();            
            foreach(byte b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            string _hex = sb.ToString();

            //Apply amount
            string _hexAmount = amount.ToString("X");
            string _newHex = _hex.Substring(0, 2) + _hexAmount + _hex.Substring(4);

            // Convert back to bytes
            byte[] newBytes = Enumerable.Range(0, _newHex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(_newHex.Substring(x, 2), 16)).ToArray();
            
            //Convert to string b64
            string _strb64 = Convert.ToBase64String(newBytes);                      
            return "[&" + _strb64 + "]";
        }
    }
}
