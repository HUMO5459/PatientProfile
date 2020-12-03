using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientProfile.DbContext.Entity
{
    public class Doctor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Photo { get; set; }
    }
}
