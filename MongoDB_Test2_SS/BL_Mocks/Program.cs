using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Models;

namespace BL_Mocks
{

    class Program
    {

        static List<Client> Clients(int clientCount)
        {
            List<Client> clientList = new List<Client>();

            for (int i = 0; i < clientCount; i++)
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
            MockProperties.SetMockSettings(3, 5, 5); // не обязательно задавать есть по умолчанию

            List<Properties> properties = new List<Properties>();
            var clients = Clients(5);

            var dbprovider = new DbLayer.MongoDbProvider("mongodb://localhost:27017", dbName);
            
            // fill clients
            var clientRepository = new PersistanceLayer.MongoClientsRepository(dbprovider,clientsCollectionName);
            clientRepository.CreateClients(clients);
            Console.WriteLine("Create clients:"+clients.Count);
            
            // fill properties for each client and each workcollection 
            foreach (var client in clients)
            {
                foreach (var workcolnameID in client.WorkCollection)
                {
                    var workcoll = new PersistanceLayer.MongoPropertiesRepository(dbprovider, workcolnameID.ToString());
                    properties.Clear(); // ВАЖНО не удалять строку очистки пропертей для следующего клиента
                    MockProperties.AddPropertiesToRootTree(properties,workcolnameID);
                    workcoll.CreateProperties(properties);
                }
            }
            Console.WriteLine("All done. Clients:" + clients.Count);
 

            // пробую сделать тестовый проход
            // TODO конечно стоит вынести в методи и сделать рефакторинг, но позже
            var rnd = new Random();
            var  someclient = clientRepository.ReadClient(clients[rnd.Next(0, clients.Count)].Id);
            var workcollectionname = someclient.WorkCollection[0];
            var findworkcoll = new PersistanceLayer.MongoPropertiesRepository(dbprovider,workcollectionname.ToString());
            Console.WriteLine("Find workcoll:" + workcollectionname);

            var rootProperty = findworkcoll.ReadProperty(workcollectionname);
            while (rootProperty.Child.Count > 0)
            {
                Console.WriteLine("Property:" + rootProperty.Id);
                rootProperty = findworkcoll.ReadProperty(rootProperty.Child[0]);
            }
            Console.WriteLine("Find id = "+rootProperty.Id); // assert  id начинаеться с цифры глубины вложености  = мы на дне
            Console.ReadKey();
        }
    }
}