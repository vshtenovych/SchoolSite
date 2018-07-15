using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF.Entities
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateOfPost { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Photo { get; set; }
    }
}
