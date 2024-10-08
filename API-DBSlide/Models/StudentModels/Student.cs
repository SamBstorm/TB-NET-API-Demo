namespace API_DBSlide.Models.StudentModels
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int SectionId {  get; set; }
        public string Login { get; set; }
        public int? YearResult { get; set; }
        public string CourseId { get; set; }
    }
}
