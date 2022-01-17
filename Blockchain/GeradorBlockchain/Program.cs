using GeradorBlockchain.Models;
using GeradorBlockchain.Services;
using System;
using System.Collections.Generic;

namespace GeradorBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            GeraBlockchain serviceGeraBlockchain = new GeraBlockchain();

            serviceGeraBlockchain.GerarBlockChain();

            Console.ReadKey();
        }
    }
}
