using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderlayPassthrough : MonoBehaviour
{
    OVRPassthroughLayer passthroughLayer;
    public GameObject bg;
    public Material m_skyBox;


    void Start()
    {
        GameObject ovrCameraRig = GameObject.Find("XR Origin");
        if (ovrCameraRig == null)
        {
            Debug.LogError("Scene does not contain an OVRCameraRig");
            return;
        }

        passthroughLayer = ovrCameraRig.GetComponent<OVRPassthroughLayer>();
        if (passthroughLayer == null)
        {
            Debug.LogError("OVRCameraRig does not contain an OVRPassthroughLayer component");
        }

        
    }

    void Update()
    {
        //bg = GameObject.FindWithTag("Background");

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            passthroughLayer.hidden = !passthroughLayer.hidden;

            bg.SetActive(passthroughLayer.hidden);

            if (!passthroughLayer.hidden)
                RenderSettings.skybox = null;
            if (passthroughLayer.hidden)
                RenderSettings.skybox = m_skyBox;


            Debug.Log("Background");
        }
    }
}
