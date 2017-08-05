using Jewelery.DAL.Entity;
using Jewelry.DTO.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO.Model.ViewModels
{
   public class ProductsViewModel
    {
       
        public List<ProductDTO> EnCokSatilanlar { get; set; }
        public List<ProductDTO> indirimdeOlanlar { get; set; }
        public List<ProductDTO> YeniEklenenler { get; set; }
        public List<OrderDetailDTO> EnSonSatinAlinanlar { get; set; }
        
    }
}
