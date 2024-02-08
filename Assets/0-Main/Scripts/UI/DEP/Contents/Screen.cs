using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TDS.UI
{
      using Display = UnityEngine.Screen;


      public class Screen : MonoBehaviour
      {
            [SerializeField] private RectTransform rectTransform;
            [SerializeField] private VerticalLayoutGroup verticalLayoutGroup;

            [Space(10F)]
            [SerializeField] private TMP_Dropdown resolutionDropdown, screenModeDropdown;
            private Resolution[] resolutions;


            private void OnEnable()
            {
                  #region P O P U L A T E   R E S O L U T I O N S
                  resolutions = Display.resolutions;

                  var options = new List<string>();
                  foreach (var resolution in resolutions)
                  {
                        options.Add(resolution.width + " x " + resolution.height + " - " + resolution.refreshRateRatio);
                  }
                  resolutionDropdown.AddOptions(options);
                  #endregion

                  #region P O P U L A T E   S C R E E N   M O D E
                  screenModeDropdown.AddOptions(Enum.GetNames(typeof(FullScreenMode)).ToList());
                  #endregion
            }

            private void Reset()
            {
                  rectTransform = GetComponent<RectTransform>();
                  verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            }
            public void OnTransformChildrenChanged()
            {
                  float height = 0F;
                  for (int i = 0; i < transform.childCount; i++)
                  {
                        var rect = transform.GetChild(i).GetComponent<RectTransform>();
                        height += rect.sizeDelta.y;
                  }
                  height += transform.childCount * verticalLayoutGroup.spacing;

                  rectTransform.sizeDelta = new(rectTransform.sizeDelta.x, height);
            }


            public void OnResolutionChange(int value)
            {
                  var selection = resolutions[value];

                  Display.SetResolution(selection.width, selection.height, Display.fullScreenMode, selection.refreshRateRatio);
            }
            public void OnScreenModeChange(int value)
            {
                  // ??
            }
      }


#if UNITY_EDITOR
      [CustomEditor(typeof(Screen))]
      internal class ScreenEditor : Editor
      {
            public override void OnInspectorGUI()
            {
                  serializedObject.Update();
                  DrawPropertiesExcluding(serializedObject, "m_Script");
                  serializedObject.ApplyModifiedProperties();

                  GUILayout.Space(10F);
                  if (GUILayout.Button("Update", GUILayout.Height(30F)))
                  {
                        var target = base.target as Screen;

                        target.OnTransformChildrenChanged();
                  }
            }
      }
#endif
}