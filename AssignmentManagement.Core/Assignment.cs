
using System;

namespace AssignmentManagement.Core
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? DueDate { get; private set; }
        public AssignmentPriority Priority { get; private set; }
        public bool IsCompleted { get; private set; }
        public string Notes { get; private set; }

        public Assignment(string title, string description, DateTime? dueDate, AssignmentPriority priority, string notes = "")
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Notes = notes; // ✅ FIXED: Assign notes
            IsCompleted = false;
        }

        public void Update(string newTitle, string newDescription)
        {
            Title = newTitle;
            Description = newDescription;
        }

        public void MarkComplete()
        {
            IsCompleted = true;
        }

        public bool IsOverdue()
        {
            // ✅ FIXED: Return false if already completed or DueDate is null
            return DueDate.HasValue && !IsCompleted && DateTime.Now > DueDate.Value;
        }

        public override string ToString()
        {
            return $"- {Title} ({Priority}) due {DueDate?.ToShortDateString() ?? "N/A"}\n" +
                   $"{Description}\n" +
                   $"Completed: {IsCompleted}\n" +
                   (!string.IsNullOrWhiteSpace(Notes) ? $"Notes: {Notes}" : "");
        }
    }

    public enum AssignmentPriority
    {
        Low,
        Medium,
        High
    }
}