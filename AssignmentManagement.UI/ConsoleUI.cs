using AssignmentManagement.Core;
using System;

namespace AssignmentManagement.UI
{
    public class ConsoleUI
    {
        private readonly IAssignmentService _assignmentService;

        public ConsoleUI(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nAssignment Manager Menu:");
                Console.WriteLine("1. Add Assignment");
                Console.WriteLine("2. List All Assignments");
                Console.WriteLine("3. List Incomplete Assignments");
                Console.WriteLine("4. Mark Assignment as Complete");
                Console.WriteLine("5. Search Assignment by Title");
                Console.WriteLine("6. Update Assignment");
                Console.WriteLine("7. Delete Assignment");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAssignment();
                        break;
                    case "2":
                        ListAllAssignments();
                        break;
                    case "3":
                        ListIncompleteAssignments();
                        break;
                    case "4":
                        MarkAssignmentComplete();
                        break;
                    case "5":
                        SearchAssignmentByTitle();
                        break;
                    case "6":
                        UpdateAssignment();
                        break;
                    case "7":
                        DeleteAssignment();
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void AddAssignment()
        {
            Console.Write("Enter assignment title: ");
            var title = Console.ReadLine();

            Console.Write("Enter assignment description: ");
            var description = Console.ReadLine();

            Console.Write("Enter due date (yyyy-mm-dd) or leave blank: ");
            var dueInput = Console.ReadLine();
            DateTime? dueDate = null;
            if (DateTime.TryParse(dueInput, out var parsedDate))
            {
                dueDate = parsedDate;
            }

            Console.Write("Select priority (Low, Medium, High): ");
            var priorityInput = Console.ReadLine();
            if (!Enum.TryParse(priorityInput, true, out AssignmentPriority priority))
            {
                Console.WriteLine("Invalid priority. Defaulting to Medium.");
                priority = AssignmentPriority.Medium;
            }

            Console.Write("Enter notes (optional): ");
            var notes = Console.ReadLine();

            try
            {
                var assignment = new Assignment(title, description, dueDate, priority, notes);
                if (_assignmentService.AddAssignment(assignment))
                {
                    Console.WriteLine("Assignment added successfully.");
                }
                else
                {
                    Console.WriteLine("An assignment with this title already exists.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void ListAllAssignments()
        {
            var assignments = _assignmentService.ListAll();
            if (assignments.Count == 0)
            {
                Console.WriteLine("No assignments found.");
                return;
            }

            foreach (var assignment in assignments)
            {
                Console.WriteLine(assignment.ToString());
            }
        }

        private void ListIncompleteAssignments()
        {
            var assignments = _assignmentService.ListIncomplete();
            if (assignments.Count == 0)
            {
                Console.WriteLine("No incomplete assignments found.");
                return;
            }

            foreach (var assignment in assignments)
            {
                Console.WriteLine(assignment.ToString());
            }
        }

        private void MarkAssignmentComplete()
        {
            Console.Write("Enter the title of the assignment to mark as complete: ");
            var title = Console.ReadLine();
            if (_assignmentService.MarkAssignmentComplete(title))
            {
                Console.WriteLine("Assignment marked as complete.");
            }
            else
            {
                Console.WriteLine("Assignment not found or already completed.");
            }
        }

        private void SearchAssignmentByTitle()
        {
            Console.Write("Enter the title of the assignment to search: ");
            var title = Console.ReadLine();
            var assignment = _assignmentService.FindAssignmentByTitle(title);
            if (assignment != null)
            {
                Console.WriteLine("Assignment found:");
                Console.WriteLine(assignment.ToString());
            }
            else
            {
                Console.WriteLine("Assignment not found.");
            }
        }

        private void UpdateAssignment()
        {
            Console.Write("Enter the title of the assignment to update: ");
            var oldTitle = Console.ReadLine();

            Console.Write("Enter new title: ");
            var newTitle = Console.ReadLine();

            Console.Write("Enter new description: ");
            var newDescription = Console.ReadLine();

            if (_assignmentService.UpdateAssignment(oldTitle, newTitle, newDescription))
            {
                Console.WriteLine("Assignment updated successfully.");
            }
            else
            {
                Console.WriteLine("Assignment not found or update failed.");
            }
        }

        private void DeleteAssignment()
        {
            Console.Write("Enter the title of the assignment to delete: ");
            var title = Console.ReadLine();

            if (_assignmentService.DeleteAssignment(title))
            {
                Console.WriteLine("Assignment deleted successfully.");
            }
            else
            {
                Console.WriteLine("Assignment not found. Nothing was deleted.");
            }
        }
    }
}