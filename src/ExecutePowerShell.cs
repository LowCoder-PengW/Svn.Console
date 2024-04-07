using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvnDemo
{
    public class ExecutePowerShell
    {
        /// <summary>
        /// 执行shell 脚本
        /// </summary>
        /// <param name="script"></param>
        public static string ExecutePowerShellScript(string script)
        {
            // 创建进程启动信息
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe", // 指定要启动的程序（这里是 PowerShell）
                Arguments = $"-NoProfile -ExecutionPolicy unrestricted -Command \"{script}\"", // 传递给 PowerShell 的参数
                UseShellExecute = false, // 设置为 false，以便我们可以重定向输入和输出
                RedirectStandardOutput = true, // 重定向标准输出，这样我们就可以获取脚本的输出
                CreateNoWindow = true // 创建一个不显示窗口的进程
            };

            // 创建一个新进程
            using (Process process = new Process())
            {
                // 将启动信息设置为新进程的启动信息
                process.StartInfo = psi;

                // 启动进程
                process.Start();

                // 等待进程结束
                process.WaitForExit();

                // 获取脚本的输出
                string output = process.StandardOutput.ReadToEnd();

                // 输出脚本的输出
                // Console.WriteLine(output);
                return output;
            }
        }

    }
}
