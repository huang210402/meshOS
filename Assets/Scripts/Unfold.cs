using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.ProBuilder.Shapes;

public class Unfold : MonoBehaviour
{
    public Transform entity;
    public Transform target;
    //public Vector3 rotation;

    public float duration = 4;


    public void GoUnfold()
    {
        
        // Create a new Sequence.
        // We will set it so that the whole duration is 6
        Sequence s = DOTween.Sequence();

        s.Append(entity.DOMove(target.position, duration));
        // Insert a rotation tween which will last half the duration
        // and will loop forward and backward twice
        s.Insert(0, entity.DORotate(target.eulerAngles, duration));
        //s.Insert(0, entity.GetComponent<Renderer>().material.DOFade(0.0785f, duration));
    }
}
