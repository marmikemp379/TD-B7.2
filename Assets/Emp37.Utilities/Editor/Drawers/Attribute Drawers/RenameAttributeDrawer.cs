using UnityEngine;

using UnityEditor;

namespace Emp37.Editor
{
      [CustomPropertyDrawer(typeof(Attribute.RenameAttribute))]
      internal class LabelAttributeDrawer : PropertyDrawer
      {
            private protected override void OnPropertyDraw(Rect position, SerializedProperty property, GUIContent label) => _ = EditorGUI.PropertyField(position, property, (attribute as Attribute.RenameAttribute).Label, true);
      }
}