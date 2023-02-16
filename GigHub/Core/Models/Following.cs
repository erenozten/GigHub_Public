
namespace GigHub.Core.Models
{
    public class Following
    {
        // 1 adet following instance'ında: 1 adet takip eden, 1 adet takip edilen olur
        // İlgili navigation property ve foreign key'leri oluştur:

        public string FollowerId { get; set; }

        public string FolloweeId { get; set; }

        public ApplicationUser Follower { get; set; }

        public ApplicationUser Followee { get; set; }
    }
}