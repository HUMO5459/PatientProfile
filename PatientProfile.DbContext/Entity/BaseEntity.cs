using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PatientProfile.DbContext.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string AdminId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
