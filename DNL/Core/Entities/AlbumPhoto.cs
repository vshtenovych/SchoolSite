using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class AlbumPhoto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Photo { get; set; }

        [ForeignKey(nameof(Entities.Album)), Required]
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
