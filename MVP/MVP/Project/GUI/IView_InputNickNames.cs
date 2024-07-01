
using System;

namespace Project.GUI
{
	public class EventArgs_NickNamePrepared : EventArgs
    {
        public string NickName { get; set; }
    }
		
	public interface IView_InputNickNames
	{
		event EventHandler<EventArgs_NickNamePrepared> NickNamePrepared;
		void UpdateListNickNames(string[] nickNames);
		void ShowMessage_NickNameAlreadyRegistered(string duplicated_nickName);
	}
}
