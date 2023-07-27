using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{

    public float duration = 4;


    public void GoFade()
    {
        gameObject.GetComponent<Renderer>().material.DOFade(0.0785f, duration);
    }
}
