using UnityEngine;

using UnityEditor;

namespace Emp37.Editor
{
      [CustomPropertyDrawer(typeof(Attribute.ReadonlyAttribute))]
      internal class ReadonlyAttributeDrawer : PropertyDrawer
      {
            private protected override void OnPropertyDraw(Rect position, SerializedProperty property, GUIContent label)
            {
                  GUI.enabled = false;
                  _ = EditorGUI.PropertyField(position, property, label, true);
                  GUI.enabled = true;
            }
      }
}