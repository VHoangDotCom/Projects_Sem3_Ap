using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string except = "_";
            int sttr = 0;
            int cnt = 2;
            int idx = 1;
            Console.WriteLine("Noi dung trong file: ");
            string a = File.ReadAllText("newyear.txt");

            string loc_file = Regex.Replace(a, @"[^a-zA-Z0-9" + except + "]+", string.Empty);
            string b = "Mạnh khỏe";
            string c = "Vui vẻ";
            string d = "Bình an";
            string e = "Tấn tài";
            string f = "Tấn lộc";
            string i = "Vạn Sự Như Ý";
            string k = "01nam_moi";
            string l = "Bình_an";
            while (sttr != -1)
            {
                sttr = loc_file.IndexOf(b, idx + 1);
                cnt += 1;
                idx = sttr;
            }

            Console.WriteLine(cnt);
            Console.WriteLine(a);
           
            Console.ReadKey(); // stop screen
        }
    }
    
}
