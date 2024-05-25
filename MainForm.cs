/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 5/25/2024
 * Time: 12:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormCreating
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			this.Width = 1920;
			this.Height = 1080;
			this.Left = 0;
			this.Top = 0;
			
			
		}
		
		public class record
		{
			public int tip;
			public int left;
			public int top;
			public int width;
			public int height;
			public Color backgroundColor;
			public Color foregroundColor;
			public List<int> attributes = new List<int>();
			public List<int> valori = new List<int>();
			public record(int codtag)
			{
				this.tip = codtag;
			}
			
		}
	
				
		
		
		public class formularul
		{
			
			public string[] atribute = {
			"name",
			"id",
			"value",
			"type",
			"class",
			"width",
			"height",
			"action",
			"for",
			"checked",
			"required",
			"readonly",
			"size",
			"defaultValue",
			"form",
			"autocomplete",
			"autofocus",
			"src",
			"alt",
			"disabled"
		
		
		};
		public string[] tags = {
			"a",
			"html",
			"head",
			"title",
			"body",
			"style",
			"script",
			"input",
			"textarea",
			"button",
			"option",
			"label",
			"select",
			"form",
			"h1",
			"p",
			"textarea",
			"img",
			
		};
		public string[] values = {
			"text",
			"submit",
			"checkbox",
			"date",
			"hidden",
			"password",
			"radio",
			"reset",
			"button",
			"option",
			"label",
			"select"		
		};
				
			
			public List<record>records = new List<record>();
			
			public void addRecord(int tipul, int atributul, int valoarea, int pleft, int ptop, int pwidth, int pheight)
			{
				this.records.Add( new record(tipul));
				int c = this.records.Count - 1;
				
				this.records[c].attributes.Add(atributul);
				this.records[c].valori.Add(valoarea);
				this.records[c].left = pleft;
				this.records[c].top = ptop;
				this.records[c].width = pwidth;
				this.records[c].height = pheight;
				
				
				
			}
			
			public void drawControlOnForm(int x, MainForm mf)
			{
				//adauga aici pentru fiecare tip in parte cateva atribute si valori
				//si tot aici poti construi si codul html
				//de exemplu <input type="button" id="x" name="x" value="button">
				if(records[x].tip == 7)
				{
					//addbutton
					mf.Controls.Add(new Button());
					int cc = mf.Controls.Count-1;
					mf.Controls[cc].Text = this.values[this.records[x].valori[0]];
					mf.Controls[cc].Left = this.records[x].left;
					mf.Controls[cc].Top = this.records[x].top;
					mf.Controls[cc].Width = this.records[x].width;
					mf.Controls[cc].Height = this.records[x].height;
					mf.Refresh();
				}
			}
			public string returnHTMLCodeOfTag(int x, MainForm mf)
			{
				string s="";
				
				if(records[x].tip == 7)
				{
				
					s = "<input type='button' ";
				    s +="id='button"+this.values[this.records[x].valori[0]]+x.ToString();

					s +="' name='buttonname"+this.values[this.records[x].valori[0]]+x.ToString();
					s +="' value='buttonname"+this.values[this.records[x].valori[0]]+x.ToString();
				
					s +="' onclick='run("+this.values[this.records[x].valori[0]]+x.ToString()+")'>";
				
				}
				
				return s;
			}
		}
		
		public formularul f = new formularul();
		void MainFormDoubleClick(object sender, EventArgs e)
		{
	
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			f.addRecord(7,3,8,10,65,200,25);
			f.addRecord(7,3,8,10,105,200,25);
			f.addRecord(7,3,8,10,145,200,25);
			f.addRecord(7,3,8,10,185,200,25);
			f.addRecord(7,3,8,10,225,200,25);
			f.drawControlOnForm(0,this);
			f.drawControlOnForm(1,this);
			f.drawControlOnForm(2,this);
			f.drawControlOnForm(3,this);
			f.drawControlOnForm(4,this);
			
			this.textBox1.Text+=f.returnHTMLCodeOfTag(0,this)+"\r\n";
				this.textBox1.Text+=f.returnHTMLCodeOfTag(1,this)+"\r\n";
					this.textBox1.Text+=f.returnHTMLCodeOfTag(2,this)+"\r\n";
						this.textBox1.Text+=f.returnHTMLCodeOfTag(3,this)+"\r\n";
							this.textBox1.Text+=f.returnHTMLCodeOfTag(4,this)+"\r\n";
		}
		
	}
}
