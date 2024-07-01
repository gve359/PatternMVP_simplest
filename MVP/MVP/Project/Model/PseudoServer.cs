
using System;
using System.Data;
using System.Linq;

namespace Project.Model
{
	public class PseudoServer : IModel  //класс, напрямую взаимодействующий с источником данных
	{
		private DataTable_Nicks nicks;
		
		public event EventHandler NickNamesUpdated = delegate{};
		public event EventHandler<EventArgs_NickNameDuplicated> Error_NickNameDuplicated = delegate{};
		
		public PseudoServer(DataTable_Nicks beginData)
		{
			this.nicks = beginData;
		}
		
		public DataTable GetNickNames()
		{
			return this.nicks.Copy();
		}
		
		public void AddNickName(string nickName)
		{								
			int countNicks_as_nickName = this.nicks.AsEnumerable().Where(row => row.Field<string>("NickName") == nickName).Count();
			if (countNicks_as_nickName > 0) // если такой ник уже есть в базе
			{
				this.Error_NickNameDuplicated(this, 
				                              new EventArgs_NickNameDuplicated(){
				                              	NickName = nickName
				                              });				
			}
			else
			{
				DataRow r = this.nicks.NewRow();
				r["NickName"] = nickName;
				this.nicks.Rows.Add(r);
				
				this.NickNamesUpdated(this, new EventArgs());
			}
		}

	}
}
