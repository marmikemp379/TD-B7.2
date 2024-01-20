using System;

using UnityEngine;

namespace Emp37.Attribute
{
      /// <summary>
      /// Attribute used to customize the label of a property in the inspector.
      /// </summary>
      [AttributeUsage(AttributeTargets.Field)]
      public class RenameAttribute : PropertyAttribute
      {
            public readonly GUIContent Label;

            /// <param name="label">Name to display the property with.</param>
            public RenameAttribute(string label) => Label = new(text: label);
      }
}