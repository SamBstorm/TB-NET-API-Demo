using API_DBSlide.Models.StudentModels;

namespace API_DBSlide.Context
{
    public interface IStudentContext
    {
        IEnumerable<Student> Get();
        Student Get(int id);
        int Create(Student student);
        void Update(int id, Student student);
        void Delete(int id);
    }
}
