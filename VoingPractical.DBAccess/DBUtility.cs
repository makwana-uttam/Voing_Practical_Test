using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VoingPractical.DBAccess
{

	 class DBUtility
	{
		private static SqlConnection GetSQLConnection(string connectionString)
		{
			SqlConnection cn = new SqlConnection();
			cn = new SqlConnection(connectionString);
			cn.Open();
			return cn;
		}

		protected internal static string ExecuteCommand(CommandType commandType, string commandQuery, string connectionString, Dictionary<string, SqlParameter> procParameters = null)
		{
			string firstColumn = string.Empty;
			SqlCommand cmd1 = new SqlCommand();
			try
			{
				using (SqlConnection cn = GetSQLConnection(connectionString))
				{
					cmd1.Connection = cn;
					cmd1.CommandTimeout = 0;
					cmd1.CommandType = commandType;
					cmd1.CommandText = commandQuery;
					if (procParameters != null)
					{
						foreach (var procParameter in procParameters)
						{
							cmd1.Parameters.Add(procParameter.Value);
						}
					}
					var res = cmd1.ExecuteScalar();
					if (res != null)
						firstColumn = res.ToString();

					cmd1.Parameters.Clear();
					cn.Close();
				}
			}
			catch (Exception ex)
			{
				cmd1.Dispose();
				return firstColumn;
			}
			finally
			{
				cmd1.Dispose();
			}

			return firstColumn;
		}
	}
}
