using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorBehaviour : MonoBehaviour
{
    public Transform target;

    public float frames;

    private Vector3 openPos;
    private Vector3 closePos;

    private void Start()
    {
        closePos = transform.position;
        openPos = target.transform.position;
    }


    public void Open()
    {
        StopAllCoroutines();
        StartCoroutine(AnchorMove(transform.position, openPos, 1/frames));
    }

    public void Close()
    {
        StopAllCoroutines();
        StartCoroutine(AnchorMove(transform.position, closePos, 1 / frames));
    }

    IEnumerator AnchorMove(Vector3 startPos, Vector3 endPos, float step)
    {
        for(float i = 0; i <=1f; i += step)
        {
            Vector3 newPos = Vector3.Lerp(startPos, endPos, i);
            transform.position = newPos;
            yield return null;
        }
        
    }
}
