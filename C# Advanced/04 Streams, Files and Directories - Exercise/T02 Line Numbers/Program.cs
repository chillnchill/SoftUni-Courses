using System;
using System.IO;

namespace T02_Line_Numbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] line = File.ReadAllLines(inputFilePath);
            int row = 1;
            for (int i = 0; i < line.Length; i++)
            {
                string currentLine = line[i];
                int letterCount = 0;
                int otherChars = 0;

                for (int j = 0; j < currentLine.Length; j++)
                {
                    if (char.IsLetterOrDigit(currentLine[j]))
                    {
                        letterCount++;
                    }
                    if (char.IsPunctuation(currentLine[j]))
                    {
                        otherChars++;
                    }
                }

                line[i] = ($"Line {row}: {currentLine} ({letterCount})({otherChars})");
                row++;
            }
            File.WriteAllLines(outputFilePath, line);
        }
    }
}




