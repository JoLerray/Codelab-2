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
using System.Security;
using System.Diagnostics;

namespace Codelab_2
{
    public partial class Form1 : Form
    {


        List<Item> itemsVal = new List<Item>();
        String path = null;
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
                if (itemsVal[id].name == "") {
               
                while (hierarchy < itemsVal[id + 1].hierarchy)
                {
                    if (hierarchy + 1 == itemsVal[id + 1].hierarchy) {
                        _item.DropDownItems.Add(createMenuItem(id + 1,hierarchy + 1));
                    }
                    id++;
                    if (id + 1 >= itemsVal.Count) break;
               
                }

                }
                return _item;


        }
        public Form1()
        {
            InitializeComponent();

            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new Cols());


        }
        private void ReadValueFromFile(StreamReader file)
        {
           
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
                var valueArray = item.Split();
               
                int hierarchy = System.Convert.ToInt32(valueArray[0]);
                
                string text = valueArray[1];
                
                int status = System.Convert.ToInt32(valueArray[2]);
                
                string name = "";
               
                if (valueArray.Length == 4) name = (valueArray[3]);
               
                itemsVal.Add(new Item(hierarchy, text, status, name));

            }
        }
        private void setItemsInInterface(List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].hierarchy == 0) this.menuStrip1.Items.Add(createMenuItem(i));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                try
                {
                    path = openFileDialog1.FileName;
                    this.textBox1.Text ="Current file: " + path;
                       
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(path != null)
            {
                try
                {
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        Process.Start("notepad.exe", path);
                        str.Close();
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        Process.Start("notepad.exe", path);
                        str.Close();
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            itemsVal.Clear();
            this.menuStrip1.Items.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamReader File;
            try
            {
                itemsVal.Clear();
                File = new StreamReader(path);
                ReadValueFromFile(File);
                setItemsInInterface(itemsVal);
                File.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
