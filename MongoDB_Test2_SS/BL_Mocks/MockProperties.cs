using Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BL_Mocks
{
    [DataContract]
    [KnownType(typeof(MockProperties))]
    public class MockProperties:Properties
    {
        public const int MinChildCount = 3;
        public const int MaxChildCount = 5;
        public const int MaxDepthLevel = 5;
        //Передаем уровень вложености для ID и ограничения рекурсии
        // Type - чтобы на одном уровне вложености были однотипные обьекты

        MockProperties(List<Properties> propertiesCollection, int depthLevel, string _Type)
        {
            Type = _Type;
            Name = _Type + "_" + new System.Random().Next(0, 1000);  // имя проперти состоит из типа +Rand номер
            Id = Models.Generators.IdGenerator.GetIDWithDepth(depthLevel);
            Text = Models.Generators.AttributesGenerator.GetDict();

            int childcount = new System.Random().Next(MinChildCount, MaxChildCount);

            var ChildType = Models.Generators.TypeGenerator.GetName();
            int childDepthLevel = depthLevel + 1;

            Child = new List<long>();
            if (childDepthLevel < MaxDepthLevel)
                for (int i = 0; i < childcount; i++)
                {
                    var newchild = new MockProperties(propertiesCollection, childDepthLevel, ChildType);
                    propertiesCollection.Add(newchild);
                    Child.Add(newchild.Id);
                }

            // заполнение дочерних уровней


        }

        public static void AddPropertiesToRootTree(List<Properties> propertiesCollection)
        {
            propertiesCollection.Add(new MockProperties(propertiesCollection, 0, "bid"));
        }

    }
}