using System;

namespace AspNetCorePostgreSql.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Building
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }

        public List<Suite> Suites { get; set; }
    }
}
