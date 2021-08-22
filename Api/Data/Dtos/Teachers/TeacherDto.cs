using System;

namespace Api.Data.Dtos.Teachers
{
    public class TeacherDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
