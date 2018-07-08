using Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BL_Mocks
{
    [DataContract]
    [KnownType(typeof(MockProperties))]
    public class MockProperties:Properties
    {
        public static int MinChildCount = 3;
        public static int MaxChildCount = 5;
        public static int MaxDepthLevel = 2;
        //Передаем уровень вложености для ID и ограничения рекурсии
        // Type - чтобы на одном уровне вложености были однотипные обьекты

        MockProperties(List<Properties> propertiesCollection, int depthLevel, string _Type, long id= 0)
        {
            Type = _Type;
            Name = _Type + "_" + new System.Random().Next(0, 1000);  // имя проперти состоит из типа +Rand номер
            if (id == 0)
                Id = Models.Generators.IdGenerator.GetIDWithDepth(depthLevel);
            else
                Id = id;
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

        public static void AddPropertiesToRootTree(List<Properties> propertiesCollection, long rootId)
        {
            propertiesCollection.Add(new MockProperties(propertiesCollection, 0, "bid", rootId));
        }

        public static void SetMockSettings(int _minChildCount, int _maxChildCount, int _maxDepthLevel)
        {
            MinChildCount = _minChildCount;
            MaxChildCount = _maxChildCount;
            MaxDepthLevel = _maxDepthLevel;
        }

    }
}