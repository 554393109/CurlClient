using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class MainForm : Form
    {
        //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Post_Click(object sender, EventArgs e)
        {
            try
            {
                using (var pro = new Process())
                {
                    var str_form = $"a={Uri.EscapeDataString("我是中文")}&b={Uri.EscapeDataString("i am English")}";
                    var str_cmd = $"-H \"Content-Type:application/x-www-form-urlencoded;charset=UTF-8\" --user-agent \"YZQ.curl\" --data \"{str_form}\" https://account.storepos.cn/UnifiedPay/Mch_Reg";

                    pro.StartInfo.FileName = Path.Combine(Environment.CurrentDirectory, "Lib\\curl.exe");
                    //pro.StartInfo.FileName = @"C:\curl\curl.exe";
                    pro.StartInfo.UseShellExecute = false;
                    pro.StartInfo.RedirectStandardInput = true;
                    pro.StartInfo.RedirectStandardOutput = true;
                    pro.StartInfo.RedirectStandardError = true;
                    pro.StartInfo.CreateNoWindow = true;
                    pro.StartInfo.Arguments = str_cmd;
                    //pro.StartInfo.StandardInputEncoding = Encoding.UTF8;
                    pro.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                    pro.Start();
                    pro.StandardInput.AutoFlush = true;

                    //获取cmd窗口的输出信息
                    string output = pro.StandardOutput.ReadToEnd();

                    pro.WaitForExit();
                    pro.Close();

                    this.AppendResult(string.Format("【FormData】：{0}", str_form));
                    this.AppendResult(string.Format("【Arguments】：{0}", str_cmd));
                    this.AppendResult(string.Format("【Response】：{0}", output));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AppendResult(string result)
        {
            this.txt_Result.AppendText(result);
            this.txt_Result.AppendText(Environment.NewLine);
            this.txt_Result.AppendText(Environment.NewLine);
        }
    }
}
