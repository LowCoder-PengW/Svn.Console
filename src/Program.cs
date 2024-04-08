using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SvnDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var isok = SVNHelper.CreateUser("King", "jwdsg0622");
            //var isok  = SVNHelper.CreatGroup("userGroupTest2");

            //var isok = SVNHelper.CreateRepository("repositoryTest");

            //SVNHelper.SetRepositoryPermission("King", "repositoryTest");


            // 设置 PowerShell 脚本内容
            //string powerShellScript = @"Write-Host 'Hello, World!'";
            //string shellScript = "import-module visualsvn \r get-childitem -Path 'D:\\PengW\\work\\SVNWeb\\SVN\\SvnRepositories' | select-object name,mode,length"; //
            string shellScript = "import-module visualsvn \r get-childitem -Path 'D:\\SoftWare\\SVN\\SVNRepositories' | select-object name,mode,length";


            // 执行 PowerShell 脚本
            var txt = ExecutePowerShell.ExecutePowerShellScript(shellScript);

            var temp = txt.Split('\r').ToArray(); 


            Console.WriteLine(txt);




            #region 修改 用户仓库权限

            string name = "repositoryTest";
            //string filePath = $"D:\\PengW\\work\\SVNWeb\\SVN\\SvnRepositories\\{name}\\conf\\VisualSVN-SvnAuthz.ini";
            string filePath = $"D:\\SoftWare\\SVN\\SVNRepositories\\{name}\\conf\\VisualSVN-SvnAuthz.ini";

            // 读取 INI 文件
            Dictionary<string, Dictionary<string, string>> iniData = ReadIniFile(filePath);
            // 修改 INI 文件内容
            if (iniData.ContainsKey("/"))
            {
                iniData["/"]["PengW"] = "rw";
            }
            // 将修改后的内容写回到 INI 文件
            WriteIniFile(filePath, iniData);

            #endregion





            #region 获取子仓库用户权限

            string subName = "repositoryTest";
            //string subFilePath = $"D:\\PengW\\work\\SVNWeb\\SVN\\SvnRepositories\\{subName}\\conf\\VisualSVN-SvnAuthz.ini";
            string subFilePath = $"D:\\SoftWare\\SVN\\SVNRepositories\\{subName}\\conf\\VisualSVN-SvnAuthz.ini";


            // 读取 INI 文件
            Dictionary<string, Dictionary<string, string>> subIniData = ReadIniFile(filePath);
            // 修改 INI 文件内容
            string nameSub = "repositorySubTest";
            var firstDatas = subIniData.Where(r => r.Key == $"/test/{nameSub}").FirstOrDefault().Value;
            foreach (var item in firstDatas)
            {
                Console.WriteLine("key:" + item.Key, "value:" + item.Value);
            }


            #endregion






            var datas = SVNHelper.GetUsers();
            Console.WriteLine("用户信息：");
            foreach (var item in datas)
            {
                Console.WriteLine(item);
            }

            var datasgroup = SVNHelper.GetGroupUsers("userGroupTest");
            Console.WriteLine("用户组【userGroupTest】信息：");
            foreach (var item in datasgroup)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("hello world");


            Console.ReadKey();


        }


        static void WriteToIniFile(string filePath)
        {
            var datas = ReadIniFile(filePath);

            var sss = datas.Where(r => r.Key == "/").FirstOrDefault().Value;
            foreach (var item in sss)
            {
                Console.WriteLine("Key:" + item.Key, "Value:" + item.Value);
            }


        }


        static void WriteIniFile(string filePath, Dictionary<string, Dictionary<string, string>> iniData)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var section in iniData)
                {
                    writer.WriteLine($"[{section.Key}]");
                    foreach (var keyValuePair in section.Value)
                    {
                        writer.WriteLine($"{keyValuePair.Key} = {keyValuePair.Value}");
                    }
                    writer.WriteLine();
                }
            }
        }



        static Dictionary<string, Dictionary<string, string>> ReadIniFile(string filePath)
        {
            Dictionary<string, Dictionary<string, string>> iniData = new Dictionary<string, Dictionary<string, string>>();
            string currentSection = "";

            foreach (string line in File.ReadAllLines(filePath))
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    iniData[currentSection] = new Dictionary<string, string>();
                }
                else if (!string.IsNullOrEmpty(currentSection) && trimmedLine.Contains("="))
                {
                    string[] parts = trimmedLine.Split(new char[] { '=' }, 2);
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    iniData[currentSection][key] = value;
                }
            }

            return iniData;
        }



        //static void WriteIniFile(string filePath)
        //{
        //    using (StreamWriter writer = new StreamWriter(filePath))
        //    {
        //        writer.WriteLine("[Section1]");
        //        writer.WriteLine("Key1=Value1");
        //        writer.WriteLine("Key2=Value2");
        //        writer.WriteLine();

        //        writer.WriteLine("[Section2]");
        //        writer.WriteLine("Key3=Value3");
        //    }
        //}

        static Dictionary<string, Dictionary<string, string>> ReadIniFilePro(string filePath)
        {
            Dictionary<string, Dictionary<string, string>> iniData = new Dictionary<string, Dictionary<string, string>>();
            string currentSection = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        currentSection = line.Substring(1, line.Length - 2);
                        iniData[currentSection] = new Dictionary<string, string>();
                    }
                    else if (!string.IsNullOrEmpty(currentSection) && line.Contains("="))
                    {
                        string[] parts = line.Split(new char[] { '=' }, 2);
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        iniData[currentSection][key] = value;
                    }
                }
            }

            return iniData;
        }
    }
}
