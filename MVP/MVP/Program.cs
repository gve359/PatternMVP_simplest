
using System;
using System.Windows.Forms;

using Project.GUI;
using Project.Presenters;
using Project.Model;

namespace MVP
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
						
			var view_InputNickNames = new Form_InputNickNames();			
			IModel dataModel = new PseudoServer(new DataTable_Nicks());
			
			new Presenter_InputNickNames(dataModel, view_InputNickNames);
			
			Application.Run(view_InputNickNames);
		}		
	}
}
