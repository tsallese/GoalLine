using System;
using System.Collections.Generic;
using System.IO;
using GoalLine.Dto;

namespace GoalLine.BL
{
    public class Import
    {
        private const int GameDate = 0;
        private const int GameDay = 1;
        private const int GameTime = 2;
        private const int ByhTeam = 3;
        private const int GameLocation = 4;
        private const int EventType = 5;
        private const int Opponent = 6;
        private const int Notes = 7;
        private const int Confirmed = 8;

        public static List<MasterGameDto> FromFile(string fileName)
        {
            var reader = new StreamReader(File.OpenRead(fileName));
            var dtos = new List<MasterGameDto>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line == null) continue;
                var values = line.Split(',');

                if (string.IsNullOrEmpty(values[GameTime]) || string.IsNullOrEmpty(values[Opponent]) ||
                    string.IsNullOrEmpty(values[EventType]) || values[GameDate].Contains("DATE") ||
                    values[EventType].Contains("PRACTICE")) continue;

                var dto = new MasterGameDto
                    {
                        Date = values[GameDate],
                        Day = values[GameDay],
                        Time = values[GameTime],
                        ByhTeam = values[ByhTeam],
                        Location = values[GameLocation],
                        EventType = values[EventType],
                        Opponent = values[Opponent],
                        Notes = values[Notes],
                        Confirmed = values[Confirmed]
                    };

                dto.Date = DateTime.Parse(dto.Date).ToString("MM/dd/yyyy");
                dtos.Add(dto);
            }
            return dtos;
        }

        public static List<GameDto> ConvertMasterGameDto(List<MasterGameDto> masterGameDtos)
        {
            var gameDtos = new List<GameDto>();

            foreach (var masterGameDto in masterGameDtos)
            {
                var gameDto = new GameDto
                    {
                        ByhTeam = masterGameDto.ByhTeam,
                        Venue = masterGameDto.Location,
                        StartDate = masterGameDto.Date,
                        StartTime = masterGameDto.Time,
                        LeagueName = masterGameDto.EventType,
                        ScheduleName = masterGameDto.EventType,
                        Duration = "90",
                        Details = string.Empty,
                        ShowDetails = string.Empty,
                        PracticeType = string.Empty
                    };

                switch (gameDto.Venue.ToUpper())
                {
                    case "REISTERSTOWN":
                    case "MT PLEASANT":
                    case "PATTERSON PARK":
                        gameDto.HomeTeam = masterGameDto.ByhTeam;
                        gameDto.VisitorTeam = masterGameDto.Opponent;
                        break;
                    default:
                        gameDto.HomeTeam = masterGameDto.Opponent;
                        gameDto.VisitorTeam = masterGameDto.ByhTeam;
                        break;
                }

                gameDtos.Add(gameDto);

            }

            return gameDtos;
        }

        public static List<TeamSchedule> GenerateTeamSchedules(List<GameDto> gameDtos)
        {
            var teams = new List<TeamSchedule>();

            foreach (var gameDto in gameDtos)
            {
                var team = teams.Find(x => x.Name.Equals(gameDto.ByhTeam));

                if (team == null)
                {
                    team = new TeamSchedule {Name = gameDto.ByhTeam};
                    teams.Add(team);
                }
                team.Schedule.Add(gameDto);
            }

            IComparer<TeamSchedule> comparer = new TeamScheduleOrderring();
            teams.Sort(comparer);

            return teams;
        }
    }
}
