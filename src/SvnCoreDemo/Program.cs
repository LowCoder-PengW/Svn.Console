using SharpSvn;
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
Console.WriteLine(txt);
#endregion


// 创建 SvnRepositoryClient 实例
using (SvnRepositoryClient client = new SvnRepositoryClient())
{
    // SVN 服务器的地址
    string serverUrl = "http://192.168.1.221/svn";

    // 新仓库的名称
    string repositoryName = "newrepo";

    // SVN 仓库的完整地址
    string repositoryPath = serverUrl + "/" + repositoryName;

    // 调用 CreateRepository 方法创建 SVN 仓库
    SvnCreateRepositoryArgs createArgs = new SvnCreateRepositoryArgs();
    client.CreateRepository(repositoryPath, createArgs);

    // 输出提示信息
    Console.WriteLine("SVN 仓库创建成功！");
}

//var isok = SVNHelper.CreateRepository("repositoryTest6");

//string CreateRepositoryShellScript = "new-svnrepository - name \"repositoryTest5\""; // 
//ExecutePowerShell.ExecutePowerShellScript(CreateRepositoryShellScript);






