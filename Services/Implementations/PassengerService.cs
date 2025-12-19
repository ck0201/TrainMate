using Microsoft.EntityFrameworkCore;
using SelfLearning.Data;
using SelfLearning.Domain.Entities;
using SelfLearning.DTOs.Requests;
using SelfLearning.DTOs.Responses;
using SelfLearning.Services.Interfaces;

namespace SelfLearning.Services.Implementations;

public class PassengerService : IPassengerService
{
    private readonly AppDbContext _context;
    private readonly IPnrApiService _pnrApiService;
    private readonly ILogger<PassengerService> _logger;

    public PassengerService(
        AppDbContext context,
        IPnrApiService pnrApiService,
        ILogger<PassengerService> logger)
    {
        _context = context;
        _pnrApiService = pnrApiService;
        _logger = logger;
    }

    public async Task<PassengerTravelShareResponse> CreatePassengerTravelShareAsync(
        CreatePassengerTravelShareRequest request)
    {
        _logger.LogInformation("Processing passenger travel share for TrainNo: {TrainNo}, PNR: {Pnr}", request.TrainNo, request.Pnr);
        // Save Passenger Travel Share
        var passengerTravelShare = new PassengerTravelShare
        {
            Pnr = request.Pnr,
            TrainId = request.TrainNo,
            TravelDate = request.TravelDate,
            Message = request.Message,
            CreatedAt = DateTime.UtcNow,
            PhoneNumber = request.PhoneNumber
        };

        _context.PassengerTravelShares.Add(passengerTravelShare);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Created passenger travel share with ShareId: {ShareId}", passengerTravelShare.ShareId);

        return new PassengerTravelShareResponse
        {
            ShareId = passengerTravelShare.ShareId,
            TrainNo = request.TrainNo,
            //TrainName = existingTrain.TrainName ?? string.Empty,
            Pnr = passengerTravelShare.Pnr,
            TravelDate = passengerTravelShare.TravelDate,
            Message = passengerTravelShare.Message,
            CreatedAt = passengerTravelShare.CreatedAt
        };
    }

    public async Task<List<PassengerTravelShareResponse>> GetFilterTravelData(string? trainNo, DateOnly? travelDate)
    {
        var query = _context.PassengerTravelShares
        .AsQueryable();

        if (!string.IsNullOrWhiteSpace(trainNo))
        {
            trainNo = trainNo.Trim();
            query = query.Where(x => x.Train.TrainNo == trainNo);
        }
        if (travelDate.HasValue)
        {
            query = query.Where(x => x.TravelDate == travelDate);
        }

        var result = await query
        .AsNoTracking()
        .OrderByDescending(x => x.CreatedAt)
        .Select(x => new PassengerTravelShareResponse
        {
            ShareId = x.ShareId,
            Pnr = x.Pnr,
            TravelDate = x.TravelDate,
            Message = x.Message,
            TrainNo = x.TrainId,
            TrainName = x.Train.TrainName ?? ""
        })
        .ToListAsync();

        return result;
    }
}

