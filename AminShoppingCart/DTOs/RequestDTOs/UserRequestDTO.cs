using System.ComponentModel.DataAnnotations;

namespace AminShoppingCart.DTOs.RequestDTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }
    }
}
