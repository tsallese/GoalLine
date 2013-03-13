using System;
using System.Collections.Generic;

namespace GoalLine.Dto
{
    public class TeamScheduleOrderring: IComparer<TeamSchedule>
    {
        public int Compare(TeamSchedule x, TeamSchedule y)
        {
            return String.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
