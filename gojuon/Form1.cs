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

			qusList = new List<Hiragana>
			{
				new Hiragana(new string[] {"a"}, "あ"),
				new Hiragana(new string[] {"i"}, "い"),
				new Hiragana(new string[] {"u"}, "う"),
				new Hiragana(new string[] {"e"}, "え"),
				new Hiragana(new string[] {"o"}, "お"),
				new Hiragana(new string[] {"ka"}, "か"),
				new Hiragana(new string[] {"ki"}, "き"),
				new Hiragana(new string[] {"ku"}, "く"),
				new Hiragana(new string[] {"ke"}, "け"),
				new Hiragana(new string[] {"ko"}, "こ"),
				new Hiragana(new string[] {"sa"}, "さ"),
				new Hiragana(new string[] {"shi", "si"}, "し"),
				new Hiragana(new string[] {"su"}, "す"),
				new Hiragana(new string[] {"se"}, "せ"),
				new Hiragana(new string[] {"so"}, "そ"),
				new Hiragana(new string[] {"ta"}, "た"),
				new Hiragana(new string[] {"chi", "ti", "ci"}, "ち"),
				new Hiragana(new string[] {"tsu"}, "つ"),
				new Hiragana(new string[] {"te"}, "て"),
				new Hiragana(new string[] {"to"}, "と"),
				new Hiragana(new string[] {"na"}, "な"),
				new Hiragana(new string[] {"ni"}, "に"),
				new Hiragana(new string[] {"nu"}, "ぬ"),
				new Hiragana(new string[] {"ne"}, "ね"),
				new Hiragana(new string[] {"no"}, "の"),
				new Hiragana(new string[] {"ha", "fa"}, "は"),
				new Hiragana(new string[] {"hi", "fi"}, "ひ"),
				new Hiragana(new string[] {"hu", "fu"}, "ふ"),
				new Hiragana(new string[] {"he", "fe"}, "へ"),
				new Hiragana(new string[] {"ho", "fo"}, "ほ"),
				new Hiragana(new string[] {"ma"}, "ま"),
				new Hiragana(new string[] {"mi"}, "み"),
				new Hiragana(new string[] {"mu"}, "む"),
				new Hiragana(new string[] {"me"}, "め"),
				new Hiragana(new string[] {"mo"}, "も"),
				new Hiragana(new string[] {"ya"}, "や"),
				new Hiragana(new string[] {"yu"}, "ゆ"),
				new Hiragana(new string[] {"yo"}, "よ"),
				new Hiragana(new string[] {"ra"}, "ら"),
				new Hiragana(new string[] {"ri"}, "り"),
				new Hiragana(new string[] {"ru"}, "る"),
				new Hiragana(new string[] {"re"}, "れ"),
				new Hiragana(new string[] {"ro"}, "ろ"),
				new Hiragana(new string[] {"wa"}, "わ"),
				new Hiragana(new string[] {"wo"}, "を"),
				new Hiragana(new string[] {"n", "nn"}, "ん"),
			};

			now = rand.Next(qusList.Count);
			label1_qus.Text = qusList[now].qus;

			Control control = (Control)this;

			textBox_ans.Location = new Point((control.Size.Width - textBox_ans.Size.Width) / 2,
											(control.Size.Height - textBox_ans.Size.Height) / 4 * 3);
			label1_qus.Location = new Point((control.Size.Width - label1_qus.Size.Width) / 2,
											(control.Size.Height - label1_qus.Size.Height) / 4);
		}

		Random rand = new Random();
		List<Hiragana> qusList;
		int now;

		class Hiragana
		{
			public string qus;

			public Hiragana(string[] yomi, string qus)
			{
				this.yomi = yomi;
				this.qus = qus;
			}

			public bool check(string msg)
			{
				foreach (string i in yomi)
				{
					if (msg == i)
						return true;
				}
				return false;
			}

			string[] yomi;
		}

		private void textBox_ans_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				System.Diagnostics.Debug.WriteLine("[" + textBox_ans.Text + "]");
				if (qusList[now].check(textBox_ans.Text))
				{
					textBox_ans.Text = "";
					now = rand.Next(qusList.Count);
					label1_qus.Text = qusList[now].qus;
				}
				else if (textBox_ans.Text == "\\ans")
				{
					textBox_ans.Text = qusList[now].qus;
				}
			}
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			Control control = (Control)sender;

			textBox_ans.Location = new Point((control.Size.Width - textBox_ans.Size.Width) / 2,
											(control.Size.Height - textBox_ans.Size.Height) / 4 * 3);
			label1_qus.Location = new Point((control.Size.Width - label1_qus.Size.Width) / 2,
											(control.Size.Height - label1_qus.Size.Height) / 4);
		}
	}
}
