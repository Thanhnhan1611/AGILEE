using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanHang.Models.ApplicationDbContext;

public partial class ApplicationDbContext : DbContext
{
 

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAbout> TbAbouts { get; set; }

    public virtual DbSet<TbBrand> TbBrands { get; set; }

    public virtual DbSet<TbConfig> TbConfigs { get; set; }

    public virtual DbSet<TbContact> TbContacts { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbCustomerAddress> TbCustomerAddresses { get; set; }

    public virtual DbSet<TbFeedback> TbFeedbacks { get; set; }

    public virtual DbSet<TbFooter> TbFooters { get; set; }

    public virtual DbSet<TbInvoice> TbInvoices { get; set; }

    public virtual DbSet<TbInvoiceDetail> TbInvoiceDetails { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; }

    public virtual DbSet<TbPasswordReset> TbPasswordResets { get; set; }

    public virtual DbSet<TbPorduct> TbPorducts { get; set; }

    public virtual DbSet<TbPost> TbPosts { get; set; }

    public virtual DbSet<TbPostCatetogy> TbPostCatetogies { get; set; }

    public virtual DbSet<TbPostComment> TbPostComments { get; set; }

    public virtual DbSet<TbPostTag> TbPostTags { get; set; }

    public virtual DbSet<TbProductCategory> TbProductCategories { get; set; }

    public virtual DbSet<TbProductComment> TbProductComments { get; set; }

    public virtual DbSet<TbSlide> TbSlides { get; set; }

    public virtual DbSet<TbSupplier> TbSuppliers { get; set; }

    public virtual DbSet<TbTag> TbTags { get; set; }

    public virtual DbSet<TbVoucher> TbVouchers { get; set; }
    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ADMIN-PC\\SQLEXPRESS01;Database=banhangonline;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAbout>(entity =>
        {
            entity.ToTable("tb_About");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(550);
            entity.Property(e => e.Detail).HasMaxLength(550);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.Metadescriptions).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(560);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbBrand>(entity =>
        {
            entity.ToTable("tb_Brand");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TbConfig>(entity =>
        {
            entity.ToTable("tb_Config");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(505);
            entity.Property(e => e.Value).HasMaxLength(50);
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.ToTable("tb_Contact");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Detail).HasMaxLength(550);
            entity.Property(e => e.Name).HasMaxLength(560);
            entity.Property(e => e.Status).HasMaxLength(550);
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("tb_Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbCustomerAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("tb_CustomerAddress");

            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasColumnName("AddressID");
            entity.Property(e => e.Address).HasMaxLength(540);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.ReceiverName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbFeedback>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Feedback");

            entity.Property(e => e.Address).HasMaxLength(505);
            entity.Property(e => e.Detail).HasMaxLength(505);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(560);
            entity.Property(e => e.Phone).HasMaxLength(550);
        });

        modelBuilder.Entity<TbFooter>(entity =>
        {
            entity.ToTable("tb_Footer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(550);
            entity.Property(e => e.Name).HasMaxLength(560);
        });

        modelBuilder.Entity<TbInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId);

            entity.ToTable("tb_Invoice");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedNever()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.CreatedBy).HasMaxLength(55);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(50);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(505);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UpdateBy).HasMaxLength(550);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Supplier).WithMany(p => p.TbInvoices)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_tb_Invoice_tb_Supplier");
        });

        modelBuilder.Entity<TbInvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ProductId });

            entity.ToTable("tb_InvoiceDetail");

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Invoice).WithMany(p => p.TbInvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_InvoiceDetail_tb_Invoice");

            entity.HasOne(d => d.Product).WithMany(p => p.TbInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_InvoiceDetail_tb_Porduct");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.ToTable("tb_Menu");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(505);
            entity.Property(e => e.Link).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(560);
            entity.Property(e => e.Target).HasMaxLength(530);
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("tb_Orders");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.Orderdate).HasColumnType("datetime");
            entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

            entity.HasOne(d => d.Address).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_tb_Orders_tb_CustomerAddress");

            entity.HasOne(d => d.Customer).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tb_Orders_tb_Customer");

            entity.HasOne(d => d.Voucher).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_tb_Orders_tb_Voucher");
        });

        modelBuilder.Entity<TbOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OderId, e.ProductId });

            entity.ToTable("tb_OrderDetail");

            entity.Property(e => e.OderId).HasColumnName("OderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Oder).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.OderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_OrderDetail_tb_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.TbOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_OrderDetail_tb_Porduct");
        });

        modelBuilder.Entity<TbPasswordReset>(entity =>
        {
            entity.ToTable("tb_PasswordReset");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ExprireData).HasMaxLength(550);
            entity.Property(e => e.Token).HasMaxLength(550);
        });

        modelBuilder.Entity<TbPorduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("tb_Porduct");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.BrainId).HasColumnName("BrainID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.Metadescriptions).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SeiTitle).HasMaxLength(250);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Brain).WithMany(p => p.TbPorducts)
                .HasForeignKey(d => d.BrainId)
                .HasConstraintName("FK_tb_Porduct_tb_Brand");

            entity.HasOne(d => d.Cate).WithMany(p => p.TbPorducts)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK_tb_Porduct_tb_ProductCategory");

            entity.HasOne(d => d.Supplier).WithMany(p => p.TbPorducts)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_tb_Porduct_tb_Supplier");
        });

        modelBuilder.Entity<TbPost>(entity =>
        {
            entity.HasKey(e => e.PostId);

            entity.ToTable("tb_Post");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.Metadescriptions).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.SeiTitle).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Cate).WithMany(p => p.TbPosts)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK_tb_Post_tb_PostCatetogy.");
        });

        modelBuilder.Entity<TbPostCatetogy>(entity =>
        {
            entity.HasKey(e => e.CateId);

            entity.ToTable("tb_PostCatetogy.");

            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.Metadescriptions).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.Seotitle).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbPostComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tb_PostComment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(510);
            entity.Property(e => e.Email).HasMaxLength(550);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.TbPostComments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_tb_PostComment_tb_Post");
        });

        modelBuilder.Entity<TbPostTag>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.TagId });

            entity.ToTable("tb_PostTag");

            entity.Property(e => e.PostId)
                .HasMaxLength(50)
                .HasColumnName("PostID");
            entity.Property(e => e.TagId)
                .HasMaxLength(50)
                .HasColumnName("TagID");

            entity.HasOne(d => d.Tag).WithMany(p => p.TbPostTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_PostTag_tb_Tag");
        });

        modelBuilder.Entity<TbProductCategory>(entity =>
        {
            entity.HasKey(e => e.CateId);

            entity.ToTable("tb_ProductCategory");

            entity.Property(e => e.CateId)
                .ValueGeneratedNever()
                .HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.Metadescriptions).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.Seotitle).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbProductComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tb_ProductComment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Detail).HasMaxLength(510);
            entity.Property(e => e.Email).HasMaxLength(550);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Rating).HasMaxLength(505);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.TbProductComments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tb_ProductComment_tb_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.TbProductComments)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tb_ProductComment_tb_Porduct");
        });

        modelBuilder.Entity<TbSlide>(entity =>
        {
            entity.ToTable("tb_Slide");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Link).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(560);
        });

        modelBuilder.Entity<TbSupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Supplỉe");

            entity.ToTable("tb_Supplier");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<TbTag>(entity =>
        {
            entity.ToTable("tb_Tag");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TbVoucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId);

            entity.ToTable("tb_Voucher");

            entity.Property(e => e.VoucherId)
                .ValueGeneratedNever()
                .HasColumnName("VoucherID");
            entity.Property(e => e.Code).HasMaxLength(550);
            entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
