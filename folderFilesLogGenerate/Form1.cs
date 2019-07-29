using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace folderFilesLogGenerate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderPath = textBox1.Text;
            string logPath = textBox2.Text + "\\log.txt";

            string[] folderList = Directory.GetDirectories(folderPath);
            string[] fileList;

            foreach(string folder in folderList)
            {
                //try
                //{

                    if (Directory.Exists(folder) && !folder.Contains("System Volume Information"))
                    {
                        // get the file attributes for file or directory
                        FileAttributes attr = File.GetAttributes(folder);

                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            fileList = Directory.GetDirectories(folder);
                            foreach(string fold in fileList)
                            {
                               if(fold.Contains("PMLLIB"))
                                {
                                string[] files = Directory.GetFiles(fold);
                                string[] folders = Directory.GetDirectories(fold);
                                WriteTextFile(logPath, files);
                                WriteTextFile(logPath, folders);
                            }
                            }
                            
                               
                            
                        }
                    }
                //}
                //catch(Exception err)
                //{
                    
                //}
                
            }

            //Thread.Sleep(TimeSpan.FromSeconds(60));
            
            //string path1 = textBox2.Text +"\\log1.txt";
            //string[] fileContent = File.ReadAllLines(logPath);

            //var newFileContent = fileContent.Where(line => !line.Contains("pml.index"));
            //File.WriteAllLines(path1, newFileContent);


        }

        public void WriteTextFile(string path, string[] text)
        {
            if(text!=null)
            {
                File.AppendAllLines(path, text);
            }
          
        }
    }
}
