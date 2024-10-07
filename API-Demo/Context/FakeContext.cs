using API_Demo.Models;

namespace API_Demo.Context
{
    public class FakeContext : IContext
    {
        private static List<Employee> _employees;

        public FakeContext()
        {
            _employees = new List<Employee>() {
                new Employee(){ Id = 1, FirstName = "Samuel", LastName = "Legrain" },
                new Employee(){ Id = 2, FirstName = "Aude", LastName = "Beurive" },
                new Employee(){ Id = 3, FirstName = "Thierry", LastName = "Morre" },
                new Employee(){ Id = 4, FirstName = "Michael", LastName = "Person" },
                new Employee(){ Id = 5, FirstName = "Quentin", LastName = "Geerts" },
                new Employee(){ Id = 6, FirstName = "Sébastien", LastName = "Bya" }
            }; 
        }

        public List<Employee> Employees { 
            get {
                return _employees;
            }
            set { 
                _employees = value; 
            } 
        }
    }
}
