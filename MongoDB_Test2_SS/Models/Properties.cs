using System.Collections.Generic;

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
            
        }
    }
}