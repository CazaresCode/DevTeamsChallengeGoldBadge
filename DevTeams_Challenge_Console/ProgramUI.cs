using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamsRepo _repo = new DevTeamsRepo();

        public void Run()
        {
            SeedContentList();
            Menu();
        }

        private void Menu()
        {
            //Start with the main menu here

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" + // \n is a line break WITHIN the ""
                    "1. Create New Member\n" +
                    "2. View All Members\n" +
                    "3. View Member By First Name\n" +
                    "4. Update Existing Member\n" +
                    "5. Delete Existing Member \n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower()) //input is what we are going to evulate
                {
                    case "1":
                    case "one":
                    case "banana": // just showing you can type anything here
                        //CreateNewMember
                        CreateNewMember();
                        break;
                    case "2":
                    case "two":
                        //ViewAllMember
                        //DisplayAllMember();
                        break;
                    case "3":
                    case "three":
                        //View Content By Title
                        //View Member By First Name();
                        break;
                    case "4":
                    case "four":
                        //Update existing Member
                        //UpdateMember();
                        break;
                    case "5":
                    case "five":
                        //Delete existing Member
                        //DeleteMember();
                        break;
                    case "6":
                    case "six":
                        //exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a vaild number");
                        break;
                }

                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //CreateNewMember()
        private void CreateNewMember()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            //ID
            Console.WriteLine("What is the Developer's ID number? xxx");
            newDeveloper.ID = Convert.ToInt32(Console.ReadLine());

            //First Name
            Console.WriteLine("What is the first name of this member?");
            newDeveloper.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("What is the last name of this member?");
            newDeveloper.LastName = Console.ReadLine();

            //Team Assignment
            Console.WriteLine("Enter the number team is this member on?\n" +
                "1. FrontEnd\n" +
                "2. BackEnd\n" +
                "3. Testing\n");

            newDeveloper.TeamAssignment = (TeamAssignment)Convert.ToInt32(Console.ReadLine());

            //Below is another example of a shorter answer
            //string maturityRatingAsString = Console.ReadLine();
            //int maturityRatingAsInt = Convert.ToInt32(maturityRatingAsString);
            //newContent.MaturityRating = (MaturityRating)maturityRatingAsInt;


            bool wasAddedCorrectly = _repo.AddDeveloperToDirectory(newDeveloper); //this needs a field so we can access it. 
            if (wasAddedCorrectly)
            {
                Console.WriteLine("The member was added correctly.");
            }
            else
            {
                Console.WriteLine("Could not add the member.");
            }
        }

        private void SeedContentList()
        {
            Developer front = new Developer(007, "James", "Bond", TeamAssignment.FrontEnd);
            Developer back = new Developer(001, "Max", "Payne", TeamAssignment.BackEnd);
            Developer test = new Developer(002, "Jason", "Bourne", TeamAssignment.Testing);

            _repo.AddDeveloperToDirectory(front);
            _repo.AddDeveloperToDirectory(back);
            _repo.AddDeveloperToDirectory(test);
        }

    }
}
