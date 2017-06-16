using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCorePostgreSql.Model
{
    public class Resident
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Timestamp { get; set; }
        [ForeignKey("SuiteId")]
        public Suite Suite { get; set; }
        public long SuiteId { get; set; }

    }
}
