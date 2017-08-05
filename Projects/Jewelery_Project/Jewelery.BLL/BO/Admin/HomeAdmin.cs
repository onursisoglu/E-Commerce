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

namespace Jewelery.BLL.BO.Admin
{

   public class HomeAdmin
    {
        EntityService service;
        public HomeAdmin()
        {
            service = new EntityService();
        }
        // ADMİN LOGİN
        public CustomerDTO AdminLogin(string email,string password)
        {
            Customer customer= service.CustomerService.GetByFind(x => x.Email == email && x.Password == password);
            if (customer!=null&&customer.Role==true)
            {
                return customer.MapTO<CustomerDTO>();
            }
            else
            {
                return null;
            }
        }

        // ADMİN INDEX VİEW 
        public AdminViewModel AdminIndex(string text)
        {
            AdminViewModel vm = new AdminViewModel();
            switch (text)
            {
                case "Product":
                    vm.ProductList = service.ProductService.GetAll().Select(x => x.MapTO<ProductDTO>()).ToList();
                    return vm;
                case "Category":
                    vm.CategoryList = service.CategoryService.GetAll().Select(x => x.MapTO<CategoryDTO>()).ToList();
                    return vm;
                case "Customer":
                    vm.CustomerList = service.CustomerService.GetAll().Select(x => x.MapTO<CustomerDTO>()).ToList();
                    foreach (var item in vm.CustomerList)
                    {
                        item.OrdersDTO = service.OrderService.GetByCondition(x => x.CustomerID == item.CustomerID).Select(c => c.MapTO<OrderDTO>()).ToList();
                        foreach (var order in item.OrdersDTO)
                        {
                            order.OrderDetailsDTO = service.OrderDetailService.GetByCondition(x => x.OrderID == order.OrderID).Select(c => c.MapTO<OrderDetailDTO>()).ToList();
                        }
                    }
                    
                    return vm;
                case "Gem":
                    vm.GemList = service.GemService.GetAll().Select(x => x.MapTO<GemDTO>()).ToList();
                    return vm;
                case "SubCategory":
                    vm.SubCategoryList = service.SubCategoryService.GetAll().Select(x => x.MapTO<SubCategoryDTO>()).ToList();
                    foreach (var item in vm.SubCategoryList)
                    {
                            item.MineDTO = service.MineService.Detail(item.MineID).MapTO<MineDTO>();
                            if (item.GemID.HasValue)
                            {
                                item.GemDTO = service.GemService.Detail(item.GemID.Value).MapTO<GemDTO>();
                            }

                            item.CategoryDTO = service.CategoryService.Detail(item.CategoryID).MapTO<CategoryDTO>();
                        
                    }
                    return vm;
                case "Order":
                    vm.OrderList  = service.OrderService.GetAll().Select(x => x.MapTO<OrderDTO>()).ToList();
                    foreach (var item in vm.OrderList)
                    {
                        
                        item.OrderDetailsDTO = service.OrderDetailService.GetByCondition(x => x.OrderID == item.OrderID).Select(c => c.MapTO<OrderDetailDTO>()).ToList();
                        foreach (var product in item.OrderDetailsDTO )
                        {
                            product.ProductName = service.ProductService.Detail(product.ProductID).ProductName;
                        }
                        item.CustomerDTO = service.CustomerService.Detail(item.CustomerID).MapTO<CustomerDTO>();
                        item.AddressDTO = service.AddressService.Detail(item.AddressID).MapTO<AddressDTO>();
                    }
                
                    return vm;
                default:
                    return null;
            }
        }

        // ADMİN CATEGORY CRUD START
        public bool AddCategory(CategoryDTO data)
        {
            Category category = service.CategoryService.GetByFind(x => x.CategoryName == data.CategoryName);
            if (category==null)
            {
                try
                {
                    //Category category = new Category();
                    category.CategoryName = data.CategoryName;
                    category.Description = data.Description;
                    service.CategoryService.Add(category);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
            
           
        }
        public CategoryDTO UpdateCategoryView(int CategoryID)
        {
            Category category = service.CategoryService.Detail(CategoryID);
            
            if (category!=null)
            {
                CategoryDTO updateCategory = category.MapTO<CategoryDTO>();
                return updateCategory;
            }
            else
            {
                return null;
            }

        }
        public bool UpdateCategory(CategoryDTO data)
        {
            Category category = service.CategoryService.Detail(data.CategoryID);
            if (category != null)
            {
                category.CategoryName = data.CategoryName;
                category.Description = data.Description;
                category.IsActive = data.IsActive;
                service.CategoryService.Update(category);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCategory(int CategoryID)
        {
            try
            {
                service.CategoryService.Delete(CategoryID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        //ADMİN CATEGORY CRUD END ---!

        // !--- ADMİN GEM CRUD START
      public bool AddGem(GemDTO data)
        {
            Gem _gem = service.GemService.GetByFind(x =>x.GemName== data.GemName&&x.Colour== data.Colour);
            if (_gem == null)
            {
                try
                {
                    _gem = data.MapTO<Gem>();
                    service.GemService.Add(_gem);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public GemDTO GemUpdateView(int GemID)
        {
            GemDTO updateGem = service.GemService.Detail(GemID).MapTO<GemDTO>();
            if (updateGem != null)
            {
                return updateGem;
            }
            else
            {
                return null;
            }
        }

        public bool GemUpdate(GemDTO data)
        {
            Gem gem = service.GemService.Detail(data.GemID);
            if (gem != null)
            {
                gem.GemName = data.GemName;
                gem.Colour = data.Colour;
                gem.Shape = data.Shape;
                gem.GemWeight = data.GemWeight;
                service.GemService.Update(gem);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteGem(int GemID)
        {
            try
            {
                service.GemService.Delete(GemID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        // ADMİN GEM CRUD END ---!

        public List<OrderDetailDTO> OrderDetail(int OrderID)
        {
            List<OrderDetail> liste = service.OrderDetailService.GetByCondition(x => x.OrderID == OrderID).ToList();
            if (liste!=null)
            {
                
                List<OrderDetailDTO> ListDTO = liste.Select(x => x.MapTO<OrderDetailDTO>()).ToList();
                foreach (var item in ListDTO)
                {
                    item.ProductName = service.ProductService.Detail(item.ProductID).ProductName;
                }
                return ListDTO;
            }
            else
            {
                return null;
                    
            }
        }

        public List<AddressDTO> CustomerDetail(int CustomerID)
        {
            List<Address> liste = service.AddressService.GetAll().Where(x => x.CustomerID == CustomerID).ToList();
            if (liste != null)
            {

                List<AddressDTO> ListDTO = liste.Select(x => x.MapTO<AddressDTO>()).ToList();
                foreach (var item in ListDTO)
                {
                    item.CustomerDTO = service.CustomerService.Detail(item.CustomerID).MapTO<CustomerDTO>();
                }
                return ListDTO;
            }
            else
            {
                return null;

            }
        }



    }

}
