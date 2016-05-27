using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroMvcDemo.DataAccess.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Artist")]
    public class Artist
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Display(Name = "Artist Name")]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the albums.
        /// </summary>
        public ICollection<Album> Albums { get; set; }
    }
}
