using ApI_task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApI_task.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModels>
    {
        public void Configure(EntityTypeBuilder<UsuarioModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
