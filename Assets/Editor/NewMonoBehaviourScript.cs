using UnityEditor;
using UnityEngine;

public class RemoveAllScriptsPrefab : EditorWindow
{
    [MenuItem("Tools/Remove All Scripts From Selected (Prefab�Ή�)")]
    public static void ShowWindow()
    {
        GetWindow<RemoveAllScriptsPrefab>("Remove All Scripts");
    }

    void OnGUI()
    {
        GUILayout.Label("�I�������I�u�W�F�N�g��Prefab�̃X�N���v�g�����ׂč폜���܂�", EditorStyles.wordWrappedLabel);

        if (GUILayout.Button("�폜���s"))
        {
            RemoveScriptsFromSelected();
        }
    }

    static void RemoveScriptsFromSelected()
    {
        foreach (GameObject go in Selection.gameObjects)
        {
            // �V�[�����̃I�u�W�F�N�g�Ȃ璼�ڍ폜
            RemoveScriptsFromGameObject(go);

            // Prefab�̏ꍇ��Prefab�̃A�Z�b�g���J���č폜
            GameObject prefabRoot = PrefabUtility.GetCorrespondingObjectFromSource(go);
            if (prefabRoot != null)
            {
                RemoveScriptsFromGameObject(prefabRoot);
                PrefabUtility.ApplyPrefabInstance(go, InteractionMode.UserAction);
            }
        }

        Debug.Log("�I�𒆂̃I�u�W�F�N�g�����Prefab����X�N���v�g���폜���܂����B");
    }

    static void RemoveScriptsFromGameObject(GameObject go)
    {
        MonoBehaviour[] scripts = go.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            DestroyImmediate(script, true);
        }

        // �q�I�u�W�F�N�g���ċA�I�ɍ폜
        foreach (Transform child in go.transform)
        {
            RemoveScriptsFromGameObject(child.gameObject);
        }
    }
}


