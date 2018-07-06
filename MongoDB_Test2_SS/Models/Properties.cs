using System.Collections.Generic;
using Models.Generators;

namespace Models
{
    public class Properties
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<string> Child { get; set; }
       
        //TODO подумать как хранить данные**
        public Dictionary<string,string> Text { get; set; }

        public string Type { get; set; }

        //TODO Саня реализуй**
        public Properties()
        {
            var id = IdGenerator.GetId();
            var name = NameGenerator.GetName();
            var workColl = "Bussines_" + name + IdGenerator.RandomColl();
            var workColl2 = "Bussines_" + name + IdGenerator.RandomColl();



            this.Id = id;
            this.Name = name;

        }
    }
}