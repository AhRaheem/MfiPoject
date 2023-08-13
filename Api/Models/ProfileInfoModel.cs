using Infrastructure.Dtos.ProfileInfo;

namespace Api.Models
{
    public class ProfileInfoModel
    {
        public List<ProfileInfoDto>? ContactUs { get; set; }
        public List<ProfileInfoDto>? SocialMedia { get; set; }
        public List<ProfileInfoDto>? BankAccountNumbers { get; set; }
        public List<ProfileInfoDto>? HotLines { get; set; }
        public ProfileInfoDto? MapLocation { get; set; }
    }
}
