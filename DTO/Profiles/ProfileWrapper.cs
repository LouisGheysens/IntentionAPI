using Data.Models;
using DTO.Base;
using DTO.Models;

namespace DTO.Profiles;
internal class ProfileWrapper: ProfileBase<ChallengeDto, Challenge>
{
    public override void CreateMapping()
    {
        CreateMap<Challenge, ChallengeDto>()
            .ReverseMap();
        base.CreateMapping();
    }
}
