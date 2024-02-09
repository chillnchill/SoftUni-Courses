namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputPath = @"..\..\..\copyMe.png";
            string archivePath = @"..\..\..\archive.zip";
            string outputPath = @"..\..\..\extracted.png";

            ZipFileToArchive(inputPath, archivePath);
            var fileName = Path.GetFileName(inputPath);
            ExtractFileFromArchive(archivePath, fileName, outputPath);
        }

        public static void ZipFileToArchive(string inputFilePath, string archivePath)
        {
            using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Create))
            {
                string fileName = Path.GetFileName(inputFilePath);
                archive.CreateEntryFromFile(inputFilePath, fileName);
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath))
            {
                ZipArchiveEntry forExtraction = archive.GetEntry(fileName);
                forExtraction.ExtractToFile(outputFilePath);
            }
        }
    }
}