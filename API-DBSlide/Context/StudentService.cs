using API_DBSlide.Mappers;
using API_DBSlide.Models.StudentModels;
using Microsoft.Data.SqlClient;

namespace API_DBSlide.Context
{
    public class StudentService : IStudentContext
    {
        private string _connectionString;
        public StudentService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DBSlideASP");
        }
        public int Create(Student student)
        {
            Dictionary<string, object?> parameters = new Dictionary<string, object?>() {
                {"fn", student.FirstName },
                {"ln", student.LastName },
                {"bd", student.BirthDate },
                {"login", student.Login },
                {"s_id", student.SectionId },
                {"yr", student.YearResult },
                {"c_id", student.CourseId }
            };
            using(SqlCommand command = CreateCommand("INSERT INTO student (first_name, last_name, birth_date, section_id, login, year_result, course_id) OUTPUT inserted.student_id VALUES (@fn, @ln, @bd, @s_id, @login, @yr, @c_id)", parameters))
            {
                command.Connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            Dictionary<string, object?> parameters = new Dictionary<string, object?>() {
                    { "id", id }
                };
            using (SqlCommand command = CreateCommand("DELETE FROM student WHERE student_id = @id", parameters))
            {
                command.Connection.Open();
                int row = command.ExecuteNonQuery();
                if(row <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            }
        }

        public IEnumerable<Student> Get()
        {
            using (SqlCommand command = CreateCommand("SELECT student_id, first_name, last_name, birth_date, login, section_id, year_result, course_id FROM student"))
            {
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        yield return reader.ToStudent();
                    }
                }
            }
        }

        public Student Get(int id)
        {
            Dictionary<string, object?> parameters = new Dictionary<string, object?>() {
                    { "id", id }
                };
            using (SqlCommand command = CreateCommand("SELECT student_id, first_name, last_name, birth_date, login, section_id, year_result, course_id FROM student WHERE student_id = @id", parameters))
            {
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.Read()) { return reader.ToStudent(); }
                    throw new ArgumentOutOfRangeException(nameof(id));
                }
            }
        }

        public void Update(int id, Student student)
        {
            Dictionary<string, object?> parameters = new Dictionary<string, object?>() {
                {"id", id },
                {"fn", student.FirstName },
                {"ln", student.LastName },
                {"bd", student.BirthDate },
                {"login", student.Login },
                {"s_id", student.SectionId },
                {"yr", student.YearResult },
                {"c_id", student.CourseId }
            };
            using(SqlCommand command = CreateCommand("UPDATE student SET first_name = @fn, last_name = @ln, birth_date = @bd, login = @login, section_id = @s_id, year_result = @yr, course_id = @c_id WHERE student_id = @id", parameters))
            {
                command.Connection.Open();
                int row = command.ExecuteNonQuery();
                if(row <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            }
        }

        private SqlCommand CreateCommand(string query, Dictionary<string, object?>? parameters = null)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            if (parameters is not null)
            {
                foreach (KeyValuePair<string, object?> kvp in parameters)
                {
                    command.Parameters.AddWithValue(kvp.Key, kvp.Value ?? DBNull.Value);
                }
            }
            return command;
        }
    }
}
