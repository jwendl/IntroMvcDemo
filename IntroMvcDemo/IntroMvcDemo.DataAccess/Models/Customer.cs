using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroMvcDemo.DataAccess.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Customer")]
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [StringLength(100)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [StringLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        [StringLength(100)]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [StringLength(100)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [StringLength(100)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [StringLength(16)]
        public string ZipCode { get; set; }
    }
}
