using Jewelery.BLL.Extensions;
using Jewelery.BLL.Service;
using Jewelery.DAL.Entity;
using Jewelry.DTO.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.BLL.BO
{
  public class LoginOperation
    {
        EntityService service = new EntityService();
        public bool SignUp(CustomerDTO customer)
        {
            if (!service.CustomerService.CheckEmail(customer.Email))
            {
                service.CustomerService.Add(customer.MapTO<Customer>());
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public CustomerDTO SigninIndex(string email,string password)
        {
            Customer customer = service.CustomerService.GetAll().FirstOrDefault(c => c.Email == email && c.Password == password);
            if (customer!=null)
            {
                CustomerDTO customerDTO = customer.MapTO<CustomerDTO>();

                customerDTO.FavoriteProductsDTO =customer.FavoriteProducts.Select(x => x.MapTO<FavoriteProductDTO>()).ToList();
                //foreach (var item in customerDTO.FavoriteProductsDTO)
                //{
                //    item.ProductDTO = service.ProductService.GetByCondition(x => x.ProductID == item.ProductID).MapTO<ProductDTO>();
                //    item.ProductDTO.ProductPicturesDTO = service.ProductPictureService.GetByCondition(x => x.ProductID == item.ProductID).Select(c => c.MapTO<ProductPictureDTO>()).ToList();
                //}
                customerDTO.OrdersDTO = customer.Orders.Select(x => x.MapTO<OrderDTO>()).ToList();
                customerDTO.AddressesDTO = customer.Addresses.Select(x => x.MapTO<AddressDTO>()).ToList();
                
                
                return customerDTO;
            }
            else
            {
                return null;
            }
            
        }
        
    }
}
