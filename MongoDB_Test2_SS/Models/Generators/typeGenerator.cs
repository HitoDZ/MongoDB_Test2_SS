using System;
using System.Collections.Generic;

namespace Models.Generators
{
    internal static class TypeGenerator
    {
        private static List<string> _types;

        static TypeGenerator()
        {
            _types = new List<string>{"Country","Department","Rozdil","Otdelenie","Cast","Rota"};
        }

        public static string GetName()
        {
            var next = new Random().Next(0, _types.Count);

            return _types[next];
        }
    }
}