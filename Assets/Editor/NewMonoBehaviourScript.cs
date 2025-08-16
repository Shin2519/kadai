using UnityEditor;
using UnityEngine;

public class RemoveAllScriptsPrefab : EditorWindow
{
    [MenuItem("Tools/Remove All Scripts From Selected (Prefab対応)")]
    public static void ShowWindow()
    {
        GetWindow<RemoveAllScriptsPrefab>("Remove All Scripts");
    }

    void OnGUI()
    {
        GUILayout.Label("選択したオブジェクトやPrefabのスクリプトをすべて削除します", EditorStyles.wordWrappedLabel);

        if (GUILayout.Button("削除実行"))
        {
            RemoveScriptsFromSelected();
        }
    }

    static void RemoveScriptsFromSelected()
    {
        foreach (GameObject go in Selection.gameObjects)
        {
            // シーン内のオブジェクトなら直接削除
            RemoveScriptsFromGameObject(go);

            // Prefabの場合はPrefabのアセットを開いて削除
            GameObject prefabRoot = PrefabUtility.GetCorrespondingObjectFromSource(go);
            if (prefabRoot != null)
            {
                RemoveScriptsFromGameObject(prefabRoot);
                PrefabUtility.ApplyPrefabInstance(go, InteractionMode.UserAction);
            }
        }

        Debug.Log("選択中のオブジェクトおよびPrefabからスクリプトを削除しました。");
    }

    static void RemoveScriptsFromGameObject(GameObject go)
    {
        MonoBehaviour[] scripts = go.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            DestroyImmediate(script, true);
        }

        // 子オブジェクトも再帰的に削除
        foreach (Transform child in go.transform)
        {
            RemoveScriptsFromGameObject(child.gameObject);
        }
    }
}


