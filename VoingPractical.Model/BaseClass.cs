using System;

namespace VoingPractical.Model
{
    public class BaseClass
    {
        public Int64 Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DMLFlag { get; set; }
    }
}
