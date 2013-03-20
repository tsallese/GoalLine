using System.Collections.Generic;

namespace GoalLine.Model
{
    public class TeamSchedule
    {
        public TeamSchedule()
        {
            Schedule = new List<Game>();
        }

        public string Name { get; set; }
        public List<Game> Schedule { get; set; }
        public int GameCount { get { return Schedule.Count; } }
    }
}
