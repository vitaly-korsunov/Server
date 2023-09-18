using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Moduls;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IConfiguration? Configuration;
        public StudentsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            // DataFromDb dataFromDb = new DataFromDb();
            //  var sdr= dataFromDb.getconnection();
            //  string connString = this.Configuration.GetConnectionString("DefaultConnectionString");
            DataSet dataSet = DataFromDb.GetStudents();
            var dataTable = dataSet.Tables[0];

            List<Student> students = new List<Student>();

            for (int I = 0; I < dataTable.Rows.Count; I++)
            {
                students.Add(new Student
                {
                    Id = int.Parse("0" + dataTable.Rows[I]["Id"].ToString()),
                    name = dataTable.Rows[I]["name"].ToString(),
                    department = dataTable.Rows[I]["department"].ToString(),
                    bdate = DateTime.Parse(dataTable.Rows[I]["bdate"].ToString() + "").ToString("yyyy-MM-dd"),
                    level = int.Parse("0" + dataTable.Rows[I]["level"].ToString()),
                    gender = dataTable.Rows[I]["gender"].ToString(),
                });
            }

            return students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student value)
        {

            DataSet dataSet = DataFromDb.CreateStudent(value);
            var dataTable = dataSet.Tables[0];
            Student student = new Student();
            //student.Id = 3;
            //student.name = value.name;
            //student.department = value.department;
            //student.bdate = value.bdate;// DateTime.Now.ToString("yyyy-MM-dd");
            //student.level = value.level;
            //student.gender = value.gender;


            for (int I = 0; I < dataTable.Rows.Count; I++)
            {
                student.Id = int.Parse("0" + dataTable.Rows[I]["Id"].ToString());
                student.name = dataTable.Rows[I]["name"].ToString();
                student.department = dataTable.Rows[I]["department"].ToString();
                student.bdate = DateTime.Parse(dataTable.Rows[I]["bdate"].ToString() + "").ToString("yyyy-MM-dd");
                student.level = int.Parse("0" + dataTable.Rows[I]["level"].ToString());
                student.gender = dataTable.Rows[I]["gender"].ToString();

            }

            return student;
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Student> Put(int id, [FromBody] Student value)
        {
            DataSet dataSet = DataFromDb.UpdateStudent(value);
            var dataTable = dataSet.Tables[0];
            Student student = new Student();

            for (int I = 0; I < dataTable.Rows.Count; I++)
            {
                student.Id = int.Parse("0" + dataTable.Rows[I]["Id"].ToString());
                student.name = dataTable.Rows[I]["name"].ToString();
                student.department = dataTable.Rows[I]["department"].ToString();
                student.bdate = DateTime.Parse(dataTable.Rows[I]["bdate"].ToString() + "").ToString("yyyy-MM-dd");
                student.level = int.Parse("0" + dataTable.Rows[I]["level"].ToString());
                student.gender = dataTable.Rows[I]["gender"].ToString();
            }
            //student.Id = id;
            //student.name = value.name;
            //student.department = value.department;
            //student.bdate = value.bdate;// DateTime.Now.ToString("yyyy-MM-dd");
            //student.level = value.level;
            //student.gender = value.gender;
            return student;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool boolVal = DataFromDb.DeleteStudent(id);
            return NoContent();
        }
    }
}