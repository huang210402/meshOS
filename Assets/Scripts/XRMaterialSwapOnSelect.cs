using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRMaterialSwapOnSelect : MonoBehaviour
{
    public Material selectMaterial = null;
    public Behaviour hoverScript = null;

    public void GoSwap()
    {
        hoverScript.enabled = false;
        gameObject.GetComponent<Renderer>().material = selectMaterial;
    }
}
