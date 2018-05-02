using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewLibrary;
using RestaurantReviewData;


namespace RestaurantReviewConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantReviewManager manager = new RestaurantReviewManager();

            Console.WriteLine("Enter Command");
            string userInput = Console.ReadLine();

            while(userInput.ToLower() != "q")
            {
                switch (userInput)
                {
                    case "cmd":
                    case "command":
                        Console.WriteLine("Print - Print all restaurant IDs and Names");
                        Console.WriteLine("Search - Search by partial restaurant name");
                        Console.WriteLine("Detail - Print details and Reviews for Restaurants by partial name");
                        Console.WriteLine("Top 3 - Print top three restaurants by average rating");
                        Console.WriteLine("Sort - Sort by name or rating, ascending or descending");
                        break;
                    case "print":
                        foreach(Restaurant res in manager.currentRestaurants)
                        {
                            Console.WriteLine(res.ID + " || " + res.Name);
                        }
                        break;
                    case "search":
                        Console.WriteLine("Enter Restaurant Name:");
                        string searchString = Console.ReadLine();
                        string searchResult = manager.SearchRestByName(searchString);
                        if(searchResult != null)
                        {
                            Console.WriteLine(searchResult);
                        }
                        else
                        {
                            Console.WriteLine("Could not find search term: " + searchString);
                        }
                        break;
                    case "detail":
                        Console.WriteLine("Enter Restaurant Name");
                        string searchName = Console.ReadLine();
                        string detailResult = manager.PrintRestaurantDetail(searchName);
                        if(detailResult != null)
                        {
                            Console.WriteLine(detailResult);
                        }
                        else
                        {
                            Console.WriteLine("Could not find search term: " + searchName);
                        }
                        break;
                    case "top three":
                    case "top 3":
                        Console.WriteLine(manager.PrintTopThree());
                        break;
                    case "sort":
                        Console.WriteLine("Enter Sort Parameters:");
                        string sortBy = Console.ReadLine();
                        switch (sortBy.ToLower())
                        {
                            case "average rating":
                            case "rating":
                                Console.WriteLine("Enter order:");
                                string order = Console.ReadLine();
                                foreach(Restaurant res in manager.SortByRating(order, manager.currentRestaurants))
                                {
                                    Console.WriteLine($"{res.ID} || {res.Name} || {res.AvgRating}\n");
                                };
                                break;
                            case "name":
                                Console.WriteLine("Enter order:");
                                string nameOrder = Console.ReadLine();
                                Console.WriteLine(manager.SortByName(nameOrder, manager.currentRestaurants));
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Unrecognized command.");
                        break;
                    
                }
                Console.WriteLine("Enter next command: ");
                userInput = Console.ReadLine();
            }
        }
    }
}
