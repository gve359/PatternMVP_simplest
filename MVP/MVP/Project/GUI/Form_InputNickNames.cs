
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project.GUI
{
	
	public partial class Form_InputNickNames : Form, IView_InputNickNames
	{
		public event EventHandler<EventArgs_NickNamePrepared> NickNamePrepared = delegate{};
		
		public Form_InputNickNames()
		{
			InitializeComponent();
		}
		
		public void UpdateListNickNames(string[] nickNames)
		{
			listBox1.Items.Clear();
			foreach(string nickName in nickNames)
			{
				listBox1.Items.Add(nickName);
			}					
		}				
		
		public void ShowMessage_NickNameAlreadyRegistered(string duplicated_nickName)
		{
			MessageBox.Show("NickName " + duplicated_nickName + " already registered");
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.NickNamePrepared(this, 
			                      new EventArgs_NickNamePrepared(){ 
			                      	NickName = textBox1.Text
			                      } );
		}
	}
}
