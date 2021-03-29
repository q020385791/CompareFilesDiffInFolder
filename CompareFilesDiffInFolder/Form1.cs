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

namespace CompareFilesDiffInFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
            string SourcePath = labSource.Text;
            string TargetPath =labTarget.Text;
            DirectoryInfo dirSource = new DirectoryInfo(SourcePath);
            DirectoryInfo dirTarget = new DirectoryInfo(TargetPath);
            //取得目錄底下所有資料夾
            DirectoryInfo[] SubDir= dirSource.GetDirectories("*",SearchOption.AllDirectories);

            foreach (var Dir in SubDir)
            {
                string TargetDir = Dir.FullName.Replace(SourcePath, TargetPath);
                if (!Directory.Exists(TargetDir))
                {
                    txtLog.Text += "目標資料夾不存在：" + TargetDir+Environment.NewLine;
                }

                IEnumerable<FileInfo> ListSource = Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);

                FileCompare MyFileCompare = new FileCompare();

                //取出所有Source檔案路徑
                foreach (var F in ListSource)
                {
                    //根目錄轉換
                    string OldPath = F.FullName;
                    string NewFilePath = F.FullName.Replace(SourcePath, TargetPath);
                    if (!File.Exists(NewFilePath))
                    {
                        txtLog.Text += "目標檔案不存在：" + NewFilePath + Environment.NewLine;
                    }
                    else
                    {
                        //檔案若存在則進行檔案比對
                        FileCompare FC = new FileCompare();
                        FileInfo OldFile = new FileInfo(OldPath);
                        FileInfo NewFile = new FileInfo(NewFilePath);
                        if (OldFile != null && NewFile != null)
                        {
                            if (!FC.CheckInfo(OldFile, NewFile))
                            {
                                txtLog.Text += "檔案不同步：" + NewFile.FullName + Environment.NewLine;
                            }
                        }


                    }

                }
            }
       

          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSetSourceFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                labSource.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                labTarget.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        public class FileCompare : IEqualityComparer<FileInfo>
        {
            public bool Equals(FileInfo FileSource, FileInfo FileTarget)
            {
                //比對名稱與長度
                return (FileSource.Name == FileTarget.Name && FileSource.Length == FileTarget.Length);
            }
            public int GetHashCode(FileInfo File)
            {
                //回傳雜湊碼
                string s = $"{File.Name}{File.Length}";
                return s.GetHashCode();
            }

            //內文比對
            public bool CheckInfo(FileInfo FileSource, FileInfo FileTarget)
            {
                var InfoSource = File.ReadAllLines(FileSource.FullName);
                var InfoTarget = File.ReadAllLines(FileTarget.FullName);
                var IFequal = Enumerable.SequenceEqual(InfoSource, InfoTarget);
                return IFequal;
            }
        }


        public void CheckSameFiles(IEnumerable<FileInfo> QueryCommonFiles, IEnumerable<FileInfo> ListTarget, FileCompare MyFileCompare) 
        {
            foreach (var ItemSource in QueryCommonFiles)
            {
                //用來源名稱取得目標名稱
                var ItemTarget = ListTarget.Select(x => x).Where(y => y.Name == ItemSource.Name).FirstOrDefault();

                //察看檔案是否相同
                bool IFSameFile = MyFileCompare.CheckInfo(ItemSource, ItemTarget);
                if (IFSameFile)
                {
                    //目前檔案若相同則不動作
                    txtLog.Text +="檔案相同：" + ItemTarget.FullName + Environment.NewLine;
                }
                else
                {
                    txtLog.Text += "檔案不同步：" + ItemTarget.FullName + Environment.NewLine;
                }
            }

        }
    }
}
