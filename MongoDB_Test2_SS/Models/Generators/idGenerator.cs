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
         public static string RandomColl()
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