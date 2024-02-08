using System;
using TDS.Object;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyChanger : MonoBehaviour
{
      [SerializeField] private Keybinds keybinds;
      [SerializeField] private TMP_Text keycode;
      [SerializeField] private Button editKeybind;

      [SerializeField] private string keyToChange;

      [SerializeField] private bool isEditing;


      private void OnEnable()
      {
            keycode.text = keybinds.Forward.ToString();

            editKeybind.onClick.AddListener(OnClick);
      }
      private void OnDisable()
      {
            editKeybind.onClick.RemoveListener(OnClick);
      }

      private void OnClick()
      {
            isEditing = true;
      }

      private void Update()
      {
            if (isEditing && Input.anyKeyDown)
            {
                  foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
                  {
                        if (Input.GetKeyDown(code))
                        {
                              isEditing = false;
                              keybinds[keyToChange] = code;
                              break;
                        }
                  }
            }
      }


}