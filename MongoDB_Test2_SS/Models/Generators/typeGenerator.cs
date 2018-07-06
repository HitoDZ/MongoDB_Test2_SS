using System;
using System.Collections.Generic;

namespace Models.Generators
{
    internal static class typeGenerator
    {
        private static List<string> _types;

        static typeGenerator()
        {
            _types = new List<string>{};
        }

        public static string GetName()
        {
            var next = new Random().Next(0, _types.Count);

            return _types[next];
        }
    }
}