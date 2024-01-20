using System;

namespace Emp37.Attribute
{
      /// <summary>
      /// Attribute used to control the indentation level of a property in the inspector.
      /// </summary>
      [AttributeUsage(AttributeTargets.Field)]
      public class IndentAttribute : UnityEngine.PropertyAttribute
      {
            public readonly int Level;

            public IndentAttribute(int level) => Level = level;
      }
}