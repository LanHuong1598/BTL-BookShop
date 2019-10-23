namespace BTL_BookShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryBook")]
    public partial class CategoryBook
    {
        public long ID { get; set; }

        public long? IDBook { get; set; }

        public long? IDCategory { get; set; }
    }
}
