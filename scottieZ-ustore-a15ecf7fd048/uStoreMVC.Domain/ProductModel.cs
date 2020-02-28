using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace uStoreMVC.Domain
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Prouct Name is required****")]
        [StringLength(50, ErrorMessage = "Product Name must be less than 50 characters****")]
        public string ProductName { get; set; }

        [StringLength(500, ErrorMessage = "Description must be less than 500 characters****")]
        public string ProductDescription { get; set; }


        public double Price { get; set; }


        public byte UnitsInStock { get; set; }


        [StringLength(75, ErrorMessage = "Filepath must be under 75 characters*****")]
        public string ProductImage { get; set; }


        [Required]
        public int ProductStatusID { get; set; }

    }
}
