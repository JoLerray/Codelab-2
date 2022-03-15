using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;
namespace Codelab_2
{
    public partial class Form1 : Form
    {


        List<Item> itemsVal = new List<Item>();
        private class Item
        {
            public int hierarchy; public string text; public int status; public string name;
            public Item(int hierarchy, string text, int status, string name)
            {
                this.hierarchy = hierarchy; this.text = text; this.status = status; this.name = name; 
            }

        }
        private ToolStripMenuItem createMenuItem(int id,int hierarchy = 0)
        {
            ToolStripMenuItem _item = new ToolStripMenuItem(itemsVal[id].text);
            _item.ForeColor = Color.FromArgb(35,47,52);
            _item.BackColor = Color.FromArgb(74, 101, 114);
            if (hierarchy == itemsVal[id].hierarchy)
            {
                switch (itemsVal[id].status)
                {
                    case 0:
                        {
                            _item.Visible = true;
                            _item.Enabled = true;
                            break;
                        }
                    case 1:
                        {
                            _item.Visible = true;
                            _item.Enabled = false;
                            break;
                        }
                    case 2:
                        {
                            _item.Visible = false;
                            _item.Enabled = false;
                            break;
                        }
                }

                if (itemsVal[id].name != "") return _item;
                if (itemsVal[id].name == "")
                {
                    hierarchy = itemsVal[id].hierarchy + 1;

                    while (hierarchy <= itemsVal[id + 1].hierarchy)
                    {
                        _item.DropDownItems.Add(createMenuItem(id + 1, hierarchy));
                        id++;
                        if (id + 1 >= itemsVal.Count) break;
                    }

                }
                return _item;
            }
            ToolStripMenuItem __item = new ToolStripMenuItem();
            __item.Visible = false;
            __item.Enabled = false;
            return __item;

        }
        public Form1()
        {
            InitializeComponent();
            string path = (@"C:\Users\EshDel\Desktop\Design.txt");
            StreamReader file = new StreamReader(path);
            ToolStripMenuItem fileItem = new ToolStripMenuItem("file");
            List<string> DesignItems = new List<string>();
            while (true)
            {
                try
                {
                    var val = file.ReadLine();
                    if (val == null) break;
                    DesignItems.Add(val);

                }
                catch
                {
                    break;
                }
            }
            foreach (var item in DesignItems)
            {
                var valueArray =  item.Split();
                int hierarchy = System.Convert.ToInt32(valueArray[0]);
                string text = valueArray[1]; 
                int status =  System.Convert.ToInt32(valueArray[2]);
                string name = "";
                if (valueArray.Length == 4) name = (valueArray[3]);
                itemsVal.Add(new Item(hierarchy, text, status, name));

            }
            for(int i = 0; i < itemsVal.Count; i++)
            {
                if (itemsVal[i].hierarchy == 0) this.menuStrip1.Items.Add(createMenuItem(i));
            }
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new Cols());


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
