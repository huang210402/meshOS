using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEditor;

public static class SceneMenu
{

    [MenuItem("Scenes/LobbyAwake")]
    static void OpenLobbyAwake()
    {
        OpenScene(SceneUtils.Names.LobbyAwake);
    }

    [MenuItem("Scenes/Lobby")]
    static void OpenLobby()
    {
        OpenScene(SceneUtils.Names.Lobby);
    }

    [MenuItem("Scenes/App")]
    static void OpenApp()
    {
        OpenScene(SceneUtils.Names.App);
    }

    static void OpenScene(string name)
    {
        Scene persistentScene = EditorSceneManager.OpenScene("Assets/Scenes/" + SceneUtils.Names.XRPersistent + ".unity", OpenSceneMode.Single);
        Scene currentScene = EditorSceneManager.OpenScene("Assets/Scenes/" + name + ".unity", OpenSceneMode.Additive);

        SceneUtils.AlignXROrigin(persistentScene, currentScene);
    }
}
