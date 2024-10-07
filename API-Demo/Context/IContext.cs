using API_Demo.Models;

namespace API_Demo.Context
{
    public interface IContext
    {
        public List<Employee> Employees { get; set; }
    }
}
