﻿using Newtonsoft.Json;
using SearchingCurses;
using System;
using System.Net;

namespace SearchingCourses
{
    class Song

    {
        public string artist;
        public string title;
        public string lyrics;
        public Song(string artist, string title)
        {
     
            var url = "https://api.lyrics.ovh/v1/" + artist + "/" + title;
            var json = WebCache.GetOrDownload(url);
      

            var answer = JsonConvert.DeserializeObject<LyricsOvhAnswer>(json);
            lyrics = answer.lyrics;
            this.artist = artist;
            this.title = title;
            Console.WriteLine("Pobrano: " + artist + " - " + title);
            
            
        }

        public int CountWords()
        {
            return lyrics.Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}

