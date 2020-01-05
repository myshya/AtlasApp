using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasApp.Domain.Entities
{
    [Table("Employee")]
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
    }
}