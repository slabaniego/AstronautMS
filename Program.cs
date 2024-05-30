using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Xml;

namespace A1ShaneeLabaniego
{
    class Program
    {
        static int astronautCounter = 1;
        static int missionCounter = 1;
        static List<Astronaut> astronauts = new List<Astronaut>()
        {
            // Add data to astronauts 
            new Commander(astronautCounter++, "Stark"),
            new Pilot(astronautCounter++, "Hulk"),
            new Scientist(astronautCounter++, "Parker")
        };
        static List<Mission> missions = new List<Mission>()
        {
            // Add data to missions 
            new Mission (missionCounter++, "Go to the moon", new DateTime(2026,02,05), 431),
            new Mission (missionCounter++, "Harvest sedimentary samples on Mars", new DateTime(2028, 12, 25), 123)
        };


        public static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1. Add Astronaut\n" +
                             "2. Edit Astronaut\n" +
                             "3. Delete Astronaut\n" +
                             "4. View Astronauts\n" +
                             "5. Search Astronaut\n" +
                             "6. Add Mission\n" +
                             "7. Edit Mission\n" +
                             "8. Delete Mission\n" +
                             "9. View Missions\n" +
                             "10. Assign Astronaut to Mission\n" +
                             "11. Exit\n");
                Console.Write("Pick a number for desired action: ");

                int i;
                string option = Console.ReadLine();
                bool choice = int.TryParse(option, out i);


