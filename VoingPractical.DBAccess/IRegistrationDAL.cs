using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoingPractical.Model;

namespace VoingPractical.DBAccess
{
    public interface IRegistrationDAL
    {
        public int Registration_InsertUpdateDelete(string connectionString, Registration dto);
    }
}
