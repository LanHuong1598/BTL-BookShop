namespace BTL_BookShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchase")]
    public partial class Purchase
    {
        public long ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public long Creater { get; set; }

        public int Status { get; set; }

        public int Total_price { get; set; }

        public long Publisher { get; set; }
    }
}
