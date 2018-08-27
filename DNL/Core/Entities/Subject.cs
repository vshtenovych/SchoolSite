using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
