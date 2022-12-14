using System;
using System.Collections.Generic;

namespace T03_Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();

            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] songProperties = Console.ReadLine().Split('_');

                Song song = new Song(songProperties[0], songProperties[1], songProperties[2]);

                songs.Add(song);
            }
            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {                
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
    class Song
    {
        //this is a constuctor
        public Song(string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }
        //if there was no constructor we'd have to make TypeList = songProperties[0] etc
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

}
