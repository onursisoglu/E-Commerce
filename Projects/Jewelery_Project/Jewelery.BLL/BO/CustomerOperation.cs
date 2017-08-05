using Jewelery.BLL.Extensions;
using Jewelery.BLL.Service;
using Jewelery.DAL.Entity;
using Jewelry.DTO.Model.DTO;
using Jewelry.DTO.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.BLL.BO
{
    public class CustomerOperation
    {
        EntityService service = new EntityService();
        CustomerInfoViewModel custVM = new CustomerInfoViewModel();
        public CustomerInfoViewModel CustomerProfile(int CustomerID, string info)
        {
            if (info == "Info")
            {
                custVM.Customer = service.CustomerService.GetAll().FirstOrDefault(c => c.CustomerID == CustomerID).MapTO<CustomerDTO>();
                return custVM;
            }
            else if (info == "Order")
            {
                custVM.ordersDTo = service.OrderDetailService.GetByCondition(x => x.Order.CustomerID == CustomerID).Select(c => new OrderDetailDTO
                {
                    ProductID =c.ProductID,
                    ProductName = c.Product.ProductName,
                    ProductPhoto = c.Product.ProductPhoto,
                    AddedDate = c.AddedDate,
                    Quantity = c.Quantity,
                    UnitPrice = c.UnitPrice

                }).ToList();
                return custVM;
            }
            else if (info == "Adres")
            {
                custVM.Adres = service.AddressService.GetByCondition(x => x.CustomerID == CustomerID && x.IsActive == true).Select(c => c.MapTO<AddressDTO>()).ToList();
                custVM.Customer = service.CustomerService.Detail(CustomerID).MapTO<CustomerDTO>();
                return custVM;
            }
            else if (info == "Pass")
            {
                custVM.Customer = service.CustomerService.GetByCondition(x => x.CustomerID == CustomerID).Select(a => new CustomerDTO
                {
                    CustomerID = a.CustomerID,
                    Name = a.Name,
                    LastName = a.LastName,
                    BirthDate = a.BirthDate,
                    Email = a.Email,
                    Phone = a.Phone,
                    Password = a.Password,

                }).FirstOrDefault();
                return custVM;
            }
            else if (info == "Favourite")
            {
                Customer customer = service.CustomerService.Detail(CustomerID);
                if (customer!=null)
                {
                    custVM.Customer = customer.MapTO<CustomerDTO>();
                    custVM.Customer.FavoriteProductsDTO = customer.FavoriteProducts.Select(x => x.MapTO<FavoriteProductDTO>()).ToList();
                   
                    foreach (var item in custVM.Customer.FavoriteProductsDTO)
                    {

                        item.ProductDTO = service.ProductService.Detail(item.ProductID).MapTO<ProductDTO>();
                    }
                    return custVM;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        public int CustomerInfoPost(CustomerDTO customer,int CustomerID)
        {
            try
            {
                Customer cust = service.CustomerService.Detail(CustomerID);
                cust.Name = customer.Name;
                cust.CustomerID = CustomerID;
                cust.LastName = customer.LastName;
                cust.Phone = customer.Phone;
                cust.Email = customer.Email;
                cust.BirthDate = customer.BirthDate;
                service.CustomerService.Update(cust);
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }


        public int CustomerResetPassword(string password,int id)
        {
            try
            {
                Customer cust = service.CustomerService.Detail(id);
                cust.Password = password;
                service.CustomerService.Update(cust);
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
            

        }
        
        public int CustomerEditAddress(AddressDTO adres, int AddressID)
        {
            Address editAddress = service.AddressService.Detail(AddressID);
            editAddress.AddressID = adres.AddressID;
            editAddress.CustomerID = adres.CustomerID;
            editAddress.City = adres.City;
            editAddress.District = adres.District;
            editAddress.Country = adres.Country;
            editAddress.Address1 = adres.Address1;
            service.AddressService.Update(editAddress);
            return 1;
        }

        public int CustomerNewAddress(AddressDTO adres,int CustomerID)
        {
            Address newAddress = new Address();
            newAddress = adres.MapTO<Address>();
            service.AddressService.Add(newAddress);
            return 1;
        }

        public int CustomerAddressDelete(int AddressID)
        {
            return service.AddressService.Delete(AddressID);
        }
    }
}
