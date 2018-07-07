using System.Collections.Generic;
using Models.Generators;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    [KnownType(typeof(Properties))]
    public class Properties
    {
        [DataMember]
        public long Id { get; set; }

        public string Name { get; set; }

        public List<long> Child { get; set; }
       
        //TODO подумать как хранить данные**
        public Dictionary<string,string> Text { get; set; }

        public string Type { get; set; }

        //TODO Саня реализуй**
        public Properties()
        {
            var id = IdGenerator.GetId();
            var name = NameGenerator.GetName();
            



            this.Id = id;
            this.Name = name;

        }
    }
}