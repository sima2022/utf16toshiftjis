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
using Microsoft.Win32;

namespace STM32_sjis_conv
{
    public partial class Form1 : Form
    {
       String str,str1,NG1str,NG2str,strbuf;
       public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("ここにメッセージ", "ここにタイトル");
            int i = 0;
            openFileDialog1.FileName = "*.txt";
            strbuf = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // ファイルのパスを取得する
                string filePath = openFileDialog1.FileName;

                // ファイルを開く
                StreamReader reader = new StreamReader(filePath);

                try
                {
                    // ファイルを一行ずつ読み込む
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        i++;// Console.WriteLine(line);
#if true

                        //if (i > 1000)
                        //{
                        //    break;
                        //}
                        //else
                        //{
                            listBox1.Items.Add(line);
                            NG1str = "------"; NG2str = "UTF-8";
                            if (line.Contains(NG1str) || line.Contains(NG2str))
                            {
                                //Console.WriteLine(“指定した文字列が含まれています。”);
                            }
                            else
                            {
                                //Console.WriteLine(“指定した文字列がありません。”);
                                str1 = line;//01 09 2129 8148 A1A9 EFBC9F FF1F   ？
                                str = str1.Remove(0, 11);//8148 A1A9 EFBC9F FF1F   ？
                                str1 = str.Remove(4, 12);//8148 FF1F   ？
                                str = str1.Insert(0, "{0x");//{0x8148 FF1F   ？
                                str1 = str.Remove(7, 1);//{0x8148FF1F   ？
                                str = str1.Insert(7, ",0x");//{0x8148,0xFF1F   ？
                                str1 = str.Insert(14, "},//");//{0x8148,0xFF1F},//   ？
                                str1 += '\r';
                                listBox2.Items.Add(str1);// label2.Text = line;
                                strbuf += str1;
                            }
                        //}
#endif
#if false
listBox1.Items.Add(line);
#endif
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("エラー: " + ex.Message);
                }
                finally
                {
                    str = i.ToString();
                    label1.Text = str;
                    MessageBox.Show(str, "全行数");
                    // ファイルを閉じる
                    reader.Close();
                }
                saveFileDialog1.FileName = "stmtable.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.Stream stream;
                    stream = saveFileDialog1.OpenFile();
                    if (stream != null)
                    {
                        //ファイルに書き込む
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);
                        sw.Write(strbuf);
                        //閉じる
                        sw.Close();
                        stream.Close();

                    }
                }
            }
        }
    }
}