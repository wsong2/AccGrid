using System.Data;
using System.Data.SqlClient;

namespace GridForm
{
 class DataAccess
 {
	static internal readonly string ConnectionString = Properties.Settings.Default.ConnectionString;
	static private readonly string SQL_SELECT =
            "SELECT ctt_id, ctt_date, ctt_hhmm" +
            ",[role],[client],[location]" +
            ",appli,reply" +
            ",agency,staff" +
            ",email,phones" +
            ",remark,[more] " +
            " FROM [dbo].[Job_Contacts_2]";

	static internal DataTable MainTable()
	{
		using (SqlConnection connection = new SqlConnection(ConnectionString))
		{
			using (SqlCommand command = new SqlCommand(SQL_SELECT, connection))
			{
				DataTable dt = new DataTable();
				connection.Open();
				SqlDataReader dataReader = command.ExecuteReader();
				dt.Load(dataReader);
				dataReader.Close();
				return dt;
			}
		}
	}

 }
}
