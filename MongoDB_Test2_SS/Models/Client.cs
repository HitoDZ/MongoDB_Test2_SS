using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Models
{
    public class Client : IIdentifieble
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<long> WorkCollection { get; set; }
        
       
       
        public Client()
        {
            
            var id = Generators.IdGenerator.GetId();
            var name = Generators.NameGenerator.GetName();
            var workColl = Generators.IdGenerator.GetId();
            var workColl2 = Generators.IdGenerator.GetId();

            this.WorkCollection = new List<long>();

            this.Id = id;
            this.Name = name;
            this.WorkCollection.Add(workColl);
            this.WorkCollection.Add(workColl2);

        }
        
//        public Client(long id,string name,string workCollection)
//        {
//            this.Id = id;
//            this.Name = name;
//            this.WorkCollection = workCollection;
//        }
//        
//        public static Client GenerateRandom()
//        {
//            
//            var id = IdGenerator.GetId();
//            var name = NameGenerator.GetName();
//            var workColl = "coll" + name + Convert.ToString(id);
//
//            var client = new Client(id, name, workColl);
//            
//
//            return client;
//        }

        
    }
}