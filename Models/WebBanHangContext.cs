using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanHang.Models;

public partial class WebBanHangContext : DbContext
{
    public WebBanHangContext()
    {
    }

    public WebBanHangContext(DbContextOptions<WebBanHangContext> options)
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=WebBanHang.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAbout>(entity =>
        {
            entity.ToTable("tb_About");
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbBrand>(entity =>
        {
            entity.ToTable("tb_Brand");
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
        });

        modelBuilder.Entity<TbConfig>(entity =>
        {
            entity.ToTable("tb_Config");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.ToTable("tb_Contact");
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
        });

        // ✅ CHỈ CÓ MỘT BLOCK DUY NHẤT cho TbCustomer
        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);
            entity.ToTable("tb_Customer");
            entity.Property(e => e.CustomerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbCustomerAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId);
            entity.ToTable("tb_CustomerAddress");
            entity.Property(e => e.AddressId).ValueGeneratedNever().HasColumnName("AddressID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
        });

        modelBuilder.Entity<TbFeedback>(entity =>
        {
            entity.HasNoKey().ToTable("tb_Feedback");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TbFooter>(entity =>
        {
            entity.ToTable("tb_Footer");
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId);
            entity.ToTable("tb_Invoice");
            entity.HasIndex(e => e.SupplierId, "IX_tb_Invoice_SupplierID");
            entity.Property(e => e.InvoiceId).ValueGeneratedNever().HasColumnName("InvoiceID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.HasOne(d => d.Supplier).WithMany(p => p.TbInvoices).HasForeignKey(d => d.SupplierId);
        });

        modelBuilder.Entity<TbInvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ProductId });
            entity.ToTable("tb_InvoiceDetail");
            entity.HasIndex(e => e.ProductId, "IX_tb_InvoiceDetail_ProductID");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.HasOne(d => d.Invoice).WithMany(p => p.TbInvoiceDetails).HasForeignKey(d => d.InvoiceId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Product).WithMany(p => p.TbInvoiceDetails).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.ToTable("tb_Menu");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.ToTable("tb_Orders");
            entity.HasIndex(e => e.AddressId, "IX_tb_Orders_AddressID");
            entity.HasIndex(e => e.CustomerId, "IX_tb_Orders_CustomerID");
            entity.HasIndex(e => e.VoucherId, "IX_tb_Orders_VoucherID");
            entity.Property(e => e.OrderId).ValueGeneratedOnAdd().HasColumnName("OrderID"); // ✅ fixed
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.Orderdate).HasColumnType("datetime");
            entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            entity.HasOne(d => d.Address).WithMany(p => p.TbOrders).HasForeignKey(d => d.AddressId);
            entity.HasOne(d => d.Customer).WithMany(p => p.TbOrders).HasForeignKey(d => d.CustomerId);
            entity.HasOne(d => d.Voucher).WithMany(p => p.TbOrders).HasForeignKey(d => d.VoucherId);
        });

        modelBuilder.Entity<TbOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OderId, e.ProductId });
            entity.ToTable("tb_OrderDetail");
            entity.HasIndex(e => e.ProductId, "IX_tb_OrderDetail_ProductID");
            entity.Property(e => e.OderId).HasColumnName("OderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.HasOne(d => d.Oder).WithMany(p => p.TbOrderDetails).HasForeignKey(d => d.OderId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Product).WithMany(p => p.TbOrderDetails).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TbPasswordReset>(entity =>
        {
            entity.ToTable("tb_PasswordReset");
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID"); // ✅ fixed
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
        });

        modelBuilder.Entity<TbPorduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.ToTable("tb_Porduct");
            entity.HasIndex(e => e.BrainId, "IX_tb_Porduct_BrainID");
            entity.HasIndex(e => e.CateId, "IX_tb_Porduct_CateID");
            entity.HasIndex(e => e.SupplierId, "IX_tb_Porduct_SupplierID");
            entity.Property(e => e.ProductId).ValueGeneratedNever().HasColumnName("ProductID");
            entity.Property(e => e.BrainId).HasColumnName("BrainID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.HasOne(d => d.Brain).WithMany(p => p.TbPorducts).HasForeignKey(d => d.BrainId);
            entity.HasOne(d => d.Cate).WithMany(p => p.TbPorducts).HasForeignKey(d => d.CateId);
            entity.HasOne(d => d.Supplier).WithMany(p => p.TbPorducts).HasForeignKey(d => d.SupplierId);
        });

        modelBuilder.Entity<TbPost>(entity =>
        {
            entity.HasKey(e => e.PostId);
            entity.ToTable("tb_Post");
            entity.HasIndex(e => e.CateId, "IX_tb_Post_CateID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.HasOne(d => d.Cate).WithMany(p => p.TbPosts).HasForeignKey(d => d.CateId);
        });

        modelBuilder.Entity<TbPostCatetogy>(entity =>
        {
            entity.HasKey(e => e.CateId);
            entity.ToTable("tb_PostCatetogy.");
            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbPostComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);
            entity.ToTable("tb_PostComment");
            entity.HasIndex(e => e.PostId, "IX_tb_PostComment_PostID");
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.HasOne(d => d.Post).WithMany(p => p.TbPostComments).HasForeignKey(d => d.PostId);
        });

        modelBuilder.Entity<TbPostTag>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.TagId });
            entity.ToTable("tb_PostTag");
            entity.HasIndex(e => e.TagId, "IX_tb_PostTag_TagID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.TagId).HasColumnName("TagID");
            entity.HasOne(d => d.Tag).WithMany(p => p.TbPostTags).HasForeignKey(d => d.TagId).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TbProductCategory>(entity =>
        {
            entity.HasKey(e => e.CateId);
            entity.ToTable("tb_ProductCategory");
            entity.Property(e => e.CateId).ValueGeneratedNever().HasColumnName("CateID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbProductComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);
            entity.ToTable("tb_ProductComment");
            entity.HasIndex(e => e.CustomerId, "IX_tb_ProductComment_CustomerID");
            entity.HasIndex(e => e.ProductId, "IX_tb_ProductComment_ProductID");
            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.HasOne(d => d.Customer).WithMany(p => p.TbProductComments).HasForeignKey(d => d.CustomerId);
            entity.HasOne(d => d.Product).WithMany(p => p.TbProductComments).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<TbSlide>(entity =>
        {
            entity.ToTable("tb_Slide");
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
        });

        modelBuilder.Entity<TbSupplier>(entity =>
        {
            entity.ToTable("tb_Supplier");
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("ID");
        });

        modelBuilder.Entity<TbTag>(entity =>
        {
            entity.ToTable("tb_Tag");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TbVoucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId);
            entity.ToTable("tb_Voucher");
            entity.Property(e => e.VoucherId).ValueGeneratedNever().HasColumnName("VoucherID");
            entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}