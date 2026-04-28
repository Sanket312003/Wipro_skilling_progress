using System;
using System.Collections.Generic;
using System.Text;

namespace Day4_Assignment
{
    internal class PlaylistService
    {
        private LinkedList<string> playlist = new LinkedList<string>();
        private SortedList<int, string> ratingList = new SortedList<int, string>();
        private SortedDictionary<string, string> artistMap = new SortedDictionary<string, string>();

        // Add song to playlist
        public void AddSong()
        {
            Console.Write("Enter song name: ");
            string song = Console.ReadLine();

            playlist.AddLast(song);
            Console.WriteLine("Song added to playlist.");
        }

        // Remove song
        public void RemoveSong()
        {
            Console.Write("Enter song name to remove: ");
            string song = Console.ReadLine();

            if (playlist.Remove(song))
                Console.WriteLine("Song removed.");
            else
                Console.WriteLine("Song not found.");
        }

        // View playlist
        public void ViewPlaylist()
        {
            Console.WriteLine("Playlist:");
            foreach (var song in playlist)
            {
                Console.WriteLine(song);
            }
        }

        // Add song with rating
        public void AddRatedSong()
        {
            Console.Write("Enter rating (int): ");
            int rating = int.Parse(Console.ReadLine());

            Console.Write("Enter song name: ");
            string song = Console.ReadLine();

            if (!ratingList.ContainsKey(rating))
            {
                ratingList.Add(rating, song);
                Console.WriteLine("Song added to rating list.");
            }
            else
            {
                Console.WriteLine("Rating already exists! Try different rating.");
            }
        }

        // View songs sorted by rating
        public void ViewByRating()
        {
            Console.WriteLine("Songs by Rating:");
            foreach (var item in ratingList)
            {
                Console.WriteLine($"Rating: {item.Key} → {item.Value}");
            }
        }

        // Map artist to song
        public void AddArtistSong()
        {
            Console.Write("Enter artist name: ");
            string artist = Console.ReadLine();

            Console.Write("Enter song: ");
            string song = Console.ReadLine();

            artistMap[artist] = song;
            Console.WriteLine("Artist-song added.");
        }

        // View artist-wise sorted songs
        public void ViewArtistSongs()
        {
            Console.WriteLine("Songs by Artist (Sorted):");
            foreach (var item in artistMap)
            {
                Console.WriteLine($"{item.Key} → {item.Value}");
            }
        }
    }

}
