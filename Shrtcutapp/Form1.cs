using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shell32;
using IWshRuntimeLibrary;

namespace Shrtcutapp
{
    public partial class Form1 : Form
    {
        public Form1(string option)
        {
            //этот конструктор запускается если параметр был передан
            
            // благодаря тому что был передан парметр, мы название формаы сделаем таким какой у нас парметр.
            InitializeComponent();
            this.Text = option;
        }
        //кд сам посромторишь
        public Form1()
        {
            // это обычный стиль запуска
            InitializeComponent();
        }

        //метод который создает шорткат(ярлык)
        private void CreateShortcut(string pathToFile)
        {


            WshShell shell = new WshShell();

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Где будем сохранять ярлык?";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                //ну вот запустим окошко, где выберем папку.
                //имя ярлыка мы указали в окне форму
                MessageBox.Show(FBD.SelectedPath);
            }
            //создадим ярлык
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(FBD.SelectedPath + $"\\{Name_Tbx.Text}.lnk");


            // в таргет припишем путь до файла + опции запуска, если они буди вписаны в поле соответствующеее
            if (String.IsNullOrWhiteSpace(OptionTbx.Text))
            {
                link.TargetPath = pathToFile;
            }
            else
            {
                link.TargetPath = pathToFile;
                link.Arguments = OptionTbx.Text;
            }
            
            //link.WorkingDirectory = path;


            link.Save();


        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            string pathToFile = String.Empty;
            // если кликаем на кнопку, то откроется опенфайлдиалог, где мы выберем путь к какому-то файлу.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathToFile = openFileDialog1.FileName;
            }
            CreateShortcut(pathToFile);
        }
        // ТЕПЕРЬ ЗАПУСТИМ.....
        // ща запустится протос из-за видоса доло запускается
    }
}
