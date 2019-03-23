using System;
using System.IO;
using Microsoft.Win32;
namespace DeletingTempAndPrefetchFiles
{
    class Program
    {
        static void Main(string[] args)
        {
			//Console.Title("----Windows Cleaner-----");
            // Set Windows Startup For Program
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("CleanerTempFiles", @"C:\Users\HP\Documents\tmp\DeletingTempAndPrefetchFiles\bin\Debug\DeletingTempAndPrefetchFiles.exe");

            // Call Method with Params
            DeleteFileAndDirectories(@"C:\Windows\Temp", @"C:\Windows\Prefetch");
        }

        // Implement Method For Deleting
        public static void DeleteFileAndDirectories(params string[] address)
        {
            // Select Element in Address Collections
            foreach (var adr in address)
            {
                DirectoryInfo dic = new DirectoryInfo(adr);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n-----------------------------Address:{adr}------------------------------");
                foreach (var element in dic.GetFiles())
                {
                    try
                    {
                        element.Delete();

                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"File \"{element.Name}\" Can Not Delete(The Process Used By Another Pointer)....");
                        continue;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"File \"{element.Name}\" Deleted...");
                }
                foreach (var element in dic.GetDirectories())
                {
                    try
                    {
                        element.Delete();
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Directory \"{element.Name}\" Can Not Delete(The Process Used By Another Pointer)....");
                        continue;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Directory \"{element.Name}\" Deleted...");
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("-----------------------------------------------------------------------\n\n");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\n\nFinished........\nPress Any Key To Exit...");
            Console.ReadKey();
        }
    }
}
