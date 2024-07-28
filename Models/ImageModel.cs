using System.ComponentModel.DataAnnotations;

namespace MyFriends22.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }

        public int FriendId { get; set; }
        public FriendModel Friend { get; set; }

        [Display(Name = "תמונה")]
        public byte[] MyImage { get; set; }


    }
}
