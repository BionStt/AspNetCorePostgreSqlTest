using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCorePostgreSql.Model
{
    public class Suite
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        [ForeignKey("BuildingId")]
        public Building Building { get; set; }
        public long BuildingId { get; set; }

        public List<Resident> Residents { get; set; }

    }
}