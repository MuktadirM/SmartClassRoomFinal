using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var date = DateTime.Now;

            string mm = "Information System";

            var two = mm.Split(" ");

            Console.WriteLine(date);
            Console.WriteLine(TruncateLongString(two[0],1));
            Console.ReadLine();

        }

        public static string TruncateLongString(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static string GetInitials(string courseName) {
            StringBuilder stringBuilder = new StringBuilder();
            var two = courseName.Split(" ");
            if (two.Length == 2) {
                stringBuilder.Append(TruncateLongString(two[0],1));
                stringBuilder.Append(TruncateLongString(two[1], 1));
            }

            stringBuilder.Append(TruncateLongString(two[0], 2));
            return stringBuilder.ToString().ToUpper();
        }
    }
}
