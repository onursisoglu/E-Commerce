//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jewelry.DTO.Model.DTO
{
    using System;
    using System.Collections.Generic;

    public partial class ProductDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDTO()
        {
            this.CommentsDTO = new HashSet<CommentDTO>();
            this.FavoriteProductsDTO = new HashSet<FavoriteProductDTO>();
            this.OrderDetailsDTO = new HashSet<OrderDetailDTO>();
            
            this.ProductPicturesDTO = new HashSet<ProductPictureDTO>();
        }

        public int ProductID { get; set; }
        public int SubCategoryID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Nullable<byte> UnitsInStock { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> GemWeight { get; set; }
        public string ProductPhoto { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentDTO> CommentsDTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriteProductDTO> FavoriteProductsDTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetailDTO> OrderDetailsDTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPictureDTO> ProductPicturesDTO { get; set; }
        public virtual SubCategoryDTO SubCategoryDTO { get; set; }
    }
}
