using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneUtils
{

    public enum SceneID
    {
        LobbyAwake,
        Lobby,
        App
    }

    public static readonly string[] scenes = {Names.LobbyAwake, Names.Lobby, Names.App};
    public static class Names
    {
        public static readonly string XRPersistent = "XR Persistent";
        public static readonly string LobbyAwake = "Lobby Awake";
        public static readonly string Lobby = "Lobby";
        public static readonly string App = "App";

    }

    public static void AlignXROrigin(Scene persistentScene, Scene currentScene)
    {
        GameObject[] currentObjects = currentScene.GetRootGameObjects();
        GameObject[] persistentObjects = persistentScene.GetRootGameObjects();

        foreach (var originTarget in currentObjects) 
        {
            if (originTarget.CompareTag("XROriginTarget"))
            {
                foreach (var origin in persistentObjects) 
                {
                    if (origin.CompareTag("XROrigin"))
                    {
                        origin.transform.position = originTarget.transform.position;
                        origin.transform.rotation = originTarget.transform.rotation;
                        return;
                    }
                }
            }
        }
    }
}
