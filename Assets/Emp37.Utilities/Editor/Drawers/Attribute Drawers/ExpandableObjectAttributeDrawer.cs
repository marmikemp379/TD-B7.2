using UnityEngine;

using UnityEditor;

namespace Emp37.Editor
{
//      [CustomPropertyDrawer(typeof(Attribute.ExpandableObjectAttribute))]
//      internal class ExpandableObjectAttributeDrawer : PropertyDrawer // ~Warped Imagination
//      {
//            private UnityEditor.Editor m_Editor = null;

//            private protected override void OnPropertyDraw(Rect position, SerializedProperty property, GUIContent label)
//            {
//                  if (property.propertyType != SerializedPropertyType.ObjectReference)
//                  {
//                        EditorGUI.HelpBox(position, "Use ExpandableObject attribute on a serializedObject.", MessageType.Error);
//                        return;
//                  }
//                  _ = EditorGUI.PropertyField(position, property, label, true);

//                  if (property.objectReferenceValue != null && (property.isExpanded = GUI.Toggle(position, property.isExpanded, GUIContent.none, GUIStyle.none)))
//                  {
//                        position.y += EditorGUIUtility.singleLineHeight;
//                        using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
//                        {
//                              if (m_Editor == null)
//                              {
//                                    UnityEditor.Editor.CreateCachedEditor(property.objectReferenceValue, null, ref m_Editor);
//                              }
//                              else
//                              {
//                                    m_Editor.OnInspectorGUI();
//                              }
//                        }
//                  }
//            }
      }