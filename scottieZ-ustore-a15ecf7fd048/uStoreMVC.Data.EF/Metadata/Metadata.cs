using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace uStoreMVC.Data.EF//.Metadata
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category { }
    public class CategoryMetadata
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
    }//end CategoryMetadata

    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department { }
    public class DepartmentMetadata
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Department")]
        public string DeptName { get; set; }

        public Nullable<int> DeptHeadID { get; set; }
    }//end DepartmentMetadata

    [MetadataType(typeof(EmployeesMetadata))]
    public partial class Employees { }
    public class EmployeesMetadata
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "First Name")]
        [StringLength(25, ErrorMessage = "25 characters or less***")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Last Name")]
        [StringLength(25, ErrorMessage = "50 characters or less***")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid Email address***")]
        public string Email { get; set; }

        [Display(Name = "Date of Hire")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public System.DateTime StartDate { get; set; }

        public Nullable<int> DirectReportID { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Please enter department ID")]
        public int DeptID { get; set; }

        [Display(Name = "Date of Separation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<System.DateTime> SeparationDate { get; set; }

        [Required(ErrorMessage = "Required**")]
        [Display(Name = "Contractor?")]
        public bool isContractor { get; set; }

    }//end EmployeesMetadata

    [MetadataType(typeof(ProductCategoryMetadata))]
    public partial class ProductCategory { }
    public class ProductCategoryMetadata
    {
        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Product Category ID")]
        public int ProductCategoryID { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

    }//end ProductCategoryMetadata

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }
    public class ProductMetadata
    {
        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = ("Product Name"))]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters**")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        [UIHint("Multiline")]
        public string ProductDescription { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Units in Stock")]
        public Nullable<byte> UnitsInStock { get; set; }

        [Display(Name = "Product Image")]
        [StringLength(75, ErrorMessage = "Image filepath must be less than 75 characters***")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Product Availability")]
        public byte ProductStatusID { get; set; }

    }//end ProductMetadata

    [MetadataType(typeof(ProductStatus))]
    public partial class ProductStatus { }
    public class ProductStatusMetadata
    {
        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Product Status ID")]
        public byte ProductStatusID { get; set; }

        [Required(ErrorMessage = "Required***")]
        [Display(Name = "Status")]
        [StringLength(25, ErrorMessage = "Status must be less than 20 characters***")]
        public string StatusName { get; set; }

    }// end ProductStatusMetadata

}
