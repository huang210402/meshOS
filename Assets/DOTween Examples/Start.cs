using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameEvent cubeStart;

    void CubeStart()
    {
        cubeStart.Raise();
    }
}
