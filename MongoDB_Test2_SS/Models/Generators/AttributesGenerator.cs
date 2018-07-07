using System;
using System.Collections.Generic;

namespace Models.Generators
{
    public static class AttributesGenerator
    {
        private static Dictionary<string, string> Attributes;

        static AttributesGenerator()
        {
            Attributes = new Dictionary<string, string> { { "Country", "UK" } };
        }

        public static Dictionary<string, string> GetDict()
        {
            var next = new Random().Next(0, Attributes.Count);

            return Attributes;
        }
    }
}