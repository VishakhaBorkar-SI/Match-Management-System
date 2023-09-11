using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDetailsManagementSystem
{
    public class MatchManagement
    {

        List<MatchDetails> matches = new List<MatchDetails>() {
            new MatchDetails(1, "Cricket", new DateTime(2013, 10, 2), "Mumbai", "MI", "CSK", 1, 2),
            new MatchDetails(2, "Football", new DateTime(2001, 10, 2), "Delhi", "FC Barcelona", "Real Madrid", 1, 2),
            new MatchDetails(3, "Volleyball", new DateTime(2017, 10, 2), "Mumbai", "Mumbai", "Delhi", 1, 2),
            new MatchDetails(4, "Squash", new DateTime(2010, 10, 2), "Ahmedabad", "Kolkata", "Bangalore", 1, 2),
            new MatchDetails(5, "BasketBall", new DateTime(2006, 10, 2), "Mumbai", "Miami", "Florida", 1, 2),
            new MatchDetails(6, "Cricket", new DateTime(2009, 10, 2), "Mumbai", "Chennai", "Kolkata", 1, 2),
        };
        

        public void AddMatch(MatchDetails match)
        {
            if (validation(match))
            {   
                matches.Add(match);
            }
        }

        //====== display All matches =======
        public void DisplayAllMatches()
        {
            foreach (var match in matches)
            {
                Console.WriteLine($"Match Id : {match.MatchId}");
                Console.WriteLine($"Sport : {match.Sport}");
                Console.WriteLine($"Match Date time : {match.MatchDateTime}");
                Console.WriteLine($"Match Location : {match.Location}");
                Console.WriteLine($"Match HomeTeam : {match.HomeTeam}");
                Console.WriteLine($"Match AwayTeam : {match.AwayTeam}");
                Console.WriteLine($"Match HomeTeamScore : {match.HomeTeamScore}");
                Console.WriteLine($"Match AwayTeamScore : {match.AwayTeamScore}");
                Console.WriteLine();
            }
        }

        //====== display matches =======
        public void DisplayMatch(int matchId)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);

            if (match != null)
            {
                Console.WriteLine($"Match Id : {match.MatchId}");
                Console.WriteLine($"Sport : {match.Sport}");
                Console.WriteLine($"Date time : {match.MatchDateTime}");
                Console.WriteLine($"Location : {match.Location}");
                Console.WriteLine($"HomeTeam : {match.HomeTeam}");
                Console.WriteLine($"AwayTeam : {match.AwayTeam}");
                Console.WriteLine($"HomeTeamScore : {match.HomeTeamScore}");
                Console.WriteLine($"AwayTeamScore : {match.AwayTeamScore}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("id is not found");
            }
        }

        //====== Update matches =======
        public void UpdateDetails(int matchId, int homeTeamScore, int awayTeamScore)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);

            if (match != null )
            {
                match.HomeTeamScore = homeTeamScore;
                match.AwayTeamScore = awayTeamScore;
                Console.WriteLine($"score of id {matchId} is successfully updated");
            }
            else
            {
                Console.WriteLine($"id {matchId} is not found");
            }
        }

        //====== Remove matches =======
        public void RemoveMatch(int matchId)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);
            if (match != null)
            {
                matches.Remove(match);
                Console.WriteLine($"id {matchId} removed successfully");
            }
            else
            {
                Console.WriteLine($"id {matchId} is not found");
            }
        }

        //====== Remove matches =======
        public void SortMatches(string sortBy, string sortOrder)
        {
            IEnumerable<MatchDetails> sortedMatches = matches;


            if (sortBy == "MatchDate")
            {
                sortedMatches = sortOrder == "Asc"
                ? sortedMatches.OrderBy(m => m.MatchDateTime)
                : sortedMatches.OrderByDescending(m => m.MatchDateTime);
            }
            else if (sortBy == "Sport")
            {
                sortedMatches = sortOrder == "Asc"
                ? sortedMatches.OrderBy(m => m.Sport)
                : sortedMatches.OrderByDescending(m => m.Sport);
            }
            else if (sortBy == "Location")
            {
                sortedMatches = sortOrder == "Asc"
                ? sortedMatches.OrderBy(m => m.Location)
                : sortedMatches.OrderByDescending(m => m.Location);
            }
            else
            {
                Console.WriteLine("Invalid sorting criteria.");
            }


            Console.WriteLine("Sorted Matches:");
            foreach (var match in sortedMatches)
            {
                DisplayMatch(match.MatchId);
            }
        }

        //====== filter matches =======
        public void FilterMatches(string filterCriteria, string filterValue)
        {
            IEnumerable<MatchDetails> filteredMatches = matches;

            switch (filterCriteria)
            {
                case "Sport":
                    filteredMatches = filteredMatches.Where(m => m.Sport.Equals(filterValue, StringComparison.OrdinalIgnoreCase));
                    break;

                case "Location":
                    filteredMatches = filteredMatches.Where(m => m.Location.Equals(filterValue, StringComparison.OrdinalIgnoreCase));
                    break;

                case "DateRange":
                    DateTime fromDate;
                    DateTime toDate;

                    
                    Console.WriteLine("Enter the to date")
                    string r1=Console.ReadLine();
                    
                    if (DateTime.TryParse(filterValue, out fromDate) && DateTime.TryParse(r1, out toDate))
                    {
                        filteredMatches = filteredMatches.Where(m => m.MatchDateTime >= fromDate && m.MatchDateTime <= toDate);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Date range filtering aborted.");
                        return;
                    }
                    break;
                    /*
                if (DateTime.TryParse(filterValue, out fromDate) && DateTime.TryParse(Console.ReadLine(), out toDate))
                {
                    filteredMatches = filteredMatches.Where(m => m.MatchDateTime >= fromDate && m.MatchDateTime <= toDate);
                }
                else
                {
                    Console.WriteLine("Invalid date format. Date range filtering aborted.");
                    return;
                }                  
                break;
                */
                default:
                    Console.WriteLine("Invalid filtering criteria.");
                    return;
            }

            Console.WriteLine("Filtered Matches:");
            foreach (var match in filteredMatches)
            {
                DisplayMatch(match.MatchId);
            }
        }

        //====== search matches =======
        public void SearchMatches(string keywords)
        {
            var searchResults = matches
                .Where(match =>
                    match.Sport.Contains(keywords, StringComparison.OrdinalIgnoreCase) ||
                    match.HomeTeam.Contains(keywords, StringComparison.OrdinalIgnoreCase) ||
                    match.AwayTeam.Contains(keywords, StringComparison.OrdinalIgnoreCase) ||
                    match.Location.Contains(keywords, StringComparison.OrdinalIgnoreCase)
                );

            Console.WriteLine("Search Results:");
            foreach (var match in searchResults)
            {
                DisplayMatch(match.MatchId);
            }
        }

        //============== validation ========================
        public bool validation(MatchDetails match)
        {
            if (match.MatchId <= 0 || matches.Any(m => m.MatchId == match.MatchId))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(match.Sport))
            {
                Console.WriteLine("Sport must not be empty.");
                return false;
            }

            if (match.MatchDateTime <= DateTime.Now)
            {
                Console.WriteLine("Match date and time must be in the future.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(match.Location))
            {
                Console.WriteLine("Location must not be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(match.HomeTeam) || string.IsNullOrWhiteSpace(match.AwayTeam) || match.HomeTeam == match.AwayTeam)
            {
                Console.WriteLine("Home and away teams must not be empty or the same.");
                return false;
            }

            if (match.HomeTeamScore < 0 || match.AwayTeamScore < 0)
            {
                Console.WriteLine("Scores must be non-negative integers.");
                return false;
            }
            return true;
        }


        //====== statistics=============

        public void CalculateStatistics(string criteria)
        {
            switch (criteria.ToLower())
            {
                case "averagescore":
                    double homeAvg = matches.Average(m => m.HomeTeamScore);
                    double awayAvg = matches.Average(m => m.AwayTeamScore);
                    Console.WriteLine($"Average Score - Home: {homeAvg}, Away: {awayAvg}");
                    break;
                case "highestscore":
                    int highestHomeScore = matches.Max(m => m.HomeTeamScore);
                    int highestAwayScore = matches.Max(m => m.AwayTeamScore);
                    Console.WriteLine($"Highest Score - Home: {highestHomeScore}, Away: {highestAwayScore}");
                    break;
                case "lowestscore":
                    int lowestHomeScore = matches.Min(m => m.HomeTeamScore);
                    int lowestAwayScore = matches.Min(m => m.AwayTeamScore);
                    Console.WriteLine($"Lowest Score - Home: {lowestHomeScore}, Away: {lowestAwayScore}");
                    break;
                default:
                    Console.WriteLine("Invalid statistics criteria.");
                    break;
            }
        }       
    }
}
