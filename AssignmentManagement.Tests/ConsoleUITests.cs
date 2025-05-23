
using Xunit;
using Moq;
using AssignmentManagement.Core;
using AssignmentManagement.UI; // Use UI, not Console
using System.IO;

namespace AssignmentManagement.Tests
{
    public class ConsoleUITests
    {
        [Fact]
        public void AddAssignment_Should_Call_Service_Add()
        {
            var mock = new Mock<IAssignmentService>();
            var ui = new ConsoleUI(mock.Object);

            using var input = new StringReader("1\nSample Title\nSample Description\nMedium\nSome notes\n0\n");
            System.Console.SetIn(input);

            ui.Run();

            mock.Verify(s => s.AddAssignment(It.Is<Assignment>(a =>
                a.Title == "Sample Title" &&
                a.Description == "Sample Description" &&
                a.Notes == "Some notes"
            )), Times.Once);
        }

        [Fact]
        public void SearchAssignmentByTitle_Should_Display_Assignment()
        {
            var mock = new Mock<IAssignmentService>();
            mock.Setup(s => s.FindAssignmentByTitle("Sample"))
                .Returns(new Assignment("Sample", "Details", DateTime.Today.AddDays(3), AssignmentPriority.Medium, "Test Notes"));

            var ui = new ConsoleUI(mock.Object);

            using var input = new StringReader("5\nSample\n0\n");
            System.Console.SetIn(input);

            ui.Run();

            mock.Verify(s => s.FindAssignmentByTitle("Sample"), Times.Once);
        }

        [Fact]
        public void DeleteAssignment_Should_Call_Service_Delete()
        {
            var mock = new Mock<IAssignmentService>();
            mock.Setup(s => s.DeleteAssignment("ToDelete")).Returns(true);

            var ui = new ConsoleUI(mock.Object);

            using var input = new StringReader("7\nToDelete\n0\n");
            System.Console.SetIn(input);

            ui.Run();

            mock.Verify(s => s.DeleteAssignment("ToDelete"), Times.Once);
        }
    }
}