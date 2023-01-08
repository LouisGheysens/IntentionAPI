using AutoMapper;
using Business.Base;
using Business.Interface;
using Data;
using Data.Models;
using DTO.Models;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Business.Service;
public class IntentionService : IntentionBaseService, IIntentionService
{

    public IntentionService(IntentionDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<ServiceResponse<List<ChallengeDto>>> GetChallengesAsync(GridifyQuery gQuery, CancellationToken token)
    {
        var serviceResponse = new ServiceResponse<List<ChallengeDto>>();

        var (count, query) = await Context.Challenges
            .OrderBy(x => x.Id)
            .Where(x => !x.Deleted)
            .GridifyQueryableAsync(gQuery, new GridifyMapper<Challenge>().GenerateMappings()
            .AddMap("name", q => q.Name), token);

        var dbObj = Mapper.Map<List<ChallengeDto>>(query);

        if (!dbObj.Any())
        {
            serviceResponse.Success = false;
            serviceResponse.Data = new List<ChallengeDto>();
            serviceResponse.Message = "NotFound.Error";
            return serviceResponse;
        }

        serviceResponse.TotalRecords = count;
        serviceResponse.Success = true;
        serviceResponse.Data = dbObj;
        return serviceResponse;
    }

    public async Task<ServiceResponse<ChallengeDto>> GetChallenge(int id, CancellationToken token)
    {
        var serviceResponse = new ServiceResponse<ChallengeDto>();
        var challengeObj = await Context.Challenges.FirstOrDefaultAsync(x => x.Id == id, token);

        if (challengeObj is null)
        {
            serviceResponse.Success = false;
            return serviceResponse;
        }
        var dataObject = Mapper.Map<ChallengeDto>(challengeObj);

        serviceResponse.Data = dataObject;
        return serviceResponse;
    }

    public async Task<ServiceResponse<int>> AddChallenge(ChallengeDto dto, CancellationToken token)
    {
        var serviceResponse = new ServiceResponse<int>();
        var mappedChallenge = Mapper.Map<Challenge>(dto);

        Context.Challenges.Add(mappedChallenge);

        mappedChallenge.CreationDate = DateTime.Now;


        await Save(token);

        if (!await Save(token))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "CreateChallenge.Error";
            return serviceResponse;
        }

        serviceResponse.Success = true;
        serviceResponse.Data = mappedChallenge.Id;
        return serviceResponse;
    }

    public async Task<ServiceResponse<int>> UpdateChallenge(int id, ChallengeDto dto, CancellationToken token)
    {
        var serviceResponse = new ServiceResponse<int>();
        var oldChallenge = await Context.Challenges.FirstOrDefaultAsync(x => x.Id == id, token);

        if (oldChallenge == null)
        {
            serviceResponse.Success = false;
            return serviceResponse;
        }

        var mappedChallenge = Mapper.Map<Challenge>(dto);

        mappedChallenge.ModificationDate = DateTime.Now;


        Context.Entry(oldChallenge).CurrentValues.SetValues(mappedChallenge);

        await Save(token);

        if (!await Save(token))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "UpdateChallenge.Error";
            return serviceResponse;
        }

        serviceResponse.Success = true;
        serviceResponse.Data = mappedChallenge.Id;
        return serviceResponse;
    }

    public async Task<ServiceResponse<object>> DeleteChallenge(int id, CancellationToken token)
    {
        var serviceResponse = new ServiceResponse<object>();
        var oldChallenge = await Context.Challenges.FirstOrDefaultAsync(x => x.Id == id, token);

        if (oldChallenge != null) oldChallenge.Deleted = true;

        if (!await Save(token))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "DeleteChallenge.Error";
            return serviceResponse;
        }

        serviceResponse.Success = true;
        return serviceResponse;
    }
}
