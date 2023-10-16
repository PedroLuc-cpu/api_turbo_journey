using ApI_task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApI_task.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModels>
    {
        public void Configure(EntityTypeBuilder<TarefaModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
