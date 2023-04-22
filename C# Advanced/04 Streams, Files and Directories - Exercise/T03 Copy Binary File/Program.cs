using System;
using System.IO;

namespace CopyBinaryFile
{
    using System;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            const int BYTE_BUFFER = 4096;
            using (FileStream reader = new FileStream(inputFilePath, FileMode.Open))
            using (FileStream writer = new FileStream(outputFilePath, FileMode.Create))

                while (reader.CanRead)
                {
                    byte[] buffer = new byte[BYTE_BUFFER];
                    int readBytes = reader.Read(buffer, 0, BYTE_BUFFER);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    writer.Write(buffer, 0, readBytes);
                }
        }
    }
}