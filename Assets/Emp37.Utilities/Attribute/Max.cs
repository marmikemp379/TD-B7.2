using System;

namespace Emp37.Attribute
{
      /// <summary>
      /// Attribute used to make a serialized float or interger field type be restricted to a specific maximum value.
      /// </summary>
      [AttributeUsage(AttributeTargets.Field)]
      public class MaxAttribute : UnityEngine.PropertyAttribute
      {
            public readonly float Value;

            /// <param name="value">The maximum allowed value.</param>
            public MaxAttribute(float value) => Value = value;
      }
}