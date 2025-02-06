using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustimzeAuth.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }   
        [Required(ErrorMessage = "This Field Name is Required!")]
        public string Name { get; set; }   
        [Required(ErrorMessage = "This Field password is Required!")]
        public string Password { get; set; }   
    }
}
