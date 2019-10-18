namespace BTL_BookShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Detail = new HashSet<Order_Detail>();
        }

        public long ID { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? CreatID { get; set; }

        public long? Shiper { get; set; }

        public long? ShipTypeID { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(50)]
        public string ShipMobile { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        [StringLength(255)]
        public string ShipAdress { get; set; }

        [StringLength(50)]
        public string CouponSerial { get; set; }

        public int? Status { get; set; }

        public DateTime? ShippedDate { get; set; }

        public decimal? TotalPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }

        public virtual ShippingType ShippingType { get; set; }
    }
}
