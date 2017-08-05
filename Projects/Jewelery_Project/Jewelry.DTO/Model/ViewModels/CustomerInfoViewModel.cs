using Jewelery.DAL.Entity;
using Jewelry.DTO.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.DTO.Model.ViewModels
{
   public class CustomerInfoViewModel
    {
        public CustomerDTO Customer { get; set; }

        public List<AddressDTO> Adres { get; set; }

        public AddressDTO _adres { get; set; }

        public List<OrderDetailDTO> ordersDTo { get; set; }

        public List<ProductDTO> ProductDTO { get; set; }

        public List<ProductPictureDTO> _productPictures { get; set; }
    }
}
