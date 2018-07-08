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
            var clientRepository = new PersistanceLayer.MongoClientsRepository(dbprovider,clientsCollectionName);
            clientRepository.CreateClients(clients);
            Console.WriteLine("Create clients:"+clients.Count);

            foreach (var client in clients)
            {
                foreach (var workcolname in client.WorkCollection)
                {
                    var workcoll = new PersistanceLayer.MongoPropertiesRepository(dbprovider, workcolname);
                    properties.Clear();
                    MockProperties.AddPropertiesToRootTree(properties);
                    workcoll.CreateProperties(properties);
                }
            }
            Console.WriteLine("Create workcpll:" + clients.Count);

           // var prop = new PersistanceLayer.MongoPropertiesRepository(dbprovider, ""); 
            /*

            
            
            dbConnection.CreateCollection(clientsCollectionName);   // create client collection
            dbConnection.InsertMany(clienList, clientsCollectionName);  // insert client
            Console.WriteLine("client insert done");
            
            foreach (var client in clienList)
            {
                var workCollections = client.WorkCollection;
                foreach (var workCollection in workCollections)
                             dbConnection.CreateCollection(workCollection); // createworkcoll
            }
            Console.WriteLine("workcoll create done");

            foreach (var client in clienList)
            {
                var workCollections = client.WorkCollection;
                foreach (var workCollection in workCollections)
                {
                    properties.Clear();
                    MockProperties.AddPropertiesToRootTree(properties);
                    dbConnection.InsertMany(properties, workCollection);
                }
            }
            Console.WriteLine("workcoll insert done");

            Console.WriteLine("Hello World! "+properties.Count);
           */ Console.ReadKey();
        }
    }
}