using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoalLine.BL.Test
{
    [TestClass]
    public class UnitTest1
    {
        private const string FileName = @"C:\Projects\GoalLine\Import\BYH MASTER SCHEDULE.csv";

        [TestMethod]
        public void TestMasterGameImport()
        {
            var dtos = Import.FromFile(FileName);

            Assert.AreNotEqual(0,dtos.Count,"No records imported.");
        }

        [TestMethod]
        public void TestConvertMaster()
        {
            var masterDtos = Import.FromFile(FileName);

            Assert.AreNotEqual(0, masterDtos.Count, "No master schedule records imported.");

            var gameDtos = Import.ConvertMasterGameDto(masterDtos);

            Assert.AreEqual(masterDtos.Count, gameDtos.Count, "No master schedule records converted.");
        }

        [TestMethod]
        public void TestGenerateTeamSchedules()
        {
            var masterDtos = Import.FromFile(FileName);

            Assert.AreNotEqual(0, masterDtos.Count, "No master schedule records imported.");

            var gameDtos = Import.ConvertMasterGameDto(masterDtos);

            Assert.AreEqual(masterDtos.Count, gameDtos.Count, "No master schedule records converted.");

            var teams = Import.GenerateTeamSchedules(gameDtos);

            Assert.AreNotEqual(0, teams.Count, "No team schedule records generated.");
        }

        [TestMethod]
        public void TestGenerateTeamSchedulesImport()
        {
            var teams = Import.GenerateTeamSchedules(FileName);

            Assert.AreNotEqual(0, teams.Count, "No team schedule records generated.");
        }
    }
}
