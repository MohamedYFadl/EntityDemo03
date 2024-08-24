using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo03.Entities
{
    public class Category
    {
        public Category ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public ICollection<Category> ChildCategories { get; set; }

    }
}
