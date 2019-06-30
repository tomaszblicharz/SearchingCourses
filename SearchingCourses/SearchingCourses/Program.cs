using SearchingCurses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingCourses
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Podaj artystę: ");
            var artist = Console.ReadLine();
            Console.Write("Podaj 4 piosenki zatwierdzając kazdą enterem: " + "\n");
            string[] titles = new string[4];
            for (int i = 0; i < titles.Length; i++)
            {
                titles[i] = Console.ReadLine();
            }

            var yourArtist = new Artist(artist);
            yourArtist.songTitles = new List<string>
            {
                titles[0],
                titles[1],
                titles[2],
                titles[3]

            };
            yourArtist.CalculateSwearAndWordCount();
            yourArtist.DisplayStatistics();


            Console.WriteLine("Gotowe.");
            Console.ReadLine();
        }
    }
}
        
    

