using API_Demo.Context;
using API_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IContext _context;
        private static List<Employee> _employees = new List<Employee>() {
                new Employee(){ Id = 1, FirstName = "Samuel", LastName = "Legrain" },
                new Employee(){ Id = 2, FirstName = "Aude", LastName = "Beurive" },
                new Employee(){ Id = 3, FirstName = "Thierry", LastName = "Morre" },
                new Employee(){ Id = 4, FirstName = "Michael", LastName = "Person" },
                new Employee(){ Id = 5, FirstName = "Quentin", LastName = "Geerts" },
                new Employee(){ Id = 6, FirstName = "Sébastien", LastName = "Bya" }
            };

        public EmployeeController(IContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/api/AllEmployees")]
        [Route("/api/Employees")]
        [Route("/api/Employee")]
        public IEnumerable<Employee> Get()
        {
            return _employees;
        }

        [HttpGet("{id:int:min(1):max(1024):even}")]
        public Employee? Get(int id) 
        { 
            return _employees.SingleOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public int Post(Employee employee) 
        { 
            int maxId = _employees.Max(e => e.Id);
            employee.Id = maxId + 1;
            _employees.Add(employee);
            return employee.Id;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee? emp = Get(id);
            if (emp is not null)
            {
                _employees.Remove(emp);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, Employee employee)
        {
            Employee? emp = Get(id);
            if (emp is not null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
            }
        }
    }
}
