using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace _7ZipConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"7ZipConsole | Made By Clxqz#0001";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
███████╗███████╗██╗██████╗  ██████╗ ██████╗ ███╗   ██╗███████╗ ██████╗ ██╗     ███████╗    
╚════██║╚══███╔╝██║██╔══██╗██╔════╝██╔═══██╗████╗  ██║██╔════╝██╔═══██╗██║     ██╔════╝    
    ██╔╝  ███╔╝ ██║██████╔╝██║     ██║   ██║██╔██╗ ██║███████╗██║   ██║██║     █████╗      
   ██╔╝  ███╔╝  ██║██╔═══╝ ██║     ██║   ██║██║╚██╗██║╚════██║██║   ██║██║     ██╔══╝      
   ██║  ███████╗██║██║     ╚██████╗╚██████╔╝██║ ╚████║███████║╚██████╔╝███████╗███████╗    
   ╚═╝  ╚══════╝╚═╝╚═╝      ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝    
                                                                                           
");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Archive or Extract Folder/File: ");
            string folder = Console.ReadLine().ToString();
            Console.Write("Extract or make and Archive, E/A: ");
            string option = Console.ReadLine().ToString();
            if (option == "E")
            {
               
                Console.WriteLine("Enter Extraction Path: ");
                string extraction = Console.ReadLine().ToString();
                ZipFile.ExtractToDirectory(folder, extraction);
            }
            else if (option == "A")
            {
                Console.Write("\r\nEnter A Name For Archive: ");
                string namearchive = Console.ReadLine().ToString();
                Properties.Settings.Default.saveDirectory = namearchive;
                Properties.Settings.Default.Save();
                Console.Write("\r\nEnter a new Direcory for archive: ");
                string newDirectory = Console.ReadLine().ToString();
                Console.Write("\r\nEnter Type Of Archive: ");
                string type = Console.ReadLine().ToString();
                DirectoryInfo info = new DirectoryInfo(folder);
                ZipFile.CreateFromDirectory(folder, $"{newDirectory}\\{namearchive}.{type}", CompressionLevel.Fastest, true);
                FileInfo fileinfo = new FileInfo($"{namearchive}.{type}");
                Console.WriteLine("Archive Length: " + fileinfo.Length);
                Thread.Sleep(1500);
                Console.Clear();
                

            }
            Console.ReadKey();
        }
    }
}
