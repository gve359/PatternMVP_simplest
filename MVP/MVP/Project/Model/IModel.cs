
using System;
using System.Data;

namespace Project.Model
{
	public class EventArgs_NickNameDuplicated : EventArgs
    {
        public string NickName { get; set; }
    }
	
	public interface IModel
	{
		DataTable GetNickNames();
		void AddNickName(string nickName);
		event EventHandler NickNamesUpdated;
		event EventHandler<EventArgs_NickNameDuplicated> Error_NickNameDuplicated;
	}
}
