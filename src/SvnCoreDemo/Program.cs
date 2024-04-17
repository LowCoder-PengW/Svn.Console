using SharpSvn;
using SvnCoreDemo;
using System;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

int i = "abcde".IndexOf("cd");
Console.WriteLine(i);
var total = "164947625394246/165014116208710/165014544748614".Length;
int a = "164947625394246/165014116208710/165014544748614".LastIndexOf("165014116208710");

var ss = "164947625394246/165014116208710/165014544748614".Substring(0, total - a);
Console.WriteLine(ss);
Console.WriteLine(a);
// 设置 PowerShell 脚本内容
//string powerShellScript = @"Write-Host 'Hello, World!'";


string shellScript = "import-module visualsvn \r get-childitem -Path 'D:\\PengW\\work\\SVNWeb\\SVN\\SvnRepositories' | select-object name,mode,length"; //
                                                                                                                                                        //string shellScript = "import-module visualsvn \r get-childitem -Path 'D:\\SoftWare\\SVN\\SVNRepositories' | select-object name,mode";

var urlPath = "/";
var totalsss = urlPath.Split("/").ToList().Where(r => !string.IsNullOrWhiteSpace(r)).ToList();


var filePath = @"D:\PengW\work\SVNWeb\SVN\SvnRepositories\htpasswd";

var datas = await File.ReadAllTextAsync(filePath);
var tetete = datas.Split("\r\n").ToList().Where(x => !string.IsNullOrWhiteSpace(x)).Select(r => r.Split(":")[0]).ToList();
var tetetepp = datas.Split("\r\n").ToList().Where(x => !string.IsNullOrWhiteSpace(x)).Select(r => r.Split(":")[1]).ToList();
foreach (var item in tetete)
{
    Console.WriteLine(item);
}




//SVNHelper.ssssTask("TEST01");


Console.ReadKey();



//#region 获取svn 仓库信息

//// 执行 PowerShell 脚本
//var txt = ExecutePowerShell.ExecutePowerShellScript("Get-SvnRepositoryItem -repository \"TEST01\" -path \"/TEST02/TEST021\" | select-object Name,Type");

//var temp = txt.Split("\r\n").ToList();
//var tempDatas = temp.Where(r => r.Contains("Folder") || r.Contains("File")).ToList();
//foreach (var item in tempDatas)
//{
//    var standardDatas = item.Split(" ").ToList().Where(r => !string.IsNullOrWhiteSpace(r)).Where(r => r != "Folder").Where(r => r != "File").ToList();
//}


//var datas = temp.Where(r => r.Contains("Fsfs")).ToList();
//foreach (var item in datas)
//{
//    var ssss = item.Split(" ").ToList().Where(r => !string.IsNullOrWhiteSpace(r)).ToList();
//    foreach (var temps in ssss)
//    {
//        Console.WriteLine(temps);
//    }
//}

//var newDatas = datas.Select(r => r.Replace("d-----", "").Trim()).ToList();


//foreach (var item in newDatas)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine(txt);
//#endregion

//string[] strArr = new string[] { "test", "demo", "kill" };

//SVNHelper.CreateRepositoryFolders("repositoryTest6", strArr);
//var isok = SVNHelper.CreatGroup("userGroupTest3");

//var isok = SVNHelper.CreateRepository("repositoryTest6");

//string CreateRepositoryShellScript = "new-svnrepositoryitem -repository \"repositoryTest6\" -path \"/test/demo\" -type \"folder\""; // 
//ExecutePowerShell.ExecutePowerShellScript(CreateRepositoryShellScript);






