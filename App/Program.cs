﻿using System;
using System.Diagnostics;
using System.Text;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            try
            {
                using (Process pro = new Process())
                {
                    var str_form = $"a={Uri.EscapeDataString("我是中文")}&b={Uri.EscapeDataString("i am English")}";
                    var str_cmd = $"-H \"Content-Type:application/x-www-form-urlencoded;charset=UTF-8\" --user-agent \"YZQ.curl\" --data \"{str_form}\" https://account.storepos.cn/UnifiedPay/Mch_Reg";
                    pro.StartInfo.FileName = @"C:\curl\curl.exe";
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

                    Console.WriteLine(output);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
