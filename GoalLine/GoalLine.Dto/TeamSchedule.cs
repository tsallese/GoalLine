using System.Collections.Generic;

namespace GoalLine.Model
{
    public class TeamSchedule
    {
        public TeamSchedule()
        {
            Games = new List<Game>();
        }

        public string Name { get; set; }
        public List<Game> Games { get; set; }
        public int GameCount { get { return Games.Count; } }
    }
}
