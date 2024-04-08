using SvnCoreDemo;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

// 设置 PowerShell 脚本内容
//string powerShellScript = @"Write-Host 'Hello, World!'";
string shellScript = "import-module visualsvn \r get-childitem -Path 'D:\\PengW\\work\\SVNWeb\\SVN\\SvnRepositories' | select-object name,mode,length"; //
                                                                                                                                                        //string shellScript = "import-module visualsvn \r get-childitem -Path 'D:\\SoftWare\\SVN\\SVNRepositories' | select-object name,mode";



#region 获取svn 仓库信息

// 执行 PowerShell 脚本
var txt = ExecutePowerShell.ExecutePowerShellScript(shellScript);

var temp = txt.Split("\r\n").ToList();

var datas = temp.Where(r => r.Contains("d-----")).ToList();
var newDatas = datas.Select(r => r.Replace("d-----", "").Trim()).ToList();


foreach (var item in newDatas)
{
    Console.WriteLine(item);
}

#endregion

//var sss = SVNHelper.CreateRepositoryFolders("repositoryTest", new string[] { "demo" });

string CreateRepositoryShellScript = "new-svnrepository - name \"repositoryTest5\""; //

 ExecutePowerShell.ExecutePowerShellScript(CreateRepositoryShellScript);




Console.WriteLine(txt);

