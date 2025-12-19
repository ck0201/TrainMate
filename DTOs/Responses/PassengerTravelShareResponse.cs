namespace SelfLearning.DTOs.Responses;

public class PassengerTravelShareResponse
{
    public int ShareId { get; set; }
    public int TrainNo { get; set; } = 0;
    public string TrainName { get; set; } = string.Empty;
    public string Pnr { get; set; } = string.Empty;
    public DateOnly TravelDate { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool TrainWasCreated { get; set; }
}




