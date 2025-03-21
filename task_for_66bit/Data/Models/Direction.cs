namespace task_for_66bit.Data.Models;

public class Direction
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Intern> Interns { get; set; } = new List<Intern>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}