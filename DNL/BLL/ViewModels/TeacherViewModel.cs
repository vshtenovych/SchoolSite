using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string UserId { get; set; }
        public string Photo { get; set; }
        public string FirstName { get; set; }
        public bool IsManager { get; set; }
        public AdministrationPositionEnum AdminPosition { get; set; }
        public string LastName { get; set; }
        public CategoryEnum Category { get; set; }
        public RankEnum Rank { get; set; }
        public string MethodicalAssociation { get; set; }

        public List<string> Subjects { get; set; }
    }
}
