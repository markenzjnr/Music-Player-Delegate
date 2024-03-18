using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player
{
    public class MusicManager
    {
        private Dictionary<string, string> songs = new Dictionary<string, string>();

        public void ImportMusic()
        {
            Console.Write("Enter the directory path to import music from: ");
            string directoryPath = @"C:\Users\42-DAWG\Music";

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Music directory not found.");
                return;
            }
            string[] files = Directory.GetFiles(directoryPath, "*.mp3");
            foreach (string file in files)
            {
                string title = Path.GetFileNameWithoutExtension(file);
                if (!songs.ContainsKey(title))
                {
                    songs[title] = file;
                    Console.WriteLine($"Added:{title}");
                }
            }

            Console.WriteLine($"{files.Length} songs imported successfully. ");
        }

        public void PlaySong()
        {
            Console.Write("Enter the title of the song you want to play: ");
            string title = Console.ReadLine();
            if (songs.ContainsKey(title))
            {
                // Code to play the song (using appropriate library or process)
                Console.WriteLine($"Playing {title}: {songs[title]}");
            }
            else
            {
                Console.WriteLine("Song not found.");
            }
        }

        public void AddSong()
        {
            Console.Write("Enter the title of the song: ");
            string title = Console.ReadLine();
            Console.Write("Enter the file path of the song: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            if (songs.ContainsKey(title))
            {
                Console.WriteLine("Song already exists. Do you want to update it? (Y/N)");
                string response = Console.ReadLine().ToUpper();
                if (response != "Y")
                {
                    return;
                }
            }

            songs[title] = filePath;
            Console.WriteLine("Song added successfully");
        }

        public void UpdateSong()
        {
            Console.Write("Enter the title of the song you want to update: ");
            string title = Console.ReadLine();
            if (songs.ContainsKey(title))
            {
                Console.Write("Enter the new file path: ");
                string newFilePath = Console.ReadLine();

                if (!File.Exists(newFilePath))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                songs[title] = newFilePath;
                Console.WriteLine("Song updated successfully.");
            }
            else
            {
                Console.WriteLine("Song not found");
            }
        }

        public void DeleteSong()
        {
            Console.Write("Enter the title of the song you want to delete: ");
            string title = Console.ReadLine();
            if (songs.ContainsKey(title))
            {
                songs.Remove(title);
                Console.WriteLine("Song deleted successfully.");
            }
            else
            {
                Console.WriteLine("Song not found.");
            }
        }
    }
}
  