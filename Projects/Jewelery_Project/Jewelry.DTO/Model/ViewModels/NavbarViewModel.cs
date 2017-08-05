using Jewelery.DAL.Entity;
using Jewelry.DTO.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO.Model.ViewModels
{
  public  class NavbarViewModel
    {
        public List<CategoryDTO> CategoryList { get; set; }

        public List<SubCategoryDTO> SubCategoryList { get; set; }
        public ProductDTO Product { get; set; }
        public List<MineDTO> MineList { get; set; }
        public List<GemDTO> GemList { get; set; }
    }
}
