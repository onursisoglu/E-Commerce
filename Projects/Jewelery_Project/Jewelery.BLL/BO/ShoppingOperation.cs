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

    public class ShoppingOperation
    {
        EntityService service;
        public ShoppingOperation()
        {
            service = new EntityService();
        }
        public List<ShoppingCartDTO> ShopBasket(ref List<ShoppingCartDTO> sepet, int ProductID, int? CustomerID)
        {

            List<ShoppingCartDTO> sepetList = new List<ShoppingCartDTO>();
            if (sepet != null)
            {
                sepetList = sepet;
            }
            ShoppingCartDTO sep = sepetList.FirstOrDefault(c => c.ProductID == ProductID);
            if (sep == null)
            {
                Product urun = service.ProductService.Detail(ProductID);
                sep = new ShoppingCartDTO();
                sep.ProductID = ProductID;
                sep.ProductName = urun.ProductName;
                sep.Quantity = 1;
                sep.ProductPhoto = urun.ProductPhoto;
                sep.UnitPrice = urun.UnitPrice;
                if (sep.Discount != null)
                {
                    sep.Discount = urun.Discount.Value;
                }
                sep.CustomerID = CustomerID;
                sep.UnitsInStock = urun.UnitsInStock;
                sepetList.Add(sep);
            }
            else
            {
                if (sep.Quantity == sep.UnitsInStock)
                {

                    return null;

                }
                else
                {
                    sep.Quantity++;
                }
            }
            sepet = sepetList;
            return sepet;
        }

        public bool Pay(OrderDTO data, List<ShoppingCartDTO>shoppingCart)
        {
            try
            {
                Order order = new Order();
                order.CustomerID = data.CustomerID;
                order.AddressID = data.AddressID;
                order.OrderDate = data.OrderDate;
                order.ShippedDate = data.ShippedDate;
                foreach (var item in shoppingCart)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.ProductID;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.UnitPrice = item.UnitPrice;
                    orderDetail.OrderID = order.OrderID;
                    orderDetail.AddedDate = DateTime.Now;
                    orderDetail.IsActive = true;

                    order.OrderDetails.Add(orderDetail);
                }

                service.OrderService.Add(order);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
