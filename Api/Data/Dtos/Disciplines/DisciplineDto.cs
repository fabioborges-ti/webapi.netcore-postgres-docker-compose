using Api.Models;
using System;

namespace Api.Data.Dtos.Disciplines
{
    public class DisciplineDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