                if (choice) // if user input numeric
                {
                    switch (Int32.Parse(option))
                    {
                        case 1:
                            AddAstronaut();
                            break;
                        case 2:
                            EditAstronaut();
                            break;
                        case 3:
                            DeleteAstronaut();
                            break;
                        case 4:
                            ViewAstronauts();
                            break;
                        case 5:
                            SearchAstronaut();
                            break;
                        case 6:
                            AddMission();
                            break;
                        case 7:
                            EditMission();
                            break;
                        case 8:
                            DeleteMission();
                            break;
                        case 9:
                            ViewMissions();
                            break;
                        case 10:
                            AssignAstronautToMission();
                            break;
                        case 11:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Press any key to try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        // Add Astronaut
        private static void AddAstronaut()
        {
            Console.Clear();
            Console.WriteLine("ADD ASTRONAUT\n" +
                        "1. Commander\n" +
                        "2. Pilot\n" +
                        "3. Scientist\n" +
                        "4. Engineer\n" +
                        "5. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int i;
            string option = Console.ReadLine();
            bool choice = int.TryParse(option, out i);

            if (choice) // if user input is numeric 
            {
                if (Int32.Parse(option) >= 1 && Int32.Parse(option) <= 4)
                {
                    Console.WriteLine("Enter name: ");
                    string name = Console.ReadLine();

                    // Reference type null will change later to be populated 
                    Astronaut astronaut = null;
                    switch (Int32.Parse(option))
                    {
                        case 1: // Add new commander and inc
                            astronaut = new Commander(astronautCounter++, name);
                            break;
                        case 2: // Add new pilot and inc
                            astronaut = new Pilot(astronautCounter++, name);
                            break;
                        case 3: // Add new scientist and inc
                            astronaut = new Scientist(astronautCounter++, name);
                            break;
                        case 4: // Add new engineer and inc
                            astronaut = new Engineer(astronautCounter++, name);
                            break;
                        case 5: // Back to main menu
                        default:
                            break;
                    }
                    // If astronaut's data populated, user is validated of success 
                    if (astronaut != null)
                    {
                        astronauts.Add(astronaut);
                        Console.WriteLine("Astronaut added successfully!\nPress enter to go back to menu.");
                    }
                    // if invalid user input, ask user to try again
                }
                else if (Int32.Parse(option) < 1 || Int32.Parse(option) > 5)
                {
                    Console.WriteLine("Invalid choice! Press any key to try again...");
                }
            }
            Console.ReadKey();
        }

        // Edit astronaut
        private static void EditAstronaut()
        {
            Console.Clear();
            Console.WriteLine("EDIT ASTRONAUT");
            ViewAstronauts();

            Console.Write("Enter the ID of the astronaut to edit: ");
            bool austroId = int.TryParse(Console.ReadLine(), out int id);
            if (austroId)
            {
                Astronaut astronaut = astronauts.FirstOrDefault(a => a.ID == id);
                if (astronaut != null)
                {
                    Console.Write("Enter new name: ");
                    astronaut.Name = Console.ReadLine();
                    Console.WriteLine("Astronaut updated successfully!\nPress enter to go back to menu.");
                }
                // If id does not exist astronaut not found
                else
                {
                    Console.WriteLine("Astronaut not found!");
                }
            }
            // if user input invalid, ask to try again
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }
            Console.ReadKey();
        }

        // Delete astronaut
        private static void DeleteAstronaut()
        {
            Console.Clear();
            Console.WriteLine("DELETE ASTRONAUT");
            ViewAstronauts();
            Console.WriteLine("Enter ID of astronaut to be deleted: ");

            bool astroId = int.TryParse(Console.ReadLine(), out int id);
            if (astroId) // If ID is numeric 
            {
                Astronaut astronaut = astronauts.FirstOrDefault(a => a.ID == id);
                if (astronaut != null) // If ID exists, remove astronaut from list
                {
                    astronauts.Remove(astronaut);
                    Console.WriteLine("Astronaut deleted successfully!\nPress enter to go back to menu.");
                }
                else // If ID does not exist 
                {
                    Console.WriteLine("Astronaut not found!");
                }
            }
            else // If ID is non-numeric 
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }

            Console.ReadKey();
        }

        // View Astronauts 
        private static void ViewAstronauts()
        {
            Console.Clear();
            Console.Write("VIEW ASTRONAUTS\n");
            foreach (var astronaut in astronauts)
            {
                Console.WriteLine(astronaut);
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            Console.WriteLine("");
        }

        // Search Astronaut by name
        private static void SearchAstronaut()
        {
            Console.WriteLine("SEARCH AN ASTRONAUT");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            // Search names of astronauts compared to user input's string
            var results = astronauts.Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            // If results exist
            if (results.Count > 0)
            {
                foreach (var astronaut in results)
                {
                    Console.WriteLine(astronaut);
                }
            }
            else
            {
                Console.WriteLine("No astronauts found.");
            }
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        // Add mission 
        private static void AddMission()
        {

            Console.WriteLine("ADD MISSION");

            // Enter mission name
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            // Enter launch date 
            Console.Write("Enter launch date (YYYY-MM-DD): ");
            DateTime launchDate = DateTime.Parse(Console.ReadLine());

            // Enter length of mission
            Console.Write("Enter duration (days): ");
            int duration = int.Parse(Console.ReadLine());

            // Create new mission
            Mission mission = new Mission(missionCounter++, name, launchDate, duration);
            // Add mission to list
            missions.Add(mission);

            Console.WriteLine("Mission added successfully!");
            Console.ReadKey();
        }

        // Edit mission 
        private static void EditMission()
        {

            Console.WriteLine("EDIT MISSION");
            ViewMissions();

            Console.Write("Enter the ID of the mission to edit: ");
            bool austroId = int.TryParse(Console.ReadLine(), out int id);
            if (austroId)
            {
                // Search muission with specified ID 
                Mission mission = missions.FirstOrDefault(m => m.ID == id);

                // If mission found, user can edit
                if (mission != null)
                {
                    Console.Write("Enter new name: ");
                    mission.Name = Console.ReadLine();

                    Console.Write("Enter new launch date (YYYY-MM-DD): ");
                    mission.LaunchDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter new duration (days): ");
                    mission.Duration = int.Parse(Console.ReadLine());

                    Console.WriteLine("Mission updated successfully!");
                }
                else
                {
                    Console.WriteLine("Mission not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }

            Console.ReadKey();
        }

        // Delete Mission 
        static void DeleteMission()
        {

            Console.WriteLine("DELETE MISSION");
            ViewMissions();

            Console.Write("Enter the ID of the mission to delete: ");
            bool austroId = int.TryParse(Console.ReadLine(), out int id);
            if (austroId)
            {
                // Search mission based on ID
                Mission mission = missions.FirstOrDefault(m => m.ID == id);

                // If mission ID exists, allow to delete
                if (mission != null)
                {
                    missions.Remove(mission);
                    Console.WriteLine("Mission deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Mission not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }

            Console.ReadKey();
        }

        // View Missions
        static void ViewMissions()
        {

            Console.WriteLine("VIEW MISSIONS");
            foreach (var mission in missions)
            {
                Console.WriteLine(mission);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Assign astronaut to a mission
        static void AssignAstronautToMission()
        {

            Console.WriteLine("ASSIGN ASTRONAUT TO MISSION");
            // Display missions
            ViewMissions();
            Console.Write("Enter the ID of the mission: ");
            // Return true of user input is numeric 
            bool missId = int.TryParse(Console.ReadLine(), out int missionId);
            if (missId)
            {
                // Search by mission ID
                Mission mission = missions.FirstOrDefault(m => m.ID == missionId);

                // If mission exists, allow to assign astronaut
                if (mission != null)
                {
                    ViewAstronauts();
                    Console.Write("Enter the ID of the astronaut to assign: ");
                    bool austroId = int.TryParse(Console.ReadLine(), out int austronautId);
                    if (austroId)
                    {
                        // Search astronaut by ID
                        Astronaut astronaut = astronauts.FirstOrDefault(a => a.ID == austronautId);

                        // If astronaut found, allow assignment
                        if (astronaut != null)
                        {
                            mission.AssignedAstronauts.Add(astronaut);
                            Console.WriteLine("Astronaut assigned to mission successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Astronaut not found!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID! Press any key to try again...");
                    }
                }
                else
                {
                    Console.WriteLine("Mission not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID! Press any key to try again...");
            }
            Console.ReadKey();
        }// End of assign astronaut method

    }// End of class

}// End of namespace