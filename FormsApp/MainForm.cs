using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static FormsApp.Easy;

namespace FormsApp
{
    public partial class MainForm : Form
    {
        private static CURLcode sm_curlCode;
        //public delegate int ReadFunction(byte[] buf, int size, int nmemb, Object extraData);
        public delegate int ReadFunction(IntPtr buf, int size, int nmemb, IntPtr extraData);
        public static ReadFunction m_pfRead;
        public Object m_readData;

        public MainForm()
        {
            InitializeComponent();

            sm_curlCode = Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
        }

        private void btn_Post_Click(object sender, EventArgs e)
        {
            IntPtr m_pCURL = External.curl_easy_init();

            CURLcode retCode = CURLcode.CURLE_OK;
            retCode = External.curl_easy_setopt(m_pCURL, CURLoption.CURLOPT_URL, Marshal.StringToCoTaskMemAnsi("https://account.storepos.cn/UnifiedPay/Mch_Reg"));
            retCode = External.curl_easy_setopt(m_pCURL, CURLoption.CURLOPT_POSTFIELDS, Marshal.StringToCoTaskMemAnsi($"a={Uri.EscapeDataString("我是中文")}&b={Uri.EscapeDataString("i am English")}"));
            retCode = External.curl_easy_setopt(m_pCURL, CURLoption.CURLOPT_USERAGENT, Marshal.StringToCoTaskMemAnsi("我是尹自强的工具"));
            retCode = External.curl_easy_setopt(m_pCURL, CURLoption.CURLOPT_SSL_VERIFYHOST, (IntPtr)0);
            retCode = External.curl_easy_setopt(m_pCURL, CURLoption.CURLOPT_SSL_VERIFYPEER, (IntPtr)0);

            CURLcode res = External.curl_easy_perform(m_pCURL);
            if (res != CURLcode.CURLE_OK)
            {
                // Error
            }

            this.txt_Result.AppendText(res.ToString());
            this.txt_Result.AppendText(Environment.NewLine);

            External.curl_easy_cleanup(m_pCURL);

            return;

            //try
            //{
            //    using (var pro = new Process())
            //    {
            //        var str_form = $"a={Uri.EscapeDataString("我是中文")}&b={Uri.EscapeDataString("i am English")}";
            //        var str_cmd = $"-H \"Content-Type:application/x-www-form-urlencoded;charset=UTF-8\" --user-agent \"YZQ.curl\" --data \"{str_form}\" https://account.storepos.cn/UnifiedPay/Mch_Reg";

            //        pro.StartInfo.FileName = Path.Combine(Environment.CurrentDirectory, "Lib\\curl.exe");
            //        pro.StartInfo.UseShellExecute = false;
            //        pro.StartInfo.RedirectStandardInput = true;
            //        pro.StartInfo.RedirectStandardOutput = true;
            //        pro.StartInfo.RedirectStandardError = true;
            //        pro.StartInfo.CreateNoWindow = true;
            //        pro.StartInfo.Arguments = str_cmd;
            //        //pro.StartInfo.StandardInputEncoding = Encoding.UTF8;
            //        pro.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            //        pro.Start();
            //        pro.StandardInput.AutoFlush = true;

            //        //获取cmd窗口的输出信息
            //        var output = pro.StandardOutput.ReadToEnd();

            //        pro.WaitForExit();
            //        pro.Close();

            //        this.AppendResult(string.Format("【FormData】：{0}", str_form));
            //        this.AppendResult(string.Format("【Arguments】：{0}", str_cmd));
            //        this.AppendResult(string.Format("【Response】：{0}", output));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void AppendResult(string result)
        {
            this.txt_Result.AppendText(result);
            this.txt_Result.AppendText(Environment.NewLine);
            this.txt_Result.AppendText(Environment.NewLine);
        }
    }
}
