using System.ComponentModel.DataAnnotations;

namespace MatchDetailsManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatchManagement matchManager = new MatchManagement();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Display All Matches");
                Console.WriteLine("2. Display Match Details");
                Console.WriteLine("3. Update Match Score");
                Console.WriteLine("4. Remove a Match");
                Console.WriteLine("5. sort matches");
                Console.WriteLine("6. filter matches");
                Console.WriteLine("7. statistics");
                Console.WriteLine("8. search matches");
                Console.WriteLine("9. Add match");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        matchManager.DisplayAllMatches();
                        break;

                    case 2:
                        
                        Console.Write("Enter Match ID: ");
                        int matchIdToDisplay = int.Parse(Console.ReadLine());
                        matchManager.DisplayMatch(matchIdToDisplay);
                        break;

                    case 3:
                        // Update Match Score
                        Console.Write("Enter Match ID: ");
                        int matchIdToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("Enter Home Team Score: ");
                        int homeScore = int.Parse(Console.ReadLine());
                        Console.Write("Enter Away Team Score: ");
                        int awayScore = int.Parse(Console.ReadLine());
                        matchManager.UpdateDetails(matchIdToUpdate, homeScore, awayScore);
                        break;

                    case 4:
                        // Remove a Match
                        Console.Write("Enter Match ID to remove: ");
                        int matchIdToRemove = int.Parse(Console.ReadLine());
                        matchManager.RemoveMatch(matchIdToRemove);
                        break;

                    case 5:
                        // Sort Matches
                        Console.Write("Enter sorting criteria (MatchDate, Sport, Location): ");
                        string sortBy = Console.ReadLine();
                        Console.Write("Enter sorting order (Asc or Desc): ");
                        string sortOrder = Console.ReadLine();
                        matchManager.SortMatches(sortBy, sortOrder);
                        break;

                    case 6:
                        // Filter Matches
                        Console.Write("Enter filtering criteria (Sport, Location, DateRange): ");
                        string filterCriteria = Console.ReadLine();
                        Console.Write("Enter filter value: ");
                        string filterValue = Console.ReadLine();
                        matchManager.FilterMatches(filterCriteria, filterValue);
                        break;

                    case 7:
                        // Statistics
                        Console.WriteLine("Enter the criteria (averagescore, highestscore, lowestscore)");
                        string Criteria = Console.ReadLine();
                        matchManager.CalculateStatistics(Criteria);
                        break;
                        
                    case 8:
                        //search
                        Console.Write("Enter keywords for search: ");
                        string searchKeywords = Console.ReadLine();
                        matchManager.SearchMatches(searchKeywords);
                        break;

                    case 9:
                        //Add
                        MatchDetails match = new MatchDetails();
                        Console.WriteLine("Enter the match id");
                        match.MatchId=int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Sport");
                        match.Sport = Console.ReadLine();

                        Console.WriteLine("Enter the Date");
                        string input= Console.ReadLine();
                        DateTime.TryParse(input, out DateTime result);
                        match.MatchDateTime = result;

                        Console.WriteLine("Enter the Location");
                        match.Location = Console.ReadLine();

                        Console.WriteLine("Enter the Home Team");
                        match.HomeTeam = Console.ReadLine();

                        Console.WriteLine("Enter the Away Team");
                        match.AwayTeam = Console.ReadLine();

                        Console.WriteLine("Enter the Home Team Score");
                        match.HomeTeamScore = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Away Team Score");
                        match.AwayTeamScore = int.Parse(Console.ReadLine());

                        matchManager.AddMatch(match);

                        break;
                    case 10:
                        // Exit the program
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}