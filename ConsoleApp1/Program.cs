using System;
using System.Runtime.CompilerServices;

/******************************************************************************************
 * Author Name: Camden Taylor
 * Last Edit Date: 12/11/25
 * Project Name: Amusement Park Ride Tracker
 *****************************************************************************************/

namespace Thrilladelphia
{
    // <summary>
    // Represents a single amusement park ride
    // </summary>
    internal class Ride
    {
        // Creates a ride with empty name and set default values
        public Ride()
        {
            _name = "";
            _frightFactor = 0;
            _costToEnter = 1.00;
            _visitorsToday = 0;
        }

        // <summary>
        // Creates a ride with supplied name, fright factor, cost, and amount of visitors
        // Greedy Constructor
        // </summary>
        public Ride(string name, int frightFactor,  double costToEnter, int visitorsToday)
        {
            Name = name;
            FrightFactor = frightFactor;
            CostToEnter = costToEnter;
            VisitorsToday = visitorsToday;
        }

        // Initialize
        private string _name = "";
        private int _frightFactor = 0;
        private double _costToEnter = 0;
        private int _visitorsToday = 0;

        // <summary>
        // Used to get and set the Ride's name
        // </summary>
        public string Name
        {
            get 
            { 
                return _name; 
            }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new Exception("Ride name cannot be blank.");
                }
                _name = value;
            }
        }

        // <summary> 
        // Used to get and set ride's fright factor.
        // </summary>
        public int FrightFactor
        {
            get
            {
                return _frightFactor;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Fright factor must be between 0 and 100");
                }
                _frightFactor = value;
            }
        }

        // <summary>
        // Used to get and set Cost to enter.
        // </summary>
        public double CostToEnter
        {
            get
            {
                return _costToEnter;
            }
            set
            {
                if (value < 1.00)
                {
                    throw new Exception("Cost to enter must be greater than 1.");
                }
                _costToEnter = value;
            }
        }

        // <summary>
        // Used to get and set count of Visitors today
        // </summary>
        public int VisitorsToday
        {
            get
            {
                return _visitorsToday;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Visitor count cannot be less than 0");
                }
                _visitorsToday = value;
            }
        }

        // <summary>
        // read only property PopularityScore that returns a double value based on a calculation
        // involving FrightFactor and Visitor count
        // </summary>
        public double PopularityScore
        {
            get
            {
                return ((FrightFactor / 10) * VisitorsToday);
            }
        }

        public void ShowPopularityScore()
        {
            Console.WriteLine($"\nPopularity: {PopularityScore}");
        }

        // <summary>
        // read only property ThrillLevel that returns a string based on FrightFactor value
        // </summary>
        public string ThrillLevel
        {
            get
            {
                if (FrightFactor <= 20)
                {
                    return "Mild";
                }
                else if (FrightFactor > 20 && FrightFactor < 61)
                {
                    return "Exciting";
                }
                else if (FrightFactor > 60 && FrightFactor < 91)
                {
                    return "Thrilling";
                }
                else
                {
                    return "Extreme";
                }
                    
            }
        }

        // <summary>
        // create a method to display thrill level of a specific ride
        // </summary>
        public void ShowThrillLevel()
        {
            Console.WriteLine($"\nThrill Level: {ThrillLevel}");
        }

        // <summary>
        // create a method called "RideDetails" that returns a list of variables
        // </summary>
        public void RideDetails()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RIDE DETAILS:\n");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fright Factor: {FrightFactor}");
            Console.WriteLine($"Cost: {CostToEnter:C}");
            Console.WriteLine($"Visitors Today: {VisitorsToday}");
            Console.WriteLine($"Thrill Level: {ThrillLevel}");
            Console.WriteLine($"Popularity: {PopularityScore}");
            Console.ResetColor();
        }
    }
    internal class Program
    {
        // <summary>
        // create a switch, recording user response and navigate accordingly
        // looping when user inputs an invalid response
        // </summary>
        private static void DisplayMainMenu(Ride ride)
        {
            string input;

                do 
                {
                    Console.WriteLine("Choose from the following options: ");
                    Console.WriteLine("[P] View Popularity Score");
                    Console.WriteLine("[T] View Thrill Level");
                    Console.WriteLine("[A] All ride details");
                    Console.Write("Enter your choice: ");
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "P":
                        case "p":
                            ride.ShowPopularityScore();
                           break;
                        case "T":
                        case "t":
                            ride.ShowThrillLevel();
                            break;
                        case "A":
                        case "a":
                            ride.RideDetails();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That wasn't a valid choice. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                while (input != null);

        }

        static void Main(string[] args)
        {
            string name;

            // <summary>
            // Prompt user for string, int, double and int, looping if the user enters an invalid input
            // </summary>
            do
            {
                Console.Write("Enter the ride name: ");
                name = Console.ReadLine();

                // <summary>
                // user enters nothing
                // </summary>
                if (string.IsNullOrEmpty(name))
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("String cannot be empty.");
                    Console.ResetColor();
                }
            }
            while (string.IsNullOrEmpty(name));

            int frightFactor;
            do
            {
                Console.Write("Enter the fright factor (0-100): ");
                string input = Console.ReadLine();

                // <summary>
                // checks string input from user and try to parse it into an int. If it can't because of invalid input, prints an error
                if (!int.TryParse(input, out frightFactor))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid: please enter a number without decimals: ");
                    Console.ResetColor();
                }
                // <summary>
                // if user enters a number smaller than 0 or larger than 100, print error
                // </summary>
                else if (frightFactor < 0 || frightFactor > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fright factor must be between 0 and 100, inclusive.");
                    Console.ResetColor();
                }
                // <summary>
                // valid entry, end loop
                // </summary>
                else
                {
                    break;
                }
            }
            while (true);
            
           
            Console.Write("Enter the cost to enter: ");
            double costToEnter = double.Parse(Console.ReadLine());
            Console.Write("Enter the # of visitors this ride had today: ");
            int visitorsToday = int.Parse(Console.ReadLine());

            Ride ride = new Ride(name, frightFactor, costToEnter, visitorsToday);

            DisplayMainMenu(ride);
        }
    }
}
