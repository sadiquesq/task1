using System.Text.Json.Serialization;

namespace task1.models
{
    public class Student
    {

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int AddressId { get; set; }


        [JsonIgnore]
        public Address Address { get; set; }
    }
}
