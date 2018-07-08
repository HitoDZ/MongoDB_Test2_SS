using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Models;

namespace BL_Mocks
{

    class Program
    {

        static List<Client> Clients()
        {
            List<Client> clientList = new List<Client>();

            for (int i = 0; i < 5; i++)
            {
                Client test = new Client();
                clientList.Add(test);
            }

            return clientList;
        }

    

        static void Main(string[] args)
        {
            string dbName = "SS_test1DB";
            string clientsCollectionName = "ClientsCollection";

            List<Properties> properties = new List<Properties>();
            var clients = Clients();

            var dbprovider = new DbLayer.MongoDbProvider("mongodb://localhost:27017", dbName);
            // fill clients
            var clientRepository = new PersistanceLayer.MongoClientsRepository(dbprovider,clientsCollectionName);
            clientRepository.CreateClients(clients);
            Console.WriteLine("Create clients:"+clients.Count);
            // fill properties for each client and each workcollection 
            foreach (var client in clients)
            {
                foreach (var workcolname in client.WorkCollection)
                {
                    var workcoll = new PersistanceLayer.MongoPropertiesRepository(dbprovider, workcolname);
                    properties.Clear();
                    MockProperties.AddPropertiesToRootTree(properties,long.Parse(workcolname));
                    workcoll.CreateProperties(properties);
                }
            }
            Console.WriteLine("All done. Clients:" + clients.Count);
             Console.ReadKey();
        }
    }
}