using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
                if (value > 100 || value < 0)
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
        // create a method called "RideDetails" that returns a list of variables
        // </summary>
        public string RideDetails()
        {
            Console.WriteLine("RIDE DETAILS:\n");
            return
                $"{"Name: "}{Name}\n" +
                $"{"Fright Factor: "}{FrightFactor}\n" +
                $"{"Cost: "}{CostToEnter:C}\n" +
                $"{"Visitors Today: "}{VisitorsToday}\n" +
                $"{"Thrill Level: "}{ThrillLevel}\n" +
                $"{"Popularity Score: "}{PopularityScore}";
        } 

        public static Ride CreateRide()
        {
            Console.Write("Enter the ride name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the Fright Factor (0-100): ");
            int frightFactor = int.Parse(Console.ReadLine());

            Console.Write("Enter the ride's cost to enter: ");
            double costToEnter = double.Parse(Console.ReadLine());

            Console.Write("Enter the # of visitors this ride had today: ");
            int visitorsToday = int.Parse(Console.ReadLine());

            return new Ride
            {
                Name = name,
                FrightFactor = frightFactor,
                CostToEnter = costToEnter,
                VisitorsToday = visitorsToday
            };
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Ride newRide = Ride.CreateRide();
        }
    }
}
