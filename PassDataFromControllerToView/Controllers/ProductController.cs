using PassDataFromControllerToView.Config;
using PassDataFromControllerToView.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassDataFromControllerToView.Controllers
{
    public class ProductController : Controller
    {
        // private readonly object dtProducts;

        // GET: Product
        public ActionResult Create()
        {
            return View(new Product { Id = 0 });
        }

        /*[HttpPost]
        public ActionResult SaveProduct()
        {
            return Content("save Action is Executed");
        }*/
        /* [HttpPost]
         public ActionResult Create(Product product)
         {
             return Content("save Action is Executed");
         }*/
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand("Products_SaveorUpdate", con))

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", product.Id);
                        cmd.Parameters.AddWithValue("@Name", product.Name);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@Supplier", product.Supplier);
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
                return RedirectToAction("GetAll");
            }
            return View("Create", product);
            // string insertSQL = "INSERT INTO Products(Name,Price,Supplier)VALUES('" + product.Name + "','" + product.Price + "','" + product.Supplier + "')";
            //string updateSQL = "UPDATE Products SET Name = '"+product.Name+"',Price ='"+product.Price+"',Supplier='"+product.Supplier+"'WHERE Id='"+product.Id+"'";
            //using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            // using (SqlConnection con = new SqlConnection("Server=ANISH-RENTAL;Database=EStoreDB;User Id=sa;Password=AnisH@1357;"))

            //{
            // using (SqlCommand cmd = new SqlCommand("Products_SaveorUpdate", con))
            // using (SqlCommand cmd = new SqlCommand("INSERT INTO Products(Name,Price,Supplier)VALUES('" + product.Name + "','" + product.Price + "','" + product.Supplier + "')", con))
            // using (SqlCommand cmd = new SqlCommand(product.Id>0 ? updateSQL:insertSQL, con))


            // return Content("Record is Saved in the database");
            // return RedirectToAction("GetAll");
            // }
        }
            public ActionResult Search(string search)
            {
                List<Product> products = GetProducts("Products_SearchProduct", search);
                return View("GetAll", products);
            }




            public List<Product> GetProducts(string storeProcedure, string search)
            {
                List<Product> Products = new List<Product>();

                using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(storeProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (search != null)
                            cmd.Parameters.AddWithValue("@Filter", search);

                        if (con.State != System.Data.ConnectionState.Open)
                            con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();

                        DataTable dtProduct = new DataTable();

                        dtProduct.Load(sdr);

                        foreach (DataRow row in dtProduct.Rows)
                        {
                            Products.Add(
                                new Product
                                {
                                    Id = Convert.ToInt32(row["ID"]),
                                    Name = row["Name"].ToString(),
                                    Price = Convert.ToDecimal(row["Price"]),
                                    Supplier = row["Supplier"].ToString()
                                }


                                );
                        }
                    }
                }
                return Products;
            }

            
            public ActionResult GetAll()
            {
                List<Product> Products = GetProducts("Product_GetAllProduct", null);

                return View(Products);
            }

            /*// using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
           //  {
                // using (SqlCommand cmd = new SqlCommand("Products_GetAllProduct", con))
                 //{
                    // cmd.CommandType = CommandType.StoredProcedure;
                     //if (con.State != System.Data.ConnectionState.Open)
                      //   con.Open();
                    // SqlDataReader sdr = cmd.ExecuteReader();

                    // DataTable dtProduct = new DataTable();

                    // dtProduct.Load(sdr);

                    // foreach (DataRow row in dtProduct.Rows)
                    // {
                        // Products.Add(
                           //  new Product
                            // {
                              //   Id = Convert.ToInt32(row["ID"]),
                               //  Name = row["Name"].ToString(),
                               //  Price = Convert.ToDecimal(row["Price"]),
                                // Supplier = row["Supplier"].ToString()
                          //   }


                           //  );
                    // }
                // }
             //}*/





            public ActionResult Delete(int id)
            {
                if (id < 0)
                    return HttpNotFound();

                using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
                {
                    //using (SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE Id = '" + id + "'", con))
                    using (SqlCommand cmd = new SqlCommand("Product_DeleteById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("GetAll");
            }
            public ActionResult Edit(int id)
            {
                if (id <= 0)
                    return HttpNotFound();
                var product = new Product();
                using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
                {
                    //using (SqlCommand cmd = new SqlCommand("SELECT * FROM Products where Id= '" + id + "'", con))
                    using (SqlCommand cmd = new SqlCommand("Product_GetById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        if (sdr.HasRows)
                        {
                            dt.Load(sdr);
                            DataRow row = dt.Rows[0];

                            product.Id = Convert.ToInt32(row["Id"]);
                            product.Name = row["Name"].ToString();
                            product.Price = Convert.ToDecimal(row["Price"]);
                            product.Supplier = row["Supplier"].ToString();

                            return View("Create", product);
                        }
                        else
                        {
                            return HttpNotFound();
                        }
                    }
                }
            }

        }
    }

