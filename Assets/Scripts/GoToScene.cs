using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToScene : MonoBehaviour
{

    public SceneUtils.SceneID nextScene = SceneUtils.SceneID.Lobby;
    
    public void Go()
    {
        SceneLoader.Instance.LoadScene(SceneUtils.scenes[(int)nextScene]);
    }

   
}
