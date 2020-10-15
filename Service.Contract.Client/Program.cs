using System;
using System.Management.Automation;

namespace WJ.V.Service.Contract.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string strCmdText =
                @"./ProtoGen/protoc -I=./proto ./proto/student.proto --js_out=import_style=commonjs:./proto --grpc-web_out=import_style=commonjs,mode=grpcwebtext:./proto";

            PowerShell ps = PowerShell.Create();
            ps.AddCommand(strCmdText);
            ps.Invoke();
        }
    }
}
