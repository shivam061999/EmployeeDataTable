using EmployeeDataTable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace EmployeeDataTable.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString = "Data Source=DESKTOP-ETVLLV3;Initial Catalog=TestDB;Integrated Security=True";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //here
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            //using (desktop-etvllv3.TestDB.dbo dbs = new desktop-etvllv3.TestDB.dbo());
            {
                if(ModelState.IsValid) 
                {
                   // dbs.EmployeeModel.Add(employeeModel);
                   // dbs.SaveChanges();
                   using( SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("InsertUpdate", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@EmployeeID", employeeModel.EmployeeID);
                            command.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                            command.Parameters.AddWithValue("@EmpAge", employeeModel.EmpAge);
                            command.Parameters.AddWithValue("@EmpCity", employeeModel.EmpCity);
                            command.Parameters.AddWithValue("@EmpDepartment", employeeModel.EmpDepartment);
                            command.Parameters.AddWithValue("@EmpManager", employeeModel.EmpManager);
                            command.Parameters.AddWithValue("@JoiningDate", employeeModel.JoiningDate);
                            command.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                            command.Parameters.AddWithValue("@StatementType", "Insert");
                            command.ExecuteNonQuery();
                        }
                    }
                    ViewBag.Success = "Data Inserted";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View(employeeModel);
        }




    }
}