using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musician.Models
{
    public class Album
    {
        [Key]

        public int Id { get; set; }

        public DateTime Date { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [ForeignKey("Musician")]
        public int MusicianId { get; set; }
        public virtual Musiciann Musician { get; set; }

        public virtual AlbumSong AlbumSong { get; set; }



    }
}
