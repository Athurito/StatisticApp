using Statistic.Application.DTOs;
using Statistic.Domain.Entities;
using Statistic.Domain.Enums;
using Statistic.Domain.Repositories;

namespace Statistic.Application.Services;

public class VisitorService : IVisitorService
{
    private readonly IVisitorRepository _visitorRepository;

    public VisitorService(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task CreateVisitor(VisitorDto visitorDto)
    {
        var visitor = ConvertDtoToVisitor(visitorDto);

        await _visitorRepository.CreateVisitor(visitor);
    }

    public async Task<IEnumerable<VisitorDto>> GetAll()
    {
        var visitors = await _visitorRepository.GetAll();
        var visitorList = visitors.ToList();
        
        if (visitorList.Count == 0)
        {
            return Enumerable.Empty<VisitorDto>();
        }
        
        return visitorList.Select(ConvertVisitorToDto).ToList();;
    }

    private static VisitorDto ConvertVisitorToDto(Visitor visitor)
    {
        var visitorDto = new VisitorDto
        {
            CreateDate = visitor.CreateDate,
            AddressDto = ConvertAddressToDto(visitor.Address!),
            VisitorInterests = ConvertInterestsToBool(visitor.VisitorInterests),
            VisitorAttentions = ConvertAttentionToBool(visitor.VisitorAttentions)
        };
        return visitorDto;
    }

    private static bool[] ConvertInterestsToBool(List<VisitorInterests> visitorVisitorInterests)
    {
        var interestsArray = new bool[Enum.GetNames(typeof(Interests)).Length];

        foreach (var interest in visitorVisitorInterests)
        {
            var interestIndex = (int)interest.Interest;
            if (interestIndex >= 0 && interestIndex < interestsArray.Length)
            {
                interestsArray[interestIndex] = true;
            }
        }
        return interestsArray;
    }
    
    private static bool[] ConvertAttentionToBool(List<VisitorAttentions> visitorAttentions)
    {
        var attentionArray = new bool[Enum.GetNames(typeof(Interests)).Length];

        foreach (var attention in visitorAttentions)
        {
            var attentionIndex = (int)attention.Attention;
            if (attentionIndex >= 0 && attentionIndex < attentionArray.Length)
            {
                attentionArray[attentionIndex] = true;
            }
        }
        return attentionArray;
    }

    private static AddressDto ConvertAddressToDto(Address visitorAddress)
    {
        return new AddressDto
        {
            Id = visitorAddress.Id,
            ZipCode = visitorAddress.ZipCode,
            Town = visitorAddress.Town
        };
    }

    private static Visitor ConvertDtoToVisitor(VisitorDto visitorDto)
    {
        var userId = Guid.NewGuid();
        List<VisitorInterests> interests = [..CovertBoolToInterest(visitorDto.VisitorInterests, userId)];
        List<VisitorAttentions> attentions = [..CovertBoolToAttention(visitorDto.VisitorAttentions, userId)];
        var visitor = new Visitor()
        {
            Id = userId,
            CreateDate = visitorDto.CreateDate,
            AddressId = visitorDto.AddressDto!.Id,
            VisitorInterests = interests,
            VisitorAttentions = attentions
        };
        return visitor;
    }

    private static List<VisitorInterests> CovertBoolToInterest(IReadOnlyList<bool> array, Guid id)
    {
        var interests = new List<VisitorInterests>();
        for (var i = 0; i < array.Count; i++)
        {
            if (!array[i]) continue;
            
            var interest = new VisitorInterests
            {
                VisitorId = id,
                Interest = (Interests)i
            };
            interests.Add(interest);
        }
        return interests;
    }
    
    private static List<VisitorAttentions> CovertBoolToAttention(IReadOnlyList<bool> array, Guid id)
    {
        var interests = new List<VisitorAttentions>();
        for (var i = 0; i < array.Count; i++)
        {
            if (!array[i]) continue;
            
            var attentions = new VisitorAttentions()
            {
                VisitorId = id,
                Attention = (Attentions)i
            };
            interests.Add(attentions);
        }
        return interests;
    }
}