using UnityEngine;
using UnityEngine.Events;

using TDS.Object;

namespace TDS.UI
{
      public class OptionMenu : MonoBehaviour
      {
            [SerializeField] private Settings settings;
            [SerializeField] private Canvas canvas;

            public UnityEvent OnInitialize;
            public UnityEvent<bool> OnStateChange;


            private void Reset()
            {
                  canvas = GetComponent<Canvas>();
            }
            private void OnEnable()
            {
                  OnInitialize.Invoke();
            }
            private void Update()
            {
                  if (Input.GetKeyDown(KeyCode.Escape))
                  {
                        OnStateChange.Invoke(canvas.enabled = !canvas.enabled);
                  }
            }
      }
}