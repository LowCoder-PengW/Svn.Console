using System;
using System.Collections.Generic;
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

            ManagementClass managementClass = new ManagementClass("root\\Microsoft\\SqlServer\\ComputerManagement15", "SqlResourceSecurity", null);

            foreach (ManagementObject obj in managementClass.GetInstances())
            {
                Console.WriteLine("Name: " + obj["Name"]);
                Console.WriteLine("SecurityDescriptor: " + obj["SecurityDescriptor"]);
                // Add more properties as needed
            }


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
    }
}
