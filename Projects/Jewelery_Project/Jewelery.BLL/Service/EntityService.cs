using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.BLL.Service
{
    using BLL.Repository;
    using DAL.Entity;

    public  class EntityService
    {
        public EntityService()
        {
            //JewelryEntities db = new JewelryEntities();
            CategoryService = new CategoryRepositroy();
            
            SubCategoryService = new SubCategoryRepository();
            ProductPictureService = new ProductPicturesRepository();
            ProductService = new ProductsRepository();
            CustomerService = new CustomerRepository();
           
            GemService = new GemRepository();
            MineService = new MineRepository();
            OrderService = new OrderRepository();
            OrderDetailService = new OrderDetailRepository();
            AddressService = new AddressRepository();
            CommentService = new CommentRepository();
            FavouriteProductService = new FavouriteProductsRepository();
        }

        public CategoryRepositroy CategoryService { get; set; }
       
        public ProductPicturesRepository ProductPictureService { get; set; }
        public ProductsRepository ProductService { get; set; }
        public  CustomerRepository CustomerService { get; set; }
      
        public GemRepository GemService { get; set; }
        public MineRepository MineService { get; set; }
        public OrderRepository OrderService { get; set; }
        public OrderDetailRepository OrderDetailService { get; set; }
        public AddressRepository AddressService { get; set; }
        public CommentRepository CommentService { get; set; }
        public SubCategoryRepository SubCategoryService { get; set; }
        public FavouriteProductsRepository FavouriteProductService { get; set; }
      
    }
}
