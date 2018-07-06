using System;

namespace Models.Generators
{
    internal static class IdGenerator
    {
        public static long GetId()
        {
            return new Random().Next(0, int.MaxValue);
        }
        public static long GetStringId()
        {
            //#Unity TODO: добавить строку вложености вначале
            return new Random().Next(0, int.MaxValue);
        }
    }
}