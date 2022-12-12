using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetCoreApiSample.Controllers
{
    public class Student // Khai báo Thuộc tính của Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    [Route("api/students")] // -- tạo router API student

    [ApiController]
    public class StudentApiController : ControllerBase // -- kế thừa lớp ControllerBase of System
    {
        private readonly IList<Student> list = new List<Student>() // -- insert data 
        {
            new Student {Id = 1, Name = "Tommy" },
            new Student {Id = 2, Name = "John" },
            new Student {Id = 3, Name = "Michale" },
            new Student {Id = 4, Name = "Grabriel" },
            new Student {Id = 5, Name = "Lena" },
            new Student {Id = 6, Name = "Lola" }
        };

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var student = list.FirstOrDefault(l => l.Id == id);
            return Ok(student);
        }

        [HttpGet]

        public IActionResult GetFromRoutePath([FromQuery] string name)
        {
            var students = list.Where(n => n.Name.Contains(name))?.ToList();
            return Ok(students);
        }

        [HttpPost]


        public IActionResult Add([FromBody] string value)
        {
            list.Add(new Student
            {
                Id = list[list.Count - 1].Id + 1,
                Name = value
            });
            return Ok(list);
        }

        [HttpPut("{id}")]


        public IActionResult Update(int id, [FromBody] string value)
        {
            var current = list.FirstOrDefault(l => l.Id == id);
            if (current == null) return BadRequest();
            current.Name = value;
            return Ok(list);
        }

        [HttpDelete("{id}")]


        public IActionResult DeleteById([FromRoute] int id)
        {
            var current = list.FirstOrDefault(l => l.Id == id);
            if (current == null) return BadRequest();
            list.Remove(current);
            return Ok(list);
        }
    }


}
