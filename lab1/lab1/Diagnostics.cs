using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace lab1
{
    public class Diagnostics
    {
        Process myProcess;
        string fileName;
        public double cpuTime;
        string s1;
        string s2;
        string args;

        public double CPUTime { get { return cpuTime; } }

        public Diagnostics(string fileName, string s1, string s2, string typeAlg)
        {
            this.fileName = fileName;
            this.s1 = s1;
            this.s2 = s2;
            args = s1 + " " + s2 + " " + typeAlg;

        }

        public void TimeAndMem()
        {
            bool flag = true;

            using (myProcess = Process.Start("C:\\Student_work\\C#\\AnAl\\lab1\\lab1\\ExmplLab1.exe", args))
            {
                while (flag)
                {
                    if (myProcess.HasExited)
                    {
                        flag = false;
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}");
                        Console.WriteLine($"  Total processor time      : {myProcess.TotalProcessorTime}");
                    }
                }

                cpuTime = myProcess.UserProcessorTime.TotalMilliseconds;
            }
        }
    }
}
