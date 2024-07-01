
using System;
using System.Data;

namespace Project.Model
{
	public class DataTable_Nicks : DataTable
	{				
		private void Initialize()
		{
			this.Columns.Add("NickName", typeof(string));
			this.PrimaryKey = new DataColumn[] { this.Columns["NickName"] };
			this.AcceptChanges();
		}
		
		private void Fill(string[] nickNames)
		{
			DataRow r = this.NewRow();
			foreach(string nick in nickNames)
			{
				r["NickName"] = nick;
				this.Rows.Add(r);
			}				
		}
		
		public DataTable_Nicks()
		{
			this.Initialize();
		}
		
		public DataTable_Nicks(string[] nickNames) : this()
		{						
			this.Fill(nickNames);
		}
	}
}
