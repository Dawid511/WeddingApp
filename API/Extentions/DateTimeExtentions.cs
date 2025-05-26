namespace API.Extentions;

public static class DateTimeExtentions
{
    public static int CalculateAge(this DateOnly dateTime)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var age = today.Year - dateTime.Year;
        if (dateTime > today.AddYears(-age)) age--;
        return age;
    }
}