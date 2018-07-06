using System;
using System.Collections.Generic;


namespace Models
{
    public class Client
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<string> WorkCollection { get; set; }
        
       
        //TODO: у меня не получилось исправить ошибку
        public Client()
        {
            
            var id = IdGenerator.GetId();
            var name = NameGenerator.GetName();
            var workColl = "coll" + name + Convert.ToString(id);
    


            this.Id = id;
            this.Name = name;
            this.WorkCollection = workColl;

        }
        
        public Client(long id,string name,string workCollection)
        {
            this.Id = id;
            this.Name = name;
            this.WorkCollection = workCollection;
        }
        
        public static Client GenerateRandom()
        {
            
            var id = IdGenerator.GetId();
            var name = NameGenerator.GetName();
            var workColl = "coll" + name + Convert.ToString(id);

            var client = new Client(id, name, workColl);
            

            return client;
        }
    }
}