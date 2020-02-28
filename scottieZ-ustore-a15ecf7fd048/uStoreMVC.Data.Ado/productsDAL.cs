using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using uStoreMVC.Domain;
using System.Web.Configuration;
using System.Configuration;

namespace uStoreMVC.Data.Ado
{
    public class productsDAL
    {
        string connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public string GetProductNames()
        {
            string products = ""; //rtv
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Data Source = .\SQL_AGAIN;Initial Catalog = uStore;Integrated Security=true;";
                conn.Open();
                SqlCommand cmdGetProductNames = new SqlCommand("Select ProductName from products", conn);
                SqlDataReader rdrProducts = cmdGetProductNames.ExecuteReader();

                products = "<ul>";
                while (rdrProducts.Read())
                {
                    products += "<li> " + (string)rdrProducts["ProductName"] + "<li>";
                }//end while

                products += "</ul>";

                rdrProducts.Close();
                conn.Close();
            }//end using
            return products;
        }//end get product names


        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            //create sql connection
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmdGetProducts = new SqlCommand("Select * from Products", conn);
                SqlDataReader rdrProducts = cmdGetProducts.ExecuteReader();
                while (rdrProducts.Read())
                {
                    ProductModel prod = new ProductModel()
                    {
                        ProductID = (int)rdrProducts["ProductID"],
                        ProductStatusID = (int)rdrProducts["ProductStatusID"],
                        ProductName = (string)rdrProducts["ProductName"],

                        Price = (rdrProducts["Price"] is DBNull) ? 0 : (double)rdrProducts["Price"],
                        ProductDescription = (rdrProducts["ProductDescription"] is DBNull) ? "NA" : (string)rdrProducts["ProductDescription"],
                        UnitsInStock = (rdrProducts["UnitsInStock"] is DBNull) ? (byte)0 : (byte)rdrProducts["UnitsInStock"],
                        ProductImage = (rdrProducts["ProductImage"] is DBNull) ? "NA" : (string)rdrProducts["ProductImage"]

                    };
                        products.Add(prod);
                }//end while/prod
                rdrProducts.Close();
                conn.Close();
            }//end using
            return products;
        }//end GetProducts()

        public void CreateProducts(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmdInsertProduct = new SqlCommand
                    (
                    @"Insert into Products
                        (ProductName, Price, UnitsInStock, ProductDescription)
                            Values(@ProductName, @Price, @UnitsInStock, @ProductDescription)"
                        , conn);
                cmdInsertProduct.Parameters.AddWithValue("ProductName", product.ProductName);


                if (product.Price != 0)
                {
                    cmdInsertProduct.Parameters.AddWithValue("Price", product.Price);
                }
                else { cmdInsertProduct.Parameters.AddWithValue("Price", DBNull.Value); }

                if (product.UnitsInStock != 0)
                {
                    cmdInsertProduct.Parameters.AddWithValue("UnitsInStock", product.UnitsInStock);
                }
                else { cmdInsertProduct.Parameters.AddWithValue("UnitsInStock", DBNull.Value); }

                if (product.ProductDescription != null)
                {
                    cmdInsertProduct.Parameters.AddWithValue("ProductDescription", product.ProductDescription);
                }
                else { cmdInsertProduct.Parameters.AddWithValue("ProductDescription", DBNull.Value); }

                cmdInsertProduct.ExecuteNonQuery();
                conn.Close();
            }//end using
        }//end createproducts()

        public ProductModel GetProduct(int id, int fk)
        {
            ProductModel prod = null; //rtv
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmdGetProduct = new SqlCommand(
                    "Select * from products where ProductID = @ProductID"
                    ,conn);
                cmdGetProduct.Parameters.AddWithValue("ProductID", id);
                cmdGetProduct.Parameters.AddWithValue("ProductStatusID", fk);
                SqlDataReader rdr = cmdGetProduct.ExecuteReader();
                if (rdr.Read())
                {
                    prod = new ProductModel()
                    {
                        ProductID = (int)rdr["ProductID"],
                        ProductName = (string)rdr["ProductName"],
                        ProductStatusID = (int)rdr["ProductStatusID"],

                        ProductDescription = (rdr["ProductDescription"] is DBNull) ? "NA" : (string)rdr["ProductDescription"],
                        Price = (rdr["Price"] is DBNull) ? 0 : (double)rdr["Price"],
                        UnitsInStock = (rdr["UnitsInStock"] is DBNull) ? (byte)0 : (byte)rdr["UnitsInStock"],
                        ProductImage = (rdr["ProductImage"] is DBNull) ? "NA" : (string)rdr["ProductImage"]                      
                    };//end prod
                }//end if
                rdr.Close();
                conn.Close();
            }//end using
            return prod;
        }//end GetProduct()

        public void UpdateProduct(ProductModel product) {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmdUpdateProduct = new SqlCommand(
                    @"Update Products set
                        ProductName = @ProductName,
                        Price = @Price,
                        ProductImage = @ProductImage,
                        UnitsInStock = @UnitsInStock,
                        ProductDescription = @ProductDescription,
                        ProductStatusID = @ProductStatusID
                        Where ProductID = @ID"  ,conn);

                cmdUpdateProduct.Parameters.AddWithValue("ID", product.ProductID);
                cmdUpdateProduct.Parameters.AddWithValue("ProductStatusID", product.ProductStatusID);
                cmdUpdateProduct.Parameters.AddWithValue("ProductName", product.ProductName);
                //nullables
                if (product.Price != 0) { cmdUpdateProduct.Parameters.AddWithValue("Price", product.Price); }
                else { cmdUpdateProduct.Parameters.AddWithValue("Price", DBNull.Value); }

                if (product.ProductImage != null) { cmdUpdateProduct.Parameters.AddWithValue("ProductImage", product.ProductImage); }
                else { cmdUpdateProduct.Parameters.AddWithValue("ProductImage", DBNull.Value); }

                if (product.UnitsInStock != 0) { cmdUpdateProduct.Parameters.AddWithValue("UnitsInStock", product.UnitsInStock); }
                else { cmdUpdateProduct.Parameters.AddWithValue("UnitsInStock", DBNull.Value); }

                if (product.ProductDescription != null) { cmdUpdateProduct.Parameters.AddWithValue("ProductDescription", product.ProductDescription); }
                else { cmdUpdateProduct.Parameters.AddWithValue("ProductDescription", DBNull.Value); }

                cmdUpdateProduct.ExecuteNonQuery();
                conn.Close();
            }//end using
        }//end UpdateProduct()

        public void DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmdDeleteAuthor = new SqlCommand(
                    "delete from products where ProductID = @ProductID"                                        
                    ,conn);
                cmdDeleteAuthor.Parameters.AddWithValue("ProductID", id);
                cmdDeleteAuthor.ExecuteNonQuery();
                conn.Close();
            }//end using
        }//end DeleteProduct()

    }
}
