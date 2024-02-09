using System;
using System.IO;

namespace copy__again
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream(@"..\..\..\copyMe.png", FileMode.Open))
            {
                using (FileStream writer = new FileStream(@"..\..\..\copied.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[256];
                        int count = reader.Read(buffer, 0, buffer.Length);

                        if (count == 0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, count);
                    }
                    
                }
            }
        }
    }
}
