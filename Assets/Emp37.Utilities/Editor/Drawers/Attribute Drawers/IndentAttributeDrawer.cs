using UnityEngine;

using UnityEditor;

namespace Emp37.Editor
{
      [CustomPropertyDrawer(typeof(Attribute.IndentAttribute))]
      internal class IndentAttributeDrawer : PropertyDrawer
      {
            private protected override void OnPropertyDraw(Rect position, SerializedProperty property, GUIContent label)
            {
                  int indent = EditorGUI.indentLevel;
                  EditorGUI.indentLevel = (attribute as Attribute.IndentAttribute).Level;
                  _ = EditorGUI.PropertyField(position, property, label, true);
                  EditorGUI.indentLevel = indent;
            }
      }
}