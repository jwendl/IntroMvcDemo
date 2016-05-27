using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroMvcDemo.DataAccess.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Order")]
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer unique identifier.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the songs.
        /// </summary>
        [ForeignKey("SongId")]
        public ICollection<Song> Songs { get; set; }
    }
}
