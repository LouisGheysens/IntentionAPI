using Gridify;
using DTO.Models;

namespace Business.Interface;
public interface IIntentionService
{
    Task<ServiceResponse<List<ChallengeDto>>> GetChallengesAsync(GridifyQuery gQuery, CancellationToken token);
    Task<ServiceResponse<ChallengeDto>> GetChallenge(int id, CancellationToken token);
    Task<ServiceResponse<int>> UpdateChallenge(int id, ChallengeDto dto, CancellationToken token);
    Task<ServiceResponse<int>> AddChallenge(ChallengeDto dto, CancellationToken token);
    Task<ServiceResponse<object>> DeleteChallenge(int id, CancellationToken token);
}
