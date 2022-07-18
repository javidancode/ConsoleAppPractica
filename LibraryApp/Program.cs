using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace LibraryApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            LibraryService libraryService = new LibraryService();

            Helper.WriteConsole(ConsoleColor.Yellow,"Select one option :");
            Helper.WriteConsole(ConsoleColor.Blue,"1 - Create library, 2 - Get library by id, 3 - Update library, 4 - Delete library ");

            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();

                int SelectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out SelectTrueOption);

                if (isSelectOption)
                {
                    switch (SelectTrueOption)
                    {
                        case 1:

                            Helper.WriteConsole(ConsoleColor.Blue, "Add library name : ");
                            string libraryName = Console.ReadLine();

                            Helper.WriteConsole(ConsoleColor.Blue, "Add library seat count : ");
                            SeatCount: string librarySeatCount = Console.ReadLine();

                            int seatCount;

                            bool isSeatCount = int.TryParse(librarySeatCount, out seatCount);

                            if (isSeatCount)
                            {
                                Library library = new Library()
                                {
                                    Name = libraryName,
                                    SeatCount = seatCount
                                };

                                var result = libraryService.Create(library);
                                Helper.WriteConsole(ConsoleColor.Green, $"Library id : {result.Id}, Name : {result.Name}, Seat count : {result.SeatCount} ");
                            }
                            else
                            {
                                Helper.WriteConsole(ConsoleColor.Red, "Add correct seat count : ");
                                goto SeatCount;
                            }

                            break;
                        case 2:
                            Console.WriteLine(SelectTrueOption);
                            break;
                        case 3:
                            Console.WriteLine(SelectTrueOption);
                            break;
                        case 4:
                            Console.WriteLine(SelectTrueOption);
                            break;
                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number");
                            break;
                            
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option");
                    goto SelectOption;
                }
            }
        }
    }
}
