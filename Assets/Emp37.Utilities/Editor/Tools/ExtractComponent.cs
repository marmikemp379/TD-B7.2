using UnityEngine;

using UnityEditor;
using UnityEditorInternal;

internal static class ExtractComponent //~Warped Imagination
{
      [MenuItem("CONTEXT/Component/Extract", priority = 524)] public static void ExtractMenuOption(MenuCommand command) => Extract(command, 0);
      [MenuItem("CONTEXT/Component/Extract To Child", priority = 525)] public static void ExtractToChildMenuOption(MenuCommand command) => Extract(command, 1);


      private static void Extract(MenuCommand command, int level)
      {
            var source = command.context as Component;

            int undoGroupID = Undo.GetCurrentGroup();
            Undo.IncrementCurrentGroup();

            var child = new GameObject(source.GetType().Name);
            Emp37.Extensions.Reset(child.transform);
            child.transform.parent = level switch
            {
                  0 => source.transform.parent,
                  1 => source.transform,
                  _ => null
            };
            Undo.RegisterCreatedObjectUndo(child, "Created child object.");

            if (!ComponentUtility.CopyComponent(source) || !ComponentUtility.PasteComponentAsNew(child))
            {
                  Debug.LogError($"Cannot extract {source.GetType().Name} from {source.name}.", source.gameObject);

                  Undo.CollapseUndoOperations(undoGroupID);
                  Undo.PerformUndo();

                  return;
            }
            Undo.DestroyObjectImmediate(source);
            Undo.CollapseUndoOperations(undoGroupID);
      }
}