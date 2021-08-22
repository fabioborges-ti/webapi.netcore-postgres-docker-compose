using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class Teacher : Base
    {
        public string Name { get; set; }

        public IEnumerable<Discipline> Disciplines { get; set; }

        public Teacher(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}