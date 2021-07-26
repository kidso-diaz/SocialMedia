using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            #region Table
            builder.ToTable("Publicacion");
            #endregion

            #region PrimaryKey
            builder.HasKey(e => e.Id);
            #endregion

            #region Fields
            builder.Property(e => e.Id)
                .HasColumnName("IdPublicacion");

            builder.Property(e => e.UserId)
                .HasColumnName("IdUsuario");

            builder.Property(e => e.PostDate)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

            builder.Property(e => e.Description)
                .HasColumnName("Descripcion")
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Image)
                .HasColumnName("Imagen")
                .HasMaxLength(500)
                .IsUnicode(false);
            #endregion

            #region Constraints
            builder.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuario");
            #endregion
        }
    }
}
