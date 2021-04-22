using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rockstars_Frontend.Models
{
    public class TribeMember
    {
        public int UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public MemberRole Role { get; set; }

        public int TribeId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(TribeId))]
        public Tribe Tribe { get; set; }
    }
}