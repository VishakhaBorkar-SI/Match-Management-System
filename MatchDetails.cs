using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDetailsManagementSystem
{
    public class MatchDetails
    {
        public int MatchId;
        public string Sport { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string Location { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public MatchDetails() { }

        public MatchDetails(int matchId, string sport, DateTime matchDateTime, string location, string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            this.MatchId = matchId;
            this.Sport = sport;
            this.MatchDateTime = matchDateTime;
            this.Location = location;  
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.HomeTeamScore = homeTeamScore;
            this.AwayTeamScore = awayTeamScore;
        }
    }
}
