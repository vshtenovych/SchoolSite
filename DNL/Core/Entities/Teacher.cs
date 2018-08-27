using Core.Enums;
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

        public bool IsManager { get; set; }

        public string AdditionalPosition { get; set; }




        [Required]
        public virtual int RankId
        {
            get => (int)Rank;
            set => Rank = (RankEnum)value;
        }
        [NotMapped]
        public RankEnum Rank { get; set; }




        [Required]
        public virtual int CategoryId
        {
            get => (int)Category;
            set => Category = (CategoryEnum)value;
        }
        [NotMapped]
        public CategoryEnum Category { get; set; }



        [ForeignKey(nameof(Entities.MethodicalAssociation)), Required]
        public int MethodicalAssociationId { get; set; }
        public MethodicalAssociation MethodicalAssociation { get; set; }



        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
