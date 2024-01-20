using UnityEngine;

namespace Emp37
{
      public static class Utility
      {
            /// <summary>
            /// Rescales a given value from a specified input range to a specified output range.
            /// </summary>
            /// <param name="value">The value to rescale.</param>
            /// <returns>The rescaled value clamped within the specified output range.</returns>
            public static float Remap(this float value, float iMin, float iMax, float oMin, float oMax) => Mathf.Lerp(a: oMin, b: oMax, t: Mathf.InverseLerp(a: iMin, b: iMax, value));
            /// <summary>
            /// Rescales a given value from a specified input range to a specified output range.
            /// </summary>
            /// <param name="value">The value to rescale.</param>
            /// <returns>The rescaled value unclamped within the specified output range.</returns>
            public static float RemapUnclamped(this float value, float iMin, float iMax, float oMin, float oMax) => Mathf.LerpUnclamped(a: oMin, b: oMax, t: InverseLerpUnclamped(a: iMin, b: iMax, value));
            /// <summary>
            /// Determines where a value lies between two points.
            /// </summary>
            /// <param name="a">The start of the range.</param>
            /// <param name="b">The end of the range.</param>
            /// <param name="value">The point within the range to calculate.</param>
            /// <returns>An unclamped value beyond zero or one, representing where the 'value' parameter falls within the range defined by a and b.</returns>
            public static float InverseLerpUnclamped(float a, float b, float value) => a != b ? (value - a) / (b - a) : default;
      }
}