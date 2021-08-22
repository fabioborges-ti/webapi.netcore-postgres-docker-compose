using System;

namespace Api.Data.Dtos.Students
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
