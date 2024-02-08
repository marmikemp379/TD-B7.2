using UnityEngine;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

namespace TDS.UI
{
      public class Group : MonoBehaviour
      {
            [SerializeField] private TMP_Text label;
            [SerializeField] private RectTransform rectTransform, contentTransform;


            public void Start()
            {
                  label.text = name;

                  AdjustContentSize(contentTransform);
                  AdjustContentSize(rectTransform);
            }

            private void AdjustContentSize(RectTransform transform)
            {
                  float height = 0F;

                  if (transform.TryGetComponent(out VerticalLayoutGroup layout))
                  {
                        height += layout.padding.top + layout.spacing * transform.childCount;
                  }
                  for (int i = 0; i < transform.childCount; i++)
                  {
                        height += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.y;
                  }
                  transform.sizeDelta = new(x: transform.sizeDelta.x, y: height);
            }
      }


#if UNITY_EDITOR
      [CustomEditor(typeof(Group))]
      internal class GroupEditor : Editor
      {
            public override void OnInspectorGUI()
            {
                  base.OnInspectorGUI();

                  GUILayout.Space(10F);
                  if (GUILayout.Button("Validate", GUILayout.Height(30F)))
                  {
                        var target = base.target as Group;

                        target.Start();
                  }
            }
      }
#endif
}