using System.ComponentModel.DataAnnotations;

namespace SelfLearning.DTOs.Requests;

public class CreatePassengerTravelShareRequest
{
    [Required]
    public int TrainNo { get; set; } = 0;

    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "PNR must be exactly 10 digits")]
    public string Pnr { get; set; } = string.Empty;

    [Required]
    public DateOnly TravelDate { get; set; }

    [StringLength(500)]
    public string? Message { get; set; }
    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain exactly 10 digits")]
    public string? PhoneNumber { get; set; }
}





