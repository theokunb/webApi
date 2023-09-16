using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Entities
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CompleteionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        Created,
        InProgress,
        Completed
    }
}
