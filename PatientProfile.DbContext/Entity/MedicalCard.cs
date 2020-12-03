using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientProfile.DbContext.Entity
{
    public class MedicalCard : BaseEntity
    {
        public string RegNumber { get; set; }
        public string RegDate { get; set; }
        public string PatientName { get; set; }
        public string PatientStatus { get; set; }
        public string DoctorName { get; set; }
        public string AdditionalFiles { get; set; }
        public string OtherDetails { get; set; }
    }
}
