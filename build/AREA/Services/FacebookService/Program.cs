﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Network.Client client = Network.Client.Instance;
                Network.NetTools.IService service = new GraphAPI();
                client.Start("MessageBus", service.GetCallback(), args[1], int.Parse(args[2]));
            }
            catch (Exception err)
            {
                Console.Error.WriteLine(err.Message);
            }
            Console.ReadKey();
        }
    }
}
