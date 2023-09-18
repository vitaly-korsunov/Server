using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Moduls;
using System.Data;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        // GET: api/<Departments>
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            // DataFromDb dataFromDb = new DataFromDb();
            //  var sdr= dataFromDb.getconnection();
            //  string connString = this.Configuration.GetConnectionString("DefaultConnectionString");
            DataSet dataSet = DataFromDb.GetDepartments();
            var dataTable = dataSet.Tables[0];

            List<Department> departments = new List<Department>();

            for (int I = 0; I < dataTable.Rows.Count; I++)
            {
                departments.Add(new Department
                {
                    Id = int.Parse("0" + dataTable.Rows[I]["Id"].ToString()),
                    department = dataTable.Rows[I]["department"].ToString()

                });
            }
            return departments;
        }

    }
}
