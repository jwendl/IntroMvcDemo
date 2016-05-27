using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroMvcDemo.DataAccess.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Album")]
    public class Album
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Display(Name = "Album Name")]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the artist unique identifier.
        /// </summary>
        public int ArtistId { get; set; }

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

        /// <summary>
        /// Gets or sets the relative path.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the songs.
        /// </summary>
        public ICollection<Song> Songs { get; set; }
    }
}
