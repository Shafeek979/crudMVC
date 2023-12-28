using crudMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace crudMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: database
        SqlConnection con = new SqlConnection("Data Source=DEKSTOP;Initial Catalog=Allservices;Integrated Security=True");
        public bool insert(DataModel employee)
        {
            int i = 0;
            {
                SqlCommand cmd = new SqlCommand("InsertTbl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("Address", employee.Address);
                con.Open();
                i = cmd.ExecuteNonQuery();
                ModelState.Clear();
                con.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}