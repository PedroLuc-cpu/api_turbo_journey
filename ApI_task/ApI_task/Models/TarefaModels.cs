using ApI_task.Enums;

namespace ApI_task.Models
{
    public class TarefaModels
    {
        // ? no tipo significa que a property pode ser null
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TarefasStatus Status { set; get; }
    }
}
