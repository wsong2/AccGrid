using System;
using System.Data;
using System.Data.OleDb;

namespace AccGrid
{
    internal class AppDS
    {
		readonly static string ConnectionString = 
			@"Provider=Microsoft.ACE.OLEDB.12.0; Data source= db1.accdb";
		
		internal static DataTable GetDataTable1()
		{			
			string querySQL = 
				"SELECT (0=1) as Flag, rec_id as RowID, rec_date as Date1, Categ, Descr " +
				"FROM SimpleItems";
			using (var conn = new OleDbConnection(ConnectionString))
			{
				OleDbCommand command = new OleDbCommand(querySQL, conn);	
				using (var adapter = new OleDbDataAdapter(command))
				{
					conn.Open();
					DataTable table = new DataTable();
					adapter.Fill(table);
					return table;
				}
			}
		}
		
		internal static void UpdateData(DataTable dt)
		{
			DataRow [] rows = dt.Select("Flag = True");
			if (rows.Length < 1)
				return;
			string updateSQL = 
				"UPDATE SimpleItems SET Categ = @Categ, Descr = @Descr " +
				"WHERE rec_id = @RecID";
			using (var conn = new OleDbConnection(ConnectionString))
			{	
				conn.Open();
				foreach (DataRow r in rows) {
					var UpdateCmd = new OleDbCommand(updateSQL);
					UpdateCmd.Connection = conn;
					UpdateCmd.Parameters.Clear();
					UpdateCmd.Parameters.AddWithValue("@Categ", r["Categ"]);
					UpdateCmd.Parameters.AddWithValue("@Descr", r["Descr"]);
					UpdateCmd.Parameters.AddWithValue("@RecID", r["RowID"]);
					UpdateCmd.ExecuteNonQuery();
					UpdateCmd.Dispose();
				}
			}
		}
		
		internal static void InsertData(DateTime? dttm, String categ, String desc)
		{
			using (var conn = new OleDbConnection(ConnectionString))
			{	
				Int32 rec_id = 1;		
				conn.Open();
		
				var command = new OleDbCommand("SELECT max(rec_id)+1 FROM SimpleItems");		
				command.Connection = conn;	
				OleDbDataReader reader = command.ExecuteReader();			
				if (reader.Read())
				{
					rec_id = Convert.ToInt32(reader.GetValue(0));
					reader.Close();
					command.Dispose();
				}
				
				string insertSQL = 
					"Insert into SimpleItems(rec_id, rec_date, Categ, Descr ) " +
					"Values(@RecId, @RecDate, @Categ, @Descr)";	
				command = new OleDbCommand(insertSQL);
				command.Connection = conn;	
				command.Parameters.AddWithValue("@RecID", rec_id);
				command.Parameters.AddWithValue("@RecDate", dttm);
				
				if ( String.IsNullOrWhiteSpace(categ) )
					 command.Parameters.AddWithValue("@Categ", DBNull.Value);
				else command.Parameters.AddWithValue("@Categ", categ);
				
				if ( String.IsNullOrWhiteSpace(desc) )
					 command.Parameters.AddWithValue("@Descr", DBNull.Value);
				else command.Parameters.AddWithValue("@Descr", desc);
				
				command.ExecuteNonQuery();
				command.Dispose();
			}
		}

    }
}
