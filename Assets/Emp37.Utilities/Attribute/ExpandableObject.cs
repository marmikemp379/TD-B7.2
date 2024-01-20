using System;

namespace Emp37.Attribute
{
#if UNITY_2022_1_OR_NEWER
      /// <summary>
      /// Attribute used to expand the representation of a serializable object value in the inspector.
      /// </summary>
      /// <remarks><b>NOTE: </b>To expand or collapse the associated serialized object, click property label when the object value is not null.</remarks>
      [AttributeUsage(AttributeTargets.Field)]
      public class ExpandableObjectAttribute : UnityEngine.PropertyAttribute
      {
      }
#endif
}