using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SocialMedia.Infrastructure.Data
{
    public partial class SocialMediaContext : DbContext
    {
        public SocialMediaContext()
        {
        }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                #region Table
                entity.ToTable("Comentario");
                #endregion

                #region PrimaryKey
                entity.HasKey(e => e.CommentId);
                #endregion

                #region Fields
                entity.Property(e => e.CommentId)
                    .HasColumnName("IdComentario")
                    .ValueGeneratedNever();

                entity.Property(e => e.PostId)
                    .HasColumnName("IdPublicacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .HasColumnName("IdUsuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("Descripcion")
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Date) 
                    .HasColumnName("Fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Active)
                    .HasColumnName("Activo")
                    .ValueGeneratedNever();
                #endregion

                #region Constraints
                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Publicacion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Usuario");
                #endregion
            });

            modelBuilder.Entity<Post>(entity =>
            {
                #region Table
                entity.ToTable("Publicacion");
                #endregion

                #region PrimaryKey
                entity.HasKey(e => e.PostId);
                #endregion

                #region Fields
                entity.Property(e => e.PostId)
                    .HasColumnName("IdPublicacion");

                entity.Property(e => e.UserId)
                    .HasColumnName("IdUsuario");

                entity.Property(e => e.PostDate)
                    .HasColumnName("Fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("Descripcion")
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("Imagen")
                    .HasMaxLength(500)
                    .IsUnicode(false);
                #endregion

                #region Constraints
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicacion_Usuario");
                #endregion
            });

            modelBuilder.Entity<User>(entity =>
            {
                #region Table
                entity.ToTable("Usuario");
                #endregion

                #region PrimaryKey
                entity.HasKey(e => e.UserId);
                #endregion

                #region Fields
                entity.Property(e => e.UserId)
                    .HasColumnName("IdUsuario")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("Nombres")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("Apellidos")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("FechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Telephone)
                    .HasColumnName("Telefono")
                    .HasMaxLength(10)
                    .IsUnicode(false);
                #endregion
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
