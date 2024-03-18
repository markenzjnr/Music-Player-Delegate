using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{  // Define delegates
    internal delegate void PlaySongDelegate();
    internal delegate void AddSongDelegate();
    internal delegate void UpdateSongDelegate();
    internal delegate void DeleteSongDelegate();
    internal delegate void ImportMusicDelegate();
    internal class Program
    {
        
        static void Main(string[] args)
        {
            MusicManager manager = new MusicManager();

            manager.ImportMusic();


            while(true) 
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Play a song");
                Console.WriteLine("2. Add a song");
                Console.WriteLine("3. Update a song");
                Console.WriteLine("4. Delete a song");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlaySongDelegate playDelegate = new PlaySongDelegate(manager.PlaySong);
                        break;
                    case "2":
                        AddSongDelegate addDelegate = new AddSongDelegate(manager.AddSong);
                        break;
                    case "3":
                        UpdateSongDelegate updateDelegate = new UpdateSongDelegate(manager.UpdateSong);
                       break;
                    case "4":
                       DeleteSongDelegate deleteDelegate = new DeleteSongDelegate(manager.DeleteSong);
                       break;
                    case "5":
                        ImportMusicDelegate importDelegate = new ImportMusicDelegate(manager.ImportMusic);
                        break;
                    case "6":
                        Console.WriteLine("Exiting....");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
            }
        }

        
    }
}
