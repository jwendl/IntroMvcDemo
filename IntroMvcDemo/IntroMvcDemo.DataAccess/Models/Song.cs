using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroMvcDemo.DataAccess.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Song")]
    public class Song
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [StringLength(256)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        [StringLength(64)]
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the tiny song link.
        /// </summary>
        [StringLength(64)]
        public string TinySongLink { get; set; }

        /// <summary>
        /// Gets or sets the album unique identifier.
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the album.
        /// </summary>
        [ForeignKey("AlbumId")]
        public Album Album { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        [ForeignKey("OrderId")]
        public ICollection<Order> Orders { get; set; }
    }
}
