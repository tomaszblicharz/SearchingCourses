﻿using System;
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
            var webcache = new webCache();
            var eminem = new Artist("Eminem");
            eminem.songTitles = new List<string>
            {
                "Lose Yourself",
                "Not Afraid",
                "Sing for the Moment"
            };
            eminem.CalculateSwearAndWordCount();
            eminem.DisplayStatistics();

           

            var profanityFinder = new ProfanityFinder();

          

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }

    internal class webCache
    {
        public webCache()
        {
        }
    }
}
        
    

