using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Automation.Opc.WcfClient.OpcServerServiceReference;

namespace Nutshell.Automation.Opc.WcfClient
{
        class Program
        {
                static void Main(string[] args)
                {
                        OpcServerServiceClient client = new OpcServerServiceClient();
                        var result = client.IsOnline();
                        Console.WriteLine(result);

                        Console.ReadKey();
                }
        }
}
