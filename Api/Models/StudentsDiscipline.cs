using System;

namespace Api.Models
{
    public class StudentsDiscipline
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public StudentsDiscipline() { }

        public StudentsDiscipline(Guid studentId, Guid disciplineId)
        {
            StudentId = studentId;
            DisciplineId = disciplineId;
        }
    }
}