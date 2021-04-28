using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rockstars_Frontend.Models
{
    public class TribeMember
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public MemberRole Role { get; set; }

        public int TribeId { get; set; }

        public enum MemberRole
        {
            Normal = 0,
            TribeLead = 1,
            SpecialAgent = 2,
        }
    }
}