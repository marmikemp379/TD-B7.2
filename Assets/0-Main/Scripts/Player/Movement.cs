using UnityEngine;

using Emp37.Attribute;

namespace TDS.Player
{
      using Object;


      [RequireComponent(typeof(Character))]
      public class Movement : MonoBehaviour
      {
            private InputKeys keys;

            public float Pace;
            [SerializeField, Readonly] private Vector2 direction;

            public bool IsMoving => direction != Vector2.zero;


            private void Awake()
            {
                  if (TryGetComponent(out Character ch))
                  {
                        keys = ch.keys;
                  }
            }
            private void OnDisable()
            {
                  direction = default;
            }
            private void OnApplicationFocus(bool focus)
            {
                  if (enabled && !focus) direction = default;
            }
            private void FixedUpdate()
            {
                  if (IsMoving)
                  {
                        transform.Translate(Pace * Time.deltaTime * direction, Space.World);
                  }
            }
            private void Update()
            {
                  #region I N P U T   H A N D L I N G
                  if (Input.GetKeyDown(keys.Forward)) direction.y += 1F;
                  if (Input.GetKeyDown(keys.Backward)) direction.y -= 1F;
                  if (Input.GetKeyDown(keys.Left)) direction.x -= 1F;
                  if (Input.GetKeyDown(keys.Right)) direction.x += 1F;

                  if (Input.GetKeyUp(keys.Forward)) direction.y -= 1F;
                  if (Input.GetKeyUp(keys.Backward)) direction.y += 1F;
                  if (Input.GetKeyUp(keys.Left)) direction.x += 1F;
                  if (Input.GetKeyUp(keys.Right)) direction.x -= 1F;
                  #endregion
            }
      }
}