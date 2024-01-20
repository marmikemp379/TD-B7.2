using UnityEngine;

namespace Emp37
{
      public static class Extensions
      {
            #region T R A N S F O R M
            /// <summary>
            /// Redefines the local position, rotation and scale of the specified transform to their default values.
            /// </summary>
            public static void Reset(this Transform context)
            {
                  context.SetLocalPositionAndRotation(default, default);
                  context.localScale = Vector3.one;
            }
            #endregion
      }
}