using BTL_BookShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_BookShop.Areas.Admin.Models
{
    public class BookModel
    {
        public Book Book { get; set; }
        public string NameAuthor { get; set; }

        public string NameReleased { get; set; }
        public string NamePublisher { get; set; }
        public string NameType { get; set; }
    }
}