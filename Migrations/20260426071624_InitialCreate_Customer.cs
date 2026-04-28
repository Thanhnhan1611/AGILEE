using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_About",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MetaKeywords = table.Column<string>(type: "TEXT", nullable: true),
                    Metadescriptions = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_About", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Config",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Config", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Contact",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Contact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "tb_CustomerAddress",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceiverName = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    IsDefault = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CustomerAddress", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Feedback",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tb_Footer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Footer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Link = table.Column<string>(type: "TEXT", nullable: true),
                    Target = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    Position = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_PasswordReset",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: true),
                    Token = table.Column<string>(type: "TEXT", nullable: true),
                    ExprireData = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PasswordReset", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_PostCatetogy.",
                columns: table => new
                {
                    CateID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Seotitle = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    Sort = table.Column<int>(type: "INTEGER", nullable: true),
                    ParentID = table.Column<int>(type: "INTEGER", nullable: true),
                    MetaKeywords = table.Column<string>(type: "TEXT", nullable: true),
                    Metadescriptions = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PostCatetogy.", x => x.CateID);
                });

            migrationBuilder.CreateTable(
                name: "tb_ProductCategory",
                columns: table => new
                {
                    CateID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Seotitle = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    Sort = table.Column<int>(type: "INTEGER", nullable: true),
                    ParentID = table.Column<int>(type: "INTEGER", nullable: true),
                    MetaKeywords = table.Column<string>(type: "TEXT", nullable: true),
                    Metadescriptions = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ProductCategory", x => x.CateID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Slide",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Sort = table.Column<int>(type: "INTEGER", nullable: true),
                    Link = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Slide", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Supplier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Tag",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Tag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Voucher",
                columns: table => new
                {
                    VoucherID = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Quanlity = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Voucher", x => x.VoucherID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Post",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SeiTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    CateID = table.Column<int>(type: "INTEGER", nullable: true),
                    ViewCount = table.Column<int>(type: "INTEGER", nullable: true),
                    MetaKeywords = table.Column<string>(type: "TEXT", nullable: true),
                    Metadescriptions = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_tb_Post_tb_PostCatetogy._CateID",
                        column: x => x.CateID,
                        principalTable: "tb_PostCatetogy.",
                        principalColumn: "CateID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    SupplierID = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<string>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Invoice", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_tb_Invoice_tb_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "tb_Supplier",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Porduct",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SeiTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    Quanlity = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    CateID = table.Column<int>(type: "INTEGER", nullable: true),
                    BrainID = table.Column<int>(type: "INTEGER", nullable: true),
                    SupplierID = table.Column<int>(type: "INTEGER", nullable: true),
                    ViewCount = table.Column<int>(type: "INTEGER", nullable: true),
                    MetaKeywords = table.Column<string>(type: "TEXT", nullable: true),
                    Metadescriptions = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Porduct", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_tb_Porduct_tb_Brand_BrainID",
                        column: x => x.BrainID,
                        principalTable: "tb_Brand",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_Porduct_tb_ProductCategory_CateID",
                        column: x => x.CateID,
                        principalTable: "tb_ProductCategory",
                        principalColumn: "CateID");
                    table.ForeignKey(
                        name: "FK_tb_Porduct_tb_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "tb_Supplier",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_PostTag",
                columns: table => new
                {
                    PostID = table.Column<string>(type: "TEXT", nullable: false),
                    TagID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PostTag", x => new { x.PostID, x.TagID });
                    table.ForeignKey(
                        name: "FK_tb_PostTag_tb_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "tb_Tag",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "INTEGER", nullable: false),
                    Orderdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    Delivered = table.Column<int>(type: "INTEGER", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: true),
                    Discount = table.Column<int>(type: "INTEGER", nullable: true),
                    VoucherID = table.Column<int>(type: "INTEGER", nullable: true),
                    AddressID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_tb_Orders_tb_CustomerAddress_AddressID",
                        column: x => x.AddressID,
                        principalTable: "tb_CustomerAddress",
                        principalColumn: "AddressID");
                    table.ForeignKey(
                        name: "FK_tb_Orders_tb_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tb_Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_tb_Orders_tb_Voucher_VoucherID",
                        column: x => x.VoucherID,
                        principalTable: "tb_Voucher",
                        principalColumn: "VoucherID");
                });

            migrationBuilder.CreateTable(
                name: "tb_PostComment",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    PostID = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PostComment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_tb_PostComment_tb_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "tb_Post",
                        principalColumn: "PostID");
                });

            migrationBuilder.CreateTable(
                name: "tb_InvoiceDetail",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    Quanlity = table.Column<int>(type: "INTEGER", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_InvoiceDetail", x => new { x.InvoiceID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_tb_InvoiceDetail_tb_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "tb_Invoice",
                        principalColumn: "InvoiceID");
                    table.ForeignKey(
                        name: "FK_tb_InvoiceDetail_tb_Porduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tb_Porduct",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "tb_ProductComment",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Detail = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Rating = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ProductComment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_tb_ProductComment_tb_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "tb_Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK_tb_ProductComment_tb_Porduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tb_Porduct",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "tb_OrderDetail",
                columns: table => new
                {
                    OderID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Quanlity = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_OrderDetail", x => new { x.OderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_tb_OrderDetail_tb_Orders_OderID",
                        column: x => x.OderID,
                        principalTable: "tb_Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_tb_OrderDetail_tb_Porduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tb_Porduct",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Invoice_SupplierID",
                table: "tb_Invoice",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_InvoiceDetail_ProductID",
                table: "tb_InvoiceDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OrderDetail_ProductID",
                table: "tb_OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Orders_AddressID",
                table: "tb_Orders",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Orders_CustomerID",
                table: "tb_Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Orders_VoucherID",
                table: "tb_Orders",
                column: "VoucherID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Porduct_BrainID",
                table: "tb_Porduct",
                column: "BrainID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Porduct_CateID",
                table: "tb_Porduct",
                column: "CateID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Porduct_SupplierID",
                table: "tb_Porduct",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Post_CateID",
                table: "tb_Post",
                column: "CateID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_PostComment_PostID",
                table: "tb_PostComment",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_PostTag_TagID",
                table: "tb_PostTag",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ProductComment_CustomerID",
                table: "tb_ProductComment",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ProductComment_ProductID",
                table: "tb_ProductComment",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_About");

            migrationBuilder.DropTable(
                name: "tb_Config");

            migrationBuilder.DropTable(
                name: "tb_Contact");

            migrationBuilder.DropTable(
                name: "tb_Feedback");

            migrationBuilder.DropTable(
                name: "tb_Footer");

            migrationBuilder.DropTable(
                name: "tb_InvoiceDetail");

            migrationBuilder.DropTable(
                name: "tb_Menu");

            migrationBuilder.DropTable(
                name: "tb_OrderDetail");

            migrationBuilder.DropTable(
                name: "tb_PasswordReset");

            migrationBuilder.DropTable(
                name: "tb_PostComment");

            migrationBuilder.DropTable(
                name: "tb_PostTag");

            migrationBuilder.DropTable(
                name: "tb_ProductComment");

            migrationBuilder.DropTable(
                name: "tb_Slide");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "tb_Invoice");

            migrationBuilder.DropTable(
                name: "tb_Orders");

            migrationBuilder.DropTable(
                name: "tb_Post");

            migrationBuilder.DropTable(
                name: "tb_Tag");

            migrationBuilder.DropTable(
                name: "tb_Porduct");

            migrationBuilder.DropTable(
                name: "tb_CustomerAddress");

            migrationBuilder.DropTable(
                name: "tb_Customer");

            migrationBuilder.DropTable(
                name: "tb_Voucher");

            migrationBuilder.DropTable(
                name: "tb_PostCatetogy.");

            migrationBuilder.DropTable(
                name: "tb_Brand");

            migrationBuilder.DropTable(
                name: "tb_ProductCategory");

            migrationBuilder.DropTable(
                name: "tb_Supplier");
        }
    }
}
