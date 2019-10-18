namespace BTL_BookShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            CartItems = new HashSet<CartItem>();
            Order_Detail = new HashSet<Order_Detail>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
        }

        public long ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? Author { get; set; }

        public int? Released { get; set; }

        public int? Publisher { get; set; }

        public int? NumberPage { get; set; }

        public int? Weight { get; set; }

        [StringLength(20)]
        public string Form { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublishDate { get; set; }

        public int? Buys { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public long? CategoryID { get; set; }

        public int? ViewCount { get; set; }

        public int? Inventory { get; set; }

        public bool? Status { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public string Description { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Author Author1 { get; set; }

        public virtual Publisher Publisher1 { get; set; }

        public virtual Publisher Publisher2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartItem> CartItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
