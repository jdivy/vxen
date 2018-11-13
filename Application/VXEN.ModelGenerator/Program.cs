﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VXEN.ModelGenerator.Steps;

namespace VXEN.ModelGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Current Directory to EXE location
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileInfo fileInfo = new FileInfo(assembly.Location);
            Environment.CurrentDirectory = fileInfo.Directory.FullName;

            // Download Schemas from VANTIV and use XSD to generate classes
            Download.Prebuild();

            // Workaround missing classes due to XSD provided being invalid
            CodeDom.FixMissingTransactionClasses();
        }
    }
}
