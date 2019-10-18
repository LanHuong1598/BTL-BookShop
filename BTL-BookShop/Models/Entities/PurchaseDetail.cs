namespace BTL_BookShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseDetail")]
    public partial class PurchaseDetail
    {
        public long ID { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public long Bookid { get; set; }

        public long PurchaseID { get; set; }

        public virtual Book Book { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
