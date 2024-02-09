using System;
using System.IO;


namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"TextFiles\input.txt";
            string outputFilePath = @"TextFiles\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int row = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (row++ % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}