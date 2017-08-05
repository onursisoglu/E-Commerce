using Jewelry.DTO.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO.Model.ViewModels
{
  public  class AdminViewModel
    {
        public List<CategoryDTO> CategoryList { get; set; }
        public List<ProductDTO> ProductList { get; set; }
        public List<CustomerDTO> CustomerList { get; set; }
        public List<SubCategoryDTO> SubCategoryList { get; set; }
        public List<GemDTO> GemList { get; set; }
        public List<AddressDTO> AddressList { get; set; }
        public List<OrderDetailDTO> OrderDetailList { get; set; }
        public List<OrderDTO> OrderList { get; set; }
        public List<MineDTO> MineList { get; set; }

    }
}
