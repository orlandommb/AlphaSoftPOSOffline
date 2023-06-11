using System.ComponentModel.DataAnnotations;

namespace  AlphaSoftPOSOffline
{
    public class UserInfo
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}