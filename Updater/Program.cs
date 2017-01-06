using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2) throw new Exception("Недопустимое количество аргументов приложения.");

                String arg_0 = args[0];
                String arg_1 = args[1];

                //String arg_0 = "GS_UpdDB.update";
                //String arg_1 = "GS_UpdDB.exe";

                //  arg_1 = "GS_UpdDB.exe";

                if (!(File.Exists(arg_0) && File.Exists(arg_1))) return;

                string process = arg_1.Replace(".exe", "");

                Console.WriteLine("Terminate process " + arg_1);

                while (Process.GetProcessesByName(process).Length > 0)
                {
                    Process[] myProcesses = Process.GetProcessesByName(process);

                    for (int i = 0; i < myProcesses.Length; i++) myProcesses[i].Kill();

                    Thread.Sleep(300);
                }

                if (File.Exists(arg_1)) { File.Delete(arg_1); }

                File.Move(arg_0, arg_1);

                Console.WriteLine("Starting " + arg_1);
                Process.Start(arg_1);
            }
            catch (Exception err) {                  
                Console.WriteLine(err);
            }
        }
    }
}
