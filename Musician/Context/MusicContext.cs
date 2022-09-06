using Microsoft.EntityFrameworkCore;
using Musician.Models;
namespace Musician.Context
{
    public class MusicContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MusicianDB;Trusted_Connection=True;");
        }

        public DbSet<Musiciann> Musicians { get; set; }
        public DbSet<Album> Albums { get; set; }

        public DbSet<Instrument> Instruments { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<AlbumSong> AlbumSongs { get; set; }

    }
}
