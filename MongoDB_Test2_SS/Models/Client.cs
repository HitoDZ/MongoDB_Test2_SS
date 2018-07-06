using System;
using System.Collections.Generic;
using System.ComponentModel;
using Models.Generators;

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
            var workColl = "Bussines_" + name + RandomColl();
            var workColl2 = "Bussines_" + name + RandomColl();



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

        public string RandomColl()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}