using System.Text.Json.Serialization;

namespace task1.models
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }


        [JsonIgnore]
        public  Department Department { get; set; }
    }
}
