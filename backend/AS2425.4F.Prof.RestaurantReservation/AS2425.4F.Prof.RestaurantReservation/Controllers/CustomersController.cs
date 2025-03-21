using AS2425._4G.Prof.IoTForHealtBE.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using System.Numerics;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AS2425._4F.Prof.RestaurantReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DatabaseHelper _dbHelper;

        public CustomersController(IConfiguration configuration)
        {
            _dbHelper = new DatabaseHelper(configuration);
        }

        [HttpGet]
        [Authorize] // 🔒 This endpoint requires a valid JWT token
        public IActionResult GetCustomers()
        {
            try
            {
                string query = @"
                    SELECT 
                        first_name, last_name, phone, email
                    FROM 
                        Customers";

                DataTable customersTable = _dbHelper.ExecuteQuery(query);

                // method 1 with System.Text.Json
                //var customers = new List<Customer>();

                //foreach (DataRow row in customersTable.Rows)
                //{
                //    customers.Add(new Customer
                //    {
                //        Customer_Id = Convert.ToInt32(row["patient_id"]),
                //        Name = row["name"].ToString(),
                //        Email = row["email"].ToString()
                //    });
                //}

                //return Ok(customers);

                // method 2 with Newtonsoft
                string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(customersTable);

                return Content(jsonResult, "application/json"); // Explicit JSON response
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        [Authorize] // 🔒 This endpoint requires a valid JWT token
        public IActionResult Get(int id)
        {
            try
            {
                string query = @"
                    SELECT 
                        first_name, last_name, phone, email
                    FROM 
                        Customers
                    WHERE 
                        customer_id = @id";

                var parameters = new List<NpgsqlParameter>
                {
                    new NpgsqlParameter("@id", id)
                };

                DataTable customersTable = _dbHelper.ExecuteQuery(query, parameters); // Pass parameters securely

                string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(customersTable);

                return Content(jsonResult, "application/json"); // Explicit JSON response
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    error = ex.Message
                });
            }
        }

        // GET api/<CustomersController>/search
        // GET with body (not recomended)
        [HttpGet("search")]
        [Authorize] // 🔒 This endpoint requires a valid JWT token
        public IActionResult SearchPatients([FromBody] JsonElement request)
        {
            try
            {
                string query = @"
                    SELECT 
                        first_name, last_name, phone, email
                    FROM 
                        Customers
                    WHERE 
                        first_name = @first_name";

                var parameters = new List<NpgsqlParameter>
                {
                    new NpgsqlParameter("@first_name", request.GetProperty("first_name").GetString())
                };

                DataTable customersTable = _dbHelper.ExecuteQuery(query, parameters); // Pass parameters securely

                string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(customersTable);

                return Content(jsonResult, "application/json"); // Explicit JSON response
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    error = ex.Message
                });
            }

        }

        // POST api/<CustomersController>
        [HttpPost]
        [Authorize] // 🔒 This endpoint requires a valid JWT token
        public IActionResult Post([FromBody] JsonElement request)
        {
            try
            {
                string query = @"
                    INSERT INTO 
                        Customers (first_name, last_name, phone, email, password) 
                    VALUES 
                        (@first_name, @last_name, @phone, @email, @password)";

                var parameters = new List<NpgsqlParameter>
                {
                    new NpgsqlParameter("@first_name", request.GetProperty("first_name").GetString()),
                    new NpgsqlParameter("@last_name", request.GetProperty("last_name").GetString()),
                    new NpgsqlParameter("@phone", request.GetProperty("phone").GetString()),
                    new NpgsqlParameter("@email", request.GetProperty("email").GetString()),
                    new NpgsqlParameter("@password", request.GetProperty("password").GetString())
                };

                var rowsAffected = _dbHelper.ExecuteNonQuery(query, parameters);

                return Ok(new { message = "Customer added successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }

        }


        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        [Authorize] // 🔒 This endpoint requires a valid JWT token
        public IActionResult Put(int id, [FromBody] JsonElement request)
        {
            try
            {
                string query = @"
                    UPDATE Customers
                    SET 
                        first_name = @first_name,
                        last_name = @last_name,
                        phone = @phone,
                        email = @email,
                        password = @password
                    WHERE 
                        customer_id = @id";

                var parameters = new List<NpgsqlParameter>
                {
                    new NpgsqlParameter("@id", id),
                    new NpgsqlParameter("@first_name", request.GetProperty("first_name").GetString()),
                    new NpgsqlParameter("@last_name", request.GetProperty("last_name").GetString()),
                    new NpgsqlParameter("@phone", request.GetProperty("phone").GetString()),
                    new NpgsqlParameter("@email", request.GetProperty("email").GetString()),
                    new NpgsqlParameter("@password", request.GetProperty("password").GetString())
                };

                var rowsAffected = _dbHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    return Ok(new { message = $"Customer with ID {id} updated successfully" });
                }
                else
                {
                    return NotFound(new { message = $"Customer with ID {id} not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
            }
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        [Authorize] // 🔒 This endpoint requires a valid JWT token
        public IActionResult Delete(int id)
        {
            try
            {
                string query = @"
                    DELETE FROM 
                        Customers 
                    WHERE 
                        customer_id = @id";

                var parameters = new List<NpgsqlParameter>
                {
                    new NpgsqlParameter("@id", id)
                };

                var rowsAffected = _dbHelper.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    return Ok(new { message = $"Customer with ID {id} deleted successfully" });
                }
                else
                {
                    return NotFound(new { message = $"Customer with ID {id} not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    error = ex.Message
                });
            }
        }
    }
}
