//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cornia.core.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        public int PatientId { get; set; }
        public string MrNo { get; set; }
        public string Name { get; set; }
        public string PatientAddress { get; set; }
        public string Sex { get; set; }
        public Nullable<int> Age { get; set; }
        public string FatherName { get; set; }
        public Nullable<int> EducationRef { get; set; }
        public Nullable<int> OccupationRef { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string SecondPhoneNo { get; set; }
        public string DisOcular { get; set; }
        public string DisSystemic { get; set; }
        public string DisAlergy { get; set; }
        public string ChifComplain { get; set; }
        public string PresentHistory { get; set; }
        public string HistoryDuration { get; set; }
        public string PastHistory { get; set; }
        public string SurType { get; set; }
        public string SurEye { get; set; }
        public Nullable<System.DateTime> SurDate { get; set; }
        public string MediOcular { get; set; }
        public string MediSystemic { get; set; }
        public Nullable<System.DateTime> InfoEntryDate { get; set; }
    
        public virtual Education Education { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}