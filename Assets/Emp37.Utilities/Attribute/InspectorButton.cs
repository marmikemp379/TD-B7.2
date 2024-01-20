using System;

namespace Emp37.Attribute
{
      /// <summary>
      /// Attribute used to display a method as button on the inspector.
      /// </summary>
      [AttributeUsage(AttributeTargets.Method)]
      public class InspectorButtonAttribute : System.Attribute
      {
            public readonly string Label;
            public readonly float Height = 18F;

            public InspectorButtonAttribute()
            {
            }
            /// <param name="label">The label to display on the button.</param>
            public InspectorButtonAttribute(string label)
            {
                  Label = label;
            }
            /// <param name="height">The height of the button in pixels.</param>
            public InspectorButtonAttribute(float height)
            {
                  Height = height;
            }
            public InspectorButtonAttribute(string label, float height)
            {
                  Label = label;
                  Height = height;
            }
      }
}