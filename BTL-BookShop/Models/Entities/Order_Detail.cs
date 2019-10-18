namespace BTL_BookShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Detail
    {
        public long ID { get; set; }

        public long BookID { get; set; }

        public long OrderID { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }
    }
}
