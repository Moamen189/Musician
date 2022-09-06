using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musician.Models
{
    public class Song
    {
        [Key]
        public string Title { get; set; }
        [MaxLength(100)]

        public string Author { get; set; }
       
        public virtual ICollection<Musiciann> Musicians { get; set; } = new HashSet<Musiciann>();
        public virtual AlbumSong AlbumSong { get; set; }


    }
}
