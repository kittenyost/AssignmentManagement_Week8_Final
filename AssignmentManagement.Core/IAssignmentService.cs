using System.Collections.Generic;
namespace AssignmentManagement.Core
{
    public interface IAssignmentService
    {
        bool AddAssignment(Assignment assignment);
        List<Assignment> ListAll();
        List<Assignment> ListIncomplete();
        List<string> ListFormatted();

        Assignment FindAssignmentByTitle(string title);
        bool UpdateAssignment(string title, string newTitle, string newDescription);
        bool DeleteAssignment(string title);
        bool MarkAssignmentComplete(string title);
    }
}