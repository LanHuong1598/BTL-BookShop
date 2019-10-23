namespace BTL_BookShop.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        public int ID { get; set; }

        [StringLength(255)]
        [DisplayName("Tên Tác Giả")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        [DisplayName("Tiểu sử")]
        public string Description { get; set; }

        [StringLength(50)]
        [DisplayName("Quốc tịch")]
        public string Type { get; set; }

        [StringLength(255)]
        [DisplayName("Avatar")]
        public string Image { get; set; }
    }
}
