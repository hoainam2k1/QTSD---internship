using System;
using System.Collections.Generic;

#nullable disable

namespace QTSD_internship.Models
{
    public partial class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public int? PositionId { get; set; }

        public virtual Position Position { get; set; }
    }
}
