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
            //var songLyrics = new SongLyrics("shakira", "Nada");
            var profanityFinder = new ProfanityFinder ("no, kurwa!");
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }

    internal class ProfanityFinder
    {
       

        public ProfanityFinder(string text)
        {
            var dictFile = File.ReadAllText(path:"profanities.txt")
        }
    }
}

