using Day4_Assignment;

class Program
{
    static void Main()
    {
        PlaylistService service = new PlaylistService();

        while (true)
        {
            Console.WriteLine("\n1. Add Song");
            Console.WriteLine("2. Remove Song");
            Console.WriteLine("3. View Playlist");
            Console.WriteLine("4. Add Rated Song");
            Console.WriteLine("5. View Songs by Rating");
            Console.WriteLine("6. Add Artist Song");
            Console.WriteLine("7. View Artist Songs");
            Console.WriteLine("8. Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: service.AddSong(); break;
                case 2: service.RemoveSong(); break;
                case 3: service.ViewPlaylist(); break;
                case 4: service.AddRatedSong(); break;
                case 5: service.ViewByRating(); break;
                case 6: service.AddArtistSong(); break;
                case 7: service.ViewArtistSongs(); break;
                case 8: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}