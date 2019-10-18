namespace BTL_BookShop.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsType> NewsTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShippingType> ShippingTypes { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Author1)
                .HasForeignKey(e => e.Author);

            modelBuilder.Entity<Book>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Book>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Book>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.CartItems)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Order_Detail)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.PurchaseDetails)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.SeoTitle)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.BookCategories)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<Image>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.isHomePage)
                .IsFixedLength();

            modelBuilder.Entity<NewsType>()
                .Property(e => e.Order)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NewsType>()
                .HasMany(e => e.News)
                .WithOptional(e => e.NewsType)
                .HasForeignKey(e => e.TypeID);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CouponSerial)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Detail)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_Detail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Publisher>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Publisher1)
                .HasForeignKey(e => e.Publisher);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books1)
                .WithOptional(e => e.Publisher2)
                .HasForeignKey(e => e.Released);

            modelBuilder.Entity<Purchase>()
                .HasMany(e => e.PurchaseDetails)
                .WithRequired(e => e.Purchase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserGroups)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("Credential").MapLeftKey("RoleID").MapRightKey("UserGroupID"));

            modelBuilder.Entity<ShippingType>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShippingType>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.ShippingType)
                .HasForeignKey(e => e.ShipTypeID);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Where)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserGroup)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);
        }
    }
}
