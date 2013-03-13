using System.Collections.Generic;

namespace GoalLine.Dto
{
    public class TeamSchedule
    {
        public TeamSchedule()
        {
            Schedule = new List<GameDto>();
        }

        public string Name { get; set; }
        public List<GameDto> Schedule { get; set; }
    }
}
