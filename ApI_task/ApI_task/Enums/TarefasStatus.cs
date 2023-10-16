using System.ComponentModel;

namespace ApI_task.Enums
{
    public enum TarefasStatus
    {
        [Description("A Fazer")]
        Afazer = 1,

        [Description("A Andamento")]

        EmAndamento = 2,
        [Description("Concluido")]

        Concluido = 3,
    }
}
