using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dockable"))
            gameObject.BroadcastMessage("Open");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dockable"))
            gameObject.BroadcastMessage("Close");
    }
}
