﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ergolys.DataModel
{
    public class Service : IInterface
    {
        public void ServiceWriteLine() {
            Console.WriteLine("ServiceClass");
            Console.ReadLine();
        }
    }
}