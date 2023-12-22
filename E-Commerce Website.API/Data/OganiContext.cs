namespace E_Commerce_Website.API.Data;

public partial class OganiContext : DbContext
{
    public OganiContext()
    {
    }

    public OganiContext(DbContextOptions<OganiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=Ogani;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Categoryid).ValueGeneratedNever();
            entity.Property(e => e.Createdon).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Updatedon).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CategoryCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_UserLogin");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.CategoryUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_UserLogin1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Productid).ValueGeneratedNever();
            entity.Property(e => e.Createdon).HasColumnType("datetime");
            entity.Property(e => e.Updatedon).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.ProductCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_UserLogin");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.ProductUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_UserLogin1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Rolesid);

            entity.Property(e => e.Rolesid).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Userid);

            entity.ToTable("UserLogin");

            entity.Property(e => e.Userid).ValueGeneratedNever();
            entity.Property(e => e.Createdon).HasColumnType("datetime");
            entity.Property(e => e.Phonenumber).HasMaxLength(50);
            entity.Property(e => e.Updatedon).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Roles).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.Rolesid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_UserLogin");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
