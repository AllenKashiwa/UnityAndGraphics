using System.IO;
using UnityEditor;
using UnityEngine;

public static class SavePrefabHelper
{
    [MenuItem("GameObject/SavePrefab", false, 10)]
    public static void SavePrefab()
    {
        var selectingGO = Selection.activeObject as GameObject;
        if (selectingGO == null)
        {
            return;
        }

        var prefabName = selectingGO.name;
        var index = prefabName.IndexOf("(Clone)");
        if (index > 0)
        {
            prefabName = prefabName.Remove(index);
        }

        var prefabs = AssetDatabase.FindAssets("t:prefab");
        foreach (var item in prefabs)
        {
            var prefabPath = AssetDatabase.GUIDToAssetPath(item);
            var fileName = Path.GetFileNameWithoutExtension(prefabPath);
            if (fileName == prefabName)
            {
                PrefabUtility.SaveAsPrefabAssetAndConnect(selectingGO, prefabPath, InteractionMode.AutomatedAction, out var success);
                if (success)
                {
                    EditorUtility.DisplayDialog("SavePrefab", $"SavePrefab {prefabPath} Success!", "OK");
                    return;
                }
            }
        }
        EditorUtility.DisplayDialog("SavePrefab", "SavePrefab Failed!", "OK");
    }
}
