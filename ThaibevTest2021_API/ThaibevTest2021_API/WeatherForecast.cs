using System;

namespace ThaibevTest2021_API
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class Employee
    {
        public int ContactId { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string PathPicture { get; set; }
        public int UpdatedBy { get; set; }

    }

    public class EmployeeATKUpdate
    {
        public int ContactId { get; set; }
        public int UpdatedBy { get; set; }

    }
}
