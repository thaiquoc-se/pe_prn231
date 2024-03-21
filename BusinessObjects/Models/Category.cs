using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Category
    {
        public Category()
        {
            SilverJewelries = new HashSet<SilverJewelry>();
        }

        public string CategoryId { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string CategoryDescription { get; set; } = null!;
        public string? FromCountry { get; set; }

        public virtual ICollection<SilverJewelry> SilverJewelries { get; set; }
    }
}
