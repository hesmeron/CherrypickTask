using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridCreator))]
public class GridCreatorEditor :Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridCreator gridCreator = target as GridCreator;

        if (GUILayout.Button("Create grrid"))
        {
            Undo.RecordObject(gridCreator, "Add Curve");
            gridCreator.ClearAndCreateGrid();
            EditorUtility.SetDirty(gridCreator);
        }
    }
}
