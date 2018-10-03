using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gojuon
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			now = rand.Next(46);
			label1_qus.Text = char.ToString(gojuin[now]);

			Control control = (Control)this;

			textBox_ans.Location = new Point((control.Size.Width - textBox_ans.Size.Width) / 2,
											(control.Size.Height - textBox_ans.Size.Height) / 4 * 3);
			label1_qus.Location = new Point((control.Size.Width - label1_qus.Size.Width) / 2,
											(control.Size.Height - label1_qus.Size.Height) / 4);
		}

		Random rand = new Random();
		int now;
		string gojuin = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをん";
		string[] pronounce = new string[46] {
			"a", "i", "u", "e", "o",
			"ka", "ki", "ku", "ke", "ko",
			"sa", "shi", "su", "se", "so",
			"ta", "chi", "tsu", "te", "to",
			"na", "ni", "nu", "ne", "no",
			"ha", "hi", "fu", "he", "ho",
			"ma", "mi", "mu", "me", "mo",
			"ya", "yu", "yo",
			"ra", "ri", "ru", "re", "ro",
			"wa", "wo",
			"n"
		};

		private void textBox_ans_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				System.Diagnostics.Debug.WriteLine("[" + textBox_ans.Text + "]");
				if (textBox_ans.Text == pronounce[now])
				{
					textBox_ans.Text = "";
					now = rand.Next(46);
					label1_qus.Text = char.ToString(gojuin[now]);
				}
				else if (textBox_ans.Text == "\\ans")
				{
					textBox_ans.Text = pronounce[now];
				}
			}
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			
			textBox_ans.Location = new Point((control.Size.Width - textBox_ans.Size.Width) / 2,
											(control.Size.Height- textBox_ans.Size.Height) / 4 * 3);
			label1_qus.Location = new Point((control.Size.Width - label1_qus.Size.Width) / 2,
											(control.Size.Height - label1_qus.Size.Height) / 4);
		}
	}
}
