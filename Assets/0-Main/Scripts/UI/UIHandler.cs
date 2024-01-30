using UnityEngine;
using UnityEngine.Events;

public class UIHandler : MonoBehaviour
{
      public UnityEvent OnPause, OnUnpause;

      [SerializeField] private Canvas escapeCanvas;

      private void Reset()
      {
            escapeCanvas = GetComponent<Canvas>();
      }
      private void Update()
      {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                  if (escapeCanvas.enabled = !escapeCanvas.enabled) OnPause.Invoke();
                  else OnUnpause.Invoke();
            }
      }
}
