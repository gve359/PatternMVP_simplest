
using System;
using System.Data;
using System.Linq;

using Project.Model;
using Project.GUI;

namespace Project.Presenters
{
	public class Presenter_InputNickNames
	{
		private IModel model;
		private IView_InputNickNames view;
		
		public Presenter_InputNickNames(IModel model, IView_InputNickNames view)
		{
			this.model = model;
			this.view = view;

			
			this.view.NickNamePrepared += (object sender, EventArgs_NickNamePrepared e) => {
				this.model.AddNickName(e.NickName);
			};

						
			this.model.NickNamesUpdated += (object sender, EventArgs e) => {
				this.view.UpdateListNickNames(
					convertDataTableNicks_toArray(
						this.model.GetNickNames()
					)
				);
			};		
			
			this.model.Error_NickNameDuplicated += (object sender, EventArgs_NickNameDuplicated e) => {
				this.view.ShowMessage_NickNameAlreadyRegistered(e.NickName);
			};
		}
		
		private string[] convertDataTableNicks_toArray(DataTable nicks)
		{
			string[] result = nicks.AsEnumerable().Select(row => row["NickName"].ToString()).ToArray();
			return result;
		}
	}
}
