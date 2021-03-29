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
            try
            {
                txtLog.Text = "";
                string SourcePath = labSource.Text;
                string TargetPath = labTarget.Text;
                DirectoryInfo dirSource = new DirectoryInfo(SourcePath);
                DirectoryInfo dirTarget = new DirectoryInfo(TargetPath);
                //取得目錄底下所有資料夾
                DirectoryInfo[] SubDir = dirSource.GetDirectories("*", SearchOption.AllDirectories);
                //如果該目錄有子資料夾
                if (SubDir.Count() > 0)
                {
                    foreach (var Dir in SubDir)
                    {
                        txtLog.Text += "----------------開始偵測目標資料夾：" + Dir.FullName + "-----------------------" + Environment.NewLine;

                        string TargetDir = Dir.FullName.Replace(SourcePath, TargetPath);
                        if (!Directory.Exists(TargetDir))
                        {
                            txtLog.Text += "目標資料夾不存在：" + TargetDir + Environment.NewLine;
                        }
                        IEnumerable<FileInfo> ListSource = Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);


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
                                try
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
                                catch (Exception ex)
                                {

                                    txtLog.Text += "錯誤：" + ex.InnerException + Environment.NewLine;
                                }

                            }
                        }
                        txtLog.Text += "----------------偵測目標資料夾結束：" + Dir.FullName + "-----------------------" + Environment.NewLine;

                    }

                    txtLog.Text += "比對完畢";
                }
                else 
                {
                    //如果該資料夾內只有檔案
                    string[] SourcePaths=Directory.GetFiles(SourcePath);
                    foreach (string  ThisSourcePath in SourcePaths)
                    {
                        string thisTargetPath = ThisSourcePath.Replace(SourcePath,TargetPath);
                        if (File.Exists(thisTargetPath))
                        {
                            //檔案若存在則進行檔案比對
                            FileCompare FC = new FileCompare();
                            FileInfo OldFile = new FileInfo(ThisSourcePath);
                            FileInfo NewFile = new FileInfo(thisTargetPath);
                            if (OldFile != null && NewFile != null)
                            {
                                if (!FC.CheckInfo(OldFile, NewFile))
                                {
                                    txtLog.Text += "檔案不同步：" + NewFile.FullName + Environment.NewLine;
                                }
                            }
                        }
                        else 
                        {
                            txtLog.Text += "目標檔案不存在：" + thisTargetPath + Environment.NewLine;
                        }
                    }
                    txtLog.Text += "比對完畢";
                }
            }
            catch (Exception ex)
            {
                txtLog.Text+=ex.InnerException;
            }
        }

        private void btnSetSourceFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
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


    }
}
