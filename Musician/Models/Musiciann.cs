using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musician.Models
{
    public class Musiciann
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int Phone { get; set; }
        public string City { get; set; }

        public string Street { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
        public virtual ICollection<Instrument> Instruments { get; set; } = new HashSet<Instrument>();
        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();


    }
}
