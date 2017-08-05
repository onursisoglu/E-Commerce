
namespace Jewelry.DTO.Model.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubCategoryDTO
    {
        public int SubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public int MineID { get; set; }
        public Nullable<int> GemID { get; set; }

        public Nullable<bool> IsActive { get; set; }
        public virtual CategoryDTO CategoryDTO { get; set; }
        public virtual GemDTO GemDTO { get; set; }
        public virtual MineDTO MineDTO { get; set; }
        public virtual ICollection<ProductDTO> ProductDTO { get; set; }
    }
}
