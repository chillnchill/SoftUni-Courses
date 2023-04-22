
namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string text = "";
            Console.WriteLine(ProcessLines(text));
        }

        public static string ProcessLines(string text)
        {
            using StreamReader reader = new StreamReader(@"..\..\..\text.txt");
            char[] replace = { '-', ',', '.', '!', '?' };

            int count = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }
                if (count % 2 == 0)
                {
                    line = ReplaceChars(replace, '@', line);
                    line = Reverse(line);
                    Console.WriteLine(line);
                }
                count++;
            }
            return text;
        }

        static string Reverse(string line)
        {
            string[] word = line.Split(' ').ToArray();
            line = "";
            for (int i = 0; i < word.Length; i++)
            {
                line += word[word.Length - i - 1];
                line += ' ';
            }
            return line;
        }

        static string ReplaceChars(char[] replace, char v, string line)
        {

            foreach (char ch in replace)
            {
                if (line.Contains(ch))
                {
                    line = line.Replace(ch, v);
                }
            }
            return line;
        }
    }
}
