using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }

        [ForeignKey(nameof(Entities.MethodicalAssociation)), Required]
        public int MethodicalAssociationId { get; set; }
        public MethodicalAssociation MethodicalAssociation { get; set; }

        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
