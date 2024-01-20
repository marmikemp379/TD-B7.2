using System;

namespace Emp37.Attribute
{
      /// <summary>
      /// Attribute used to visually separate content in the inspector with a horizontal line.
      /// </summary>
      [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
      public class DividerAttribute : UnityEngine.PropertyAttribute
      {
            public readonly byte Thickness = 2;

            public DividerAttribute()
            {
            }
            /// <param name="thickness">Height of the divider line in pixels.</param>
            public DividerAttribute(byte thickness) => Thickness = thickness;
      }
}