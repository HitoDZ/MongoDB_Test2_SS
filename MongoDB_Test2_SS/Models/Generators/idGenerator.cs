using System;
using System.Collections.Generic;

namespace Models.Generators
{
    public static class IdGenerator
    {
        static System.Random rnd = new System.Random();
        static List<long> createdId = new List<long>();

        static long GetNewID(long oldID)
        {
            while (createdId.Contains(oldID))
                oldID++;

            createdId.Add(oldID);
            return oldID;
        }

        public static long GetId()
        {
            var id = rnd.Next(0, int.MaxValue);
            return GetNewID(id);
        }
        public static long GetStringId()
        {
            return rnd.Next(0, int.MaxValue);
        }

        public static long GetIDWithDepth(int depth)
        {
            var id =(rnd.Next(0, 1000)) + depth * 10000;
            return GetNewID(id);
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