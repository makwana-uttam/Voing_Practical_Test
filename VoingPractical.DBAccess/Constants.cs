using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoingPractical.DBAccess
{
    public partial class Constants
    {
        public const string COLUMN_FullName = "FullName";
        public const string COLUMN_Email = "Email";
        public const string COLUMN_Password = "Password";
        public const string DMLFlag = "DMLFlag";
    }

    public static partial class SPConstants
    {
        public static string usp_tbl_Registration_Operation = "dbo.usp_tbl_Registration_Operation";
    }
}
