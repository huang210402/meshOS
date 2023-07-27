using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public Transform entity;


    public void GoDisable()
    {
        // Create a new Sequence.
        // We will set it so that the whole duration is 6
 
    
        gameObject.SetActive(false);
    }
}
