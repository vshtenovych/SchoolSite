using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateOfPost { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Photo { get; set; }
    }
}
