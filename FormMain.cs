using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace SmartDrinks
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            textDrinks.Text = Application.ProductName + " version " + Application.ProductVersion + Environment.NewLine;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string strFileName = "SmartDrinks.txt";
            List<Drinks> listDrinks = new List<Drinks>();

            textDrinks.Text = "Loading File: " + strFileName + "." + Environment.NewLine + Environment.NewLine;

            try
            {
                List<string> lines = System.IO.File.ReadLines(strFileName).ToList();
                for (int i = 0; i < lines.Count; i++)
                {
                    List<string> listValues = lines[i].Trim().Split(',').ToList();

                    switch (listValues[0].ToLower())
                    {
                        case "beer":
                            Beer beerDrink = new Beer(listValues[1], Convert.ToBoolean(listValues[2]), Convert.ToDecimal(listValues[3]));
                            listDrinks.Add(beerDrink);
                            break;
                        case "juice":
                            Juice juiceDrink = new Juice(listValues[1], Convert.ToBoolean(listValues[2]), listValues[3]);
                            listDrinks.Add(juiceDrink);
                            break;
                        case "soda":
                            Soda sodaDrink = new Soda(listValues[1], Convert.ToBoolean(listValues[2]));
                            listDrinks.Add(sodaDrink);
                            break;
                    }
                }
                ListDrinks(listDrinks);
            }
            catch
            {
                AppendDrinksText(textDrinks, "Error Loading File!"+Environment.NewLine, Color.Red);
            }
        }

        private void ListDrinks(List<Drinks> listDrinks)
        {
            textDrinks.Text += "Drink Listing: " + Environment.NewLine;
            foreach (var drink in listDrinks)
            {
                AppendDrinksText(textDrinks, drink.Description() + Environment.NewLine, drink.Color);
            }

        }

        public void AppendDrinksText(RichTextBox richText, string text, Color color)
        {
            richText.SelectionStart = textDrinks.TextLength;
            richText.SelectionLength = 0;
            richText.SelectionColor = color;
            richText.AppendText(text);
            richText.SelectionColor = textDrinks.ForeColor;
        }
    }
}
