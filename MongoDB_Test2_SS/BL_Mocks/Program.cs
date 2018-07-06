using System;
using System.Collections.Generic;
using Models;

namespace BL_Mocks
{
    class Program
    {

        static List<Client> Clients()
        {
            List<Client> clientList = new List<Client>();

            for (int i = 0; i < 100; i++)
            {
                Client test = new Client();
                clientList.Add(test);
            }

            return clientList;
        }

        static void Main(string[] args)
        {
            
            var clienList = Clients();
            string clientsCollectionName = "ClientsCollection";
            string dbName = "SS_test1DB";
            
            Console.WriteLine("Hello World!");
        }
    }
}