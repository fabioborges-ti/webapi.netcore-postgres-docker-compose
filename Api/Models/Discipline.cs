using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class Discipline : Base
    {
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public IEnumerable<StudentsDiscipline> StudentsDisciplines { get; set; }

        public Discipline() { }

        public Discipline(Guid id, string name, Guid teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }
    }
}