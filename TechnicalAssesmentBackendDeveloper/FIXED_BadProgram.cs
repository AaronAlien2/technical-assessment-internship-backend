namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string GuestName { get; private set; }  // Use properties instead of public fields
    public string RoomNumber { get; private set; }
    public DateTime CheckInDate { get; private set; }
    public DateTime CheckOutDate { get; private set; }

    public int TotalDays { get; private set; }
    public double RatePerDay { get; private set; }
    public double Discount { get; private set; }
    public double TotalAmount { get; private set; }

    public async Task BookRoomAsync(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        GuestName = name;
        RoomNumber = room;
        CheckInDate = checkin;
        CheckOutDate = checkout;
        RatePerDay = rate;
        Discount = discountRate;

        Calculate();
        TotalAmount = CalculateTotalAmount();

        await LogBookingDetailsAsync();

        PrintDetails();
    }
    // Split the method
    private void Calculate()
    {
        TotalDays = (CheckOutDate - CheckInDate).Days;
    }

    private double CalculateTotalAmount()
    {
        double amount = TotalDays * RatePerDay;
        return amount - (amount * Discount / 100);  // Cleaner calculations
    }

    private async Task LogBookingDetailsAsync()  // Make the function works
    {
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    private void PrintDetails()
    {
        Console.WriteLine("Room Booked for " + GuestName);
        Console.WriteLine("Room No: " + RoomNumber);
        Console.WriteLine("Check-In: " + CheckInDate);
        Console.WriteLine("Check-Out: " + CheckOutDate);
        Console.WriteLine("Total Days: " + TotalDays);
        Console.WriteLine("Amount: " + TotalAmount);
    }

    public void Cancel()
    {
        GuestName = null;
        RoomNumber = null;
        CheckInDate = DateTime.MinValue;
        CheckOutDate = DateTime.MinValue;
        TotalAmount = 0;

        Console.WriteLine("Booking cancelled");
    }
}
