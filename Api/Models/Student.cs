using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class Student : Base
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }

        public IEnumerable<StudentsDiscipline> StudentsDisciplines { get; set; }

        public Student(Guid id, string name, string lastname, string phone)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Phone = phone;
        }
    }
}