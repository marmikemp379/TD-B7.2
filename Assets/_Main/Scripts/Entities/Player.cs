using UnityEngine;

namespace Game
{
      using Animation;

      public class Player : MonoBehaviour
      {
            private Animator animator;

            [Header("R E Q U I R E D   R E F E R E N C E S")]
            [SerializeField] private new Camera camera;
            [SerializeField] private Settings settings;
            private Keybinds Key => settings.Key;


            [Header("M O V E M E N T")]
            public float Pace = 10F;


            [Header("A I M I N G")]
            [SerializeField] private float angleOffset = 100F;


            [Header("R A W   I N P U T")]
            [SerializeField] private Vector2 keyboard;
            [SerializeField] private Vector2 mouse;
            private bool IsKeyboardActive => keyboard.x != 0 || keyboard.y != 0;
            private bool IsMouseActive => mouse.x != 0 || mouse.y != 0;


            [Header("I N F O")]
            [SerializeField] private Weapons equippedWeapon;


            // E D I T O R
            private void Reset()
            {
                  if (!camera) camera = Camera.main;
            }

            // R U N T I M E
            private void Awake()
            {
                  animator = GetComponent<Animator>();
            }
            private void Update()
            {
                  #region A C T I O N S
                  if (Input.GetKeyDown(Key.Attack))
                  {
                        animator.SetTrigger(HashLibrary.Attack);
                  }
                  else
                  if (Input.GetKeyUp(Key.Attack))
                  {
                        animator.ResetTrigger(HashLibrary.Attack);
                  }
                  #endregion

                  #region M O V E M E N T
                  keyboard.Set(GetAxisRaw(Key.Right, Key.Left), GetAxisRaw(Key.Forward, Key.Back));
                  if (IsKeyboardActive)
                  {
                        transform.Translate(Pace * Time.deltaTime * keyboard.normalized, Space.World);
                  }
                  #endregion

                  #region R O T A T I O N
                  mouse.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                  if (IsMouseActive)
                  {
                        var displacement = (camera.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                        var angle = Mathf.Atan2(y: displacement.y, x: displacement.x) * Mathf.Rad2Deg;

                        transform.localRotation = Quaternion.Euler(x: 0F, y: 0F, z: angle + angleOffset);
                  }
                  #endregion
            }

            // C U S T O M
            private static float GetAxisRaw(KeyCode positive, KeyCode negative) => (Input.GetKey(positive) ? 1F : 0F) - (Input.GetKey(negative) ? 1F : 0F);
      }
}