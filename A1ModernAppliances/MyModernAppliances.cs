using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            long itemNumber;

            // Get user input as string and assign to variable.
            string userInput = Console.ReadLine();

            // Convert user input from string to long and store as item number variable.
            if (!long.TryParse(userInput, out itemNumber))
            {
                Console.WriteLine("Invalid item number format.");
                return;
            }

            // Create 'foundAppliance' variable to hold appliance with item number
            Appliance foundAppliance = null;

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test appliance item number equals entered item number
                if (appliance.ItemNumber == itemNumber)
                {
                    // Assign appliance in list to foundAppliance variable
                    foundAppliance = appliance;

                    // Break out of loop (since we found what we need)
                    break;
                }
            }

            // Test appliance was not found (foundAppliance is null)
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                // Test found appliance is available
                if (foundAppliance.IsAvailable)
                {
                    // Checkout found appliance
                    foundAppliance.Checkout();

                    // Write "Appliance "item number" has been checked out."
                    Console.WriteLine($"Appliance {itemNumber} has been checked out.");
                }
                else
                {
                    // Otherwise (appliance isn't available)
                    // Write "The appliance is not available to be checked out."
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to search for:");

            // Create string variable to hold entered brand
            string brandToSearch = Console.ReadLine();

            // Create list to hold found Appliance objects
            List<Appliance> foundAppliances = new List<Appliance>();

            // Iterate through loaded appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test current appliance brand matches what user entered
                if (appliance.Brand == brandToSearch)
                {
                    // Add current appliance in list to found list
                    foundAppliances.Add(appliance);
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options:");

            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");

            // Write "Enter number of doors: "
            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors), or 4 (four doors): ");

            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();

            // Convert user input from string to int and store as number of doors variable
            if (!int.TryParse(userInput, out int numberOfDoors))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            // Create list to hold found Appliance objects
            List<Appliance> foundRefrigerators = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Test that current appliance is a refrigerator
                if (appliance is Refrigerator refrigerator)
                {
                    // Test user entered 0 or refrigerator doors equals what user entered
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        // Add current appliance to found list
                        foundRefrigerators.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(foundRefrigerators, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options for grade:"
            Console.WriteLine("Possible options for grade:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");

            // Write "Enter grade:"
            Console.WriteLine("Enter grade:");

            // Get user input as string and assign to variable
            string gradeInput = Console.ReadLine();

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string grade;

            // Test input is "0"
            if (gradeInput == "0")
            {
                grade = "Any";
            }
            // Test input is "1"
            else if (gradeInput == "1")
            {
                grade = "Residential";
            }
            // Test input is "2"
            else if (gradeInput == "2")
            {
                grade = "Commercial";
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling (previous) method
                return;
            }

            // Write "Enter battery voltage value. 18 V (low) or 24 V (high):"
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high):");

            // Get user input as string and assign to variable
            string voltageInput = Console.ReadLine();

            // Create variable to hold voltage
            short voltage;

            // Test input is "18"
            if (voltageInput == "18")
            {
                voltage = 18;
            }
            // Test input is "24"
            else if (voltageInput == "24")
            {
                voltage = 24;
            }
            // Otherwise
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling (previous) method
                return;
            }

            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (Appliance appliance in Appliances)
            {
                // Check if current appliance is vacuum
                if (appliance is Vacuum)
                {
                    // Down cast current Appliance to Vacuum object
                    Vacuum vacuum = (Vacuum)appliance;

                    // Test grade is "Any" or grade is equal to current vacuum grade
                    // and voltage is 0 or voltage is equal to current vacuum voltage
                    if ((grade == "Any" || vacuum.Grade == grade) &&
                        (voltage == 0 || vacuum.BatteryVoltage == voltage))
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Room where the microwave will be installed: K (kitchen) or W (work site):"
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");

            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();

            // Create character variable that holds room type
            char roomType;

            // Test input is "K" or "k"
            if (userInput.Equals("K", StringComparison.OrdinalIgnoreCase))
            {
                // Assign 'K' to room type variable
                roomType = 'K';
            }
            // Test input is "W" or "w"
            else if (userInput.Equals("W", StringComparison.OrdinalIgnoreCase))
            {
                // Assign 'W' to room type variable
                roomType = 'W';
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");

                // Return to calling method
                return;
            }

            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            foreach (var appliance in Appliances)
            {
                // Test current appliance is Microwave
                if (appliance is Microwave microwave)
                {
                    // Test room type equals 'A' or microwave room type
                    if (roomType == 'A' || microwave.RoomType == roomType)
                    {
                        // Add current appliance in list to found list
                        found.Add(appliance);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):"
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");

            // Get user input as string and assign to variable
            string userInput = Console.ReadLine();

            // Create variable that holds sound rating
            string soundRating;

            // Test input is "Qt"
            if (userInput == "Qt")
            {
                // Assign "Qt" to sound rating variable
                soundRating = "Qt";
            }
            // Test input is "Qr"
            else if (userInput == "Qr")
            {
                // Assign "Qr" to sound rating variable
                soundRating = "Qr";
            }
            // Test input is "Qu"
            else if (userInput == "Qu")
            {
                // Assign "Qu" to sound rating variable
                soundRating = "Qu";
            }
            // Test input is "M"
            else if (userInput == "M")
            {
                // Assign "M" to sound rating variable
                soundRating = "M";
            }
            // Otherwise (input is something else)
            else
            {
                // Write "Invalid option."
                Console.WriteLine("Invalid option.");
                // Return to calling method
                return;
            }

            // Create variable that holds list of found appliances
            List<Appliance> foundAppliances = new List<Appliance>();

            // Loop through Appliances
            foreach (var appliance in Appliances)
            {
                // Test if current appliance is dishwasher
                if (appliance is Dishwasher)
                {
                    // Down cast current Appliance to Dishwasher
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    // Test sound rating is "Any" or equals sound rating for current dishwasher
                    if (soundRating == "Any" || dishwasher.SoundRating == soundRating)
                    {
                        // Add current appliance in list to found list
                        foundAppliances.Add(appliance);
                    }
                }
            }

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Enter number of appliances: "
            Console.WriteLine("Enter number of appliances: ");

            // Get user input as string and assign to variable
            string numAppliancesInput = Console.ReadLine();

            // Convert user input from string to int
            int numAppliances = int.Parse(numAppliancesInput);

            // Create variable to hold list of found appliances
            List<Appliance> foundAppliances = new List<Appliance>();

            // Loop through appliances
            foreach (var appliance in Appliances)
            {
                // Add current appliance in list to found list
                foundAppliances.Add(appliance);
            }

            // Randomize list of found appliances
            foundAppliances.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(foundAppliances, numAppliances);
        }
    }
}
