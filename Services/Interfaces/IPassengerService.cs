using SelfLearning.DTOs.Requests;
using SelfLearning.DTOs.Responses;

namespace SelfLearning.Services.Interfaces;

public interface IPassengerService
{
    Task<PassengerTravelShareResponse> CreatePassengerTravelShareAsync(CreatePassengerTravelShareRequest request);
    public Task<List<PassengerTravelShareResponse>> GetFilterTravelData(string? trainNo, DateOnly? travelDate);
}




