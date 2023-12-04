using System;
using System.Collections.Generic;
using VoingPractical.Model;
using System.Data.SqlClient;
using System.Data;

namespace VoingPractical.DBAccess
{
    public class RegistrationDAL : IRegistrationDAL
    {
		public int Registration_InsertUpdateDelete(string connectionString, Registration dto)
		{
			int inserted_id = 0;
			try
			{
				Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
				cmdParameters[Constants.COLUMN_FullName] = (new SqlParameter(Constants.COLUMN_FullName, dto.FullName));
				cmdParameters[Constants.COLUMN_Email] = (new SqlParameter(Constants.COLUMN_Email, dto.Email));
				cmdParameters[Constants.COLUMN_Password] = (new SqlParameter(Constants.COLUMN_Password, dto.Password));
				cmdParameters[Constants.DMLFlag] = (new SqlParameter(Constants.DMLFlag, dto.DMLFlag));
				var result = DBUtility.ExecuteCommand(CommandType.StoredProcedure, SPConstants.usp_tbl_Registration_Operation, connectionString, cmdParameters);

				if (result != null)
					int.TryParse(result, out inserted_id);
			}
			catch (Exception ex)
			{

			}
			return inserted_id;
		}
	}
}
