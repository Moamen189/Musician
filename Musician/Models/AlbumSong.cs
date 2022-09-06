using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musician.Models
{
    public class AlbumSong
    {
        [Key]
        public string TitleSong { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
        public virtual Album Album { get; set; }

    }
}
