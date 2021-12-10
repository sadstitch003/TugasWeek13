using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        public static void tampilkanMenu()
        {
            Console.WriteLine(" 1. My Scroll list");
            Console.WriteLine(" 2. Add scroll");
            Console.WriteLine(" 3. Search scroll");
            Console.WriteLine(" 4. Remove scroll");
            Console.WriteLine(" Choose what to do : ");
        }
        public static void tampilkanScroll(List<string> scrolls)
        {
            Console.WriteLine("Scroll to learn list : ");
            for (int i = 0; i < scrolls.Count; i++)
                Console.WriteLine($"Scroll {i + 1}: {scrolls[i]}");
        }
        static void Main(string[] args)
        {
            List<string> scrolls = new List<string>() { "Book of Peace", "Scroll of Swords", "Silence Guide Book" };

            while (true)
            {
                tampilkanMenu();
                var menu = Convert.ToInt16(Console.ReadLine());

                Console.Clear();
                if (menu == 1)
                    tampilkanScroll(scrolls);
                else if (menu == 2)
                {
                    Console.WriteLine("How many scroll to add:");
                    var jumlahScroll = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("In what number of queue ?");
                    var indexInput = Convert.ToInt32(Console.ReadLine());

                    if (indexInput < 0)
                        indexInput = 1;
                    else if (indexInput > scrolls.Count + 1)
                        indexInput = scrolls.Count + 1;
                    for (int i = 0; i < jumlahScroll; i++)
                    {
                        Console.WriteLine($"Scroll {i + 1} name:");
                        var scrollName = Console.ReadLine();
                        scrolls.Insert(indexInput - 1, scrollName);
                        indexInput++;
                    }
                }
                else if (menu == 3)
                {
                    Console.WriteLine("Insert scroll name : ");
                    var searchScroll = Console.ReadLine();

                    var scrollNotFound = true;
                    foreach (var scroll in scrolls)
                        if (searchScroll.ToLower() == scroll.ToLower())
                        {
                            Console.WriteLine($"Book Found. Queue : {scrolls.IndexOf(scroll) + 1}");
                            scrollNotFound = false;
                        }
                    if (scrollNotFound) Console.WriteLine("Book not found");
                }
                else if (menu == 4)
                {
                    var pilihanRemove = "0";
                    while (pilihanRemove != "y" && pilihanRemove != "n")
                    {
                        Console.WriteLine("Remove from list by scroll name ? Y/N :");
                        pilihanRemove = Console.ReadLine().ToLower();

                        if (pilihanRemove != "y" && pilihanRemove != "n")
                            Console.WriteLine("Wrong selection. Choose again !");
                    }

                    if (pilihanRemove == "y")
                    {
                        Console.WriteLine("Input scroll name :");
                        var scrollRemove = Console.ReadLine();

                        var scrollNameNotFound = true;
                        for (int i = 0; i < scrolls.Count; i++)
                            if (scrollRemove.ToLower() == scrolls[i].ToLower())
                            {
                                Console.WriteLine("Book Removed!");
                                scrolls.RemoveAt(i);
                                scrollNameNotFound = false;
                            }
                        if (scrollNameNotFound) Console.WriteLine("Book not found");
                    }
                    else if(pilihanRemove == "n")
                    {
                        Console.WriteLine("Input scroll queue :");

                        var scrollNumber = -1;
                        while (scrollNumber > scrolls.Count || scrollNumber < 0)
                        {
                            scrollNumber = Convert.ToInt16(Console.ReadLine());
                            if (scrollNumber > scrolls.Count || scrollNumber <= 0)
                                Console.WriteLine("Queue not found. Insert scroll queue :");
                        }
                        scrolls.RemoveAt(scrollNumber - 1);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}