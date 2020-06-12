using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreTutorials.Models
{
    class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
}
