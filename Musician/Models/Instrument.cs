using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musician.Models
{
    public class Instrument
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string Key { get; set; }

        public virtual ICollection<Musiciann> Musicians { get; set; } = new HashSet<Musiciann>();

    }
}
