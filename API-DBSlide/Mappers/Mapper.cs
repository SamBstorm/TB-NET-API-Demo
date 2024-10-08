using API_DBSlide.Models.StudentModels;
using System.Data;

namespace API_DBSlide.Mappers
{
    public static class Mapper
    {
        public static Student ToStudent(this IDataRecord record)
        {
            if(record is null) throw new ArgumentNullException(nameof(record));
            return new Student()
            {
                StudentId = (int)record["student_id"],
                FirstName = (string)record["first_name"],
                LastName = (string)record["last_name"],
                BirthDate = (DateTime)record["birth_date"],
                Login = (string)record["login"],
                SectionId = (int)record["section_id"],
                YearResult = (record["year_result"] is DBNull) ? null : (int)record["year_result"],
                CourseId = (string)record["course_id"]
            };
        }
    }
}
