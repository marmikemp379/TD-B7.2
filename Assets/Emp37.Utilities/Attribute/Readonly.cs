using System;

namespace Emp37.Attribute
{
      /// <summary>
      /// Attribute used to mark a serialized field as read-only in the inspector.
      /// </summary>
      [AttributeUsage(AttributeTargets.Field)]
      public class ReadonlyAttribute : UnityEngine.PropertyAttribute
      {
      }
}