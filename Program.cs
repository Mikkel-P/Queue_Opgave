using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_Opgave
{
    class Program
    {
        // Vi lægger vores queue her så vi kan kalde på den i alle metoder
        static Queue<PrinterJob> printQueue = new Queue<PrinterJob>();
        static void Main(string[] args)
        {
            // Her genererer vi en random der dikterer størrelsen på vores filer
            Random rand = new Random();

            // Her genererer vi en masse filer, for at skabe en kø-lignende tilstand
            PrinterJob job1 = new PrinterJob();
            job1.FileName = "Kittens";
            job1.FileType = "jpg";
            job1.FileSize = rand.Next(1000, 50000);
            printQueue.Enqueue(job1);
            PrinterJob job2 = new PrinterJob();
            job2.FileName = "Movies";
            job2.FileType = "txt";
            job2.FileSize = rand.Next(1000, 50000);
            printQueue.Enqueue(job2);
            PrinterJob job3 = new PrinterJob();
            job3.FileName = "bomb manual";
            job3.FileType = "txt";
            job3.FileSize = rand.Next(1000, 50000);
            printQueue.Enqueue(job3);
            PrinterJob job4 = new PrinterJob();
            job4.FileName = "Switch Configuration";
            job4.FileType = "txt";
            job4.FileSize = rand.Next(1000, 50000);
            printQueue.Enqueue(job4);

            // En boolean til at vise vores menu
            bool showMenu = true;
            while (showMenu)
            {
                // Menu indhold
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("             H1 Queue Operations Menu");
                Console.WriteLine("==================================================");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add items");
                Console.WriteLine("2. Delete items");
                Console.WriteLine("3. Show the number of items");
                Console.WriteLine("4. Show min and max items");
                Console.WriteLine("5. Find an item");
                Console.WriteLine("6. Print all items");
                Console.WriteLine("7. Exit");
                // \n giver os en ny linje
                Console.Write("\nEnter a number: ");

                // En switch case til at holde styr på vores menu
                switch (Console.ReadLine())
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        DeleteItem();
                        break;
                    case "3":
                        ShowNumItems();
                        break;
                    case "4":
                        ShowMinMax();
                        break;
                    case "5":
                        FindItem();
                        break;
                    case "6":
                        PrintAll();
                        break;
                    case "7":
                        ExitMenu();
                        //showMenu = false; ville give det samme som vores metode
                        break;
                    default:
                        break;
                }
            }
        }
        static void AddItem()
        {
            // Her opretter vi et nyt objekt som vi kan tilføje til vores queue
            PrinterJob newFile = new PrinterJob();

            // Tilføjer et nyt objekt til vores queue
            printQueue.Enqueue(newFile);

            // Her genererer vi en random der dikterer størrelsen på vores filer
            Random random = new Random();

            Console.Clear();
            Console.WriteLine("Add file to the print queue...");
            Console.WriteLine("Name of the file you want to add?");
            // Vi opfanger brugerens input og laver det til et nyt fil navn
            newFile.FileName = Console.ReadLine();

            // Vi opfanger brugerens input og laver vores fil til en bestemt fil type
            Console.WriteLine("Write the file type.");
            newFile.FileType = Console.ReadLine();
            newFile.FileSize = random.Next(1000, 50000);
            Console.WriteLine($"File has been added to C:\\PrintableFiles\\{newFile.FileName}.{newFile.FileType}");
        }
        static void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("Name of the file you want to delete?");
            string fileInput = Console.ReadLine();
            Console.WriteLine("Write the file type.");
            string typeInput = Console.ReadLine();

            // Vi laver en ny kø som kopierer elementer fra den gamle kø, medmindre at det indtastede filnavn
            // stemmer overens med et der allerede eksisterer, og sletter det efterfølgende. Vi benytter LinQ
            // til at udelade en specifik plads på vores nye liste med .Where da en queue normalt kører efter
            // principperne first in - first out.
            printQueue = new Queue<PrinterJob>(printQueue.Where(job => (job.FileName != fileInput && job.FileType != typeInput)));

            Console.WriteLine("Your file has been deleted, succesfully.");
        }
        static void ShowNumItems()
        {
            Console.Clear();
            // Vi bruger  .Count for at tælle antal elementer i vores queue
            Console.WriteLine(printQueue.Count);
            Console.ReadLine();
            foreach (PrinterJob item in printQueue)
            {
                Console.WriteLine(item.FileName + "found.");
            }
        }
        static void ShowMinMax()
        {
            // Vi bruger LinQ's lambda expression for at pege på hvor der skal ledes efter en minimums/maksimums værdi
            Console.Clear();
            Console.WriteLine($"The Smallest file in the queue {printQueue.Min(job => job.FileSize)}");
            Console.WriteLine($"The Biggest file in the queue {printQueue.Max(job => job.FileSize)}");
            Console.ReadLine();
        }
        static void FindItem()
        {
            Console.Clear();

            // Fanger bruger input så vi kan lede efter objektet i vores queue
            Console.WriteLine("Name of the item you want to find?");
            string filename = Console.ReadLine();

            // Udskriver det objekt som brugeren leder efter til skærmen, hvis det eksisterer i 
            foreach (PrinterJob item in printQueue)
            {
                if (filename == item.FileName)
                {
                    Console.WriteLine(item.FileName + "found.");
                }
            }
        }
        static void PrintAll()
        {
            Console.Clear();

            while (printQueue.Count > 0)
            {
                PrinterJob item = printQueue.Dequeue();

                // Her udskrives alle detaljer om objektet i printerkøen
                Console.WriteLine(item.FileName + "." + item.FileType + " " + item.FileSize + "kb - Is now being printed.");

                for (int i = 0; i < 20; i++)
                {
                    // System.Threading.Thread.Sleep benyttes til at sætte en timer imellem
                    // vores punktummer så vi kan simulere en loading proces
                    System.Threading.Thread.Sleep(200);
                    Console.Write(".");
                }
                Console.WriteLine(); 
            }

            //foreach (PrinterJob item in printQueue)
            //{
            //    // Her udskrives alle detaljer om objektet i printerkøen
            //    Console.WriteLine(item.FileName + "." + item.FileType + " " + item.FileSize + "kb - Is now being printed.");

            //    for (int i = 0; i < 20; i++)
            //    {
            //        // System.Threading.Thread.Sleep benyttes til at sætte en timer imellem
            //        // vores punktummer så vi kan simulere en loading proces
            //        System.Threading.Thread.Sleep(200);
            //        Console.Write(".");
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine("All items succesfully printed.");
            Console.ReadLine();
        }
        static void ExitMenu()
        {
            // Her opfanger vi brugerens ønske om at lukke applikationen
            string exit = Console.ReadLine();
            // Med Environment.Exit lukker vi det miljø vores applikation kører i
            // Vi er nød til at lave en Convert.ToInt32 da Environment.Exit kræver
            // en int data type for at kunne udføres
            Environment.Exit(Convert.ToInt32(exit));
        }
    }
}
