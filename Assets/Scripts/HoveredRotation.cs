using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class HoveredRotation : MonoBehaviour
{
    XRBaseInteractable m_interactable = null;
    private GameObject m_gameObject = null;

    bool isSelected = false;

    public Transform targetOrigin = null;
    public Transform targetLeft = null;
    public Transform targetRight = null;

    int turnCount = 0;
    public float duration = 2;

    public Vector3 m_scale = new Vector3((float)10.33192, (float)10.33192, (float)10.33192);

    void Awake()
    {
        m_interactable = GetComponent<XRBaseInteractable>();
    }

    private void OnEnable()
    {
        m_interactable.hoverEntered.AddListener(SwapInController);
        m_interactable.hoverExited.AddListener(SwapOutController);
    }

    private void SwapInController(HoverEnterEventArgs arg0)
    {
        m_gameObject = gameObject;
        isSelected = true;
        Debug.Log(gameObject + "is selected");
    }

    private void SwapOutController(HoverExitEventArgs arg0)
    {
        m_gameObject = null;
        isSelected = false;
        turnCount = 0;
        Debug.Log(gameObject + "is deselected" + turnCount);
    }

    private void OnDisable()
    {
        m_interactable.hoverEntered.RemoveListener(SwapInController);
        m_interactable.hoverExited.RemoveListener(SwapOutController);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
        {
            turnCount--;
            if (turnCount == -2)
            {
                turnCount = 1;
            }
            //Debug.Log(m_gameObject + "GetLeft" + turnCount);

            m_gameObject.transform.DOScale(m_scale / 3 * 2, duration / 2)
                .OnComplete(
                () => { m_gameObject.transform.DOScale(m_scale, duration / 2); }
                );
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
        {
            turnCount++;
            if (turnCount == 2)
            {
                turnCount = -1;
            }
            //Debug.Log(m_gameObject + "GetRight" + turnCount);
            
            m_gameObject.transform.DOScale(m_scale / 3 *2, duration/2)
                .OnComplete(
                () => {m_gameObject.transform.DOScale(m_scale , duration / 2); }
                );
            
        }


        if (turnCount == 0 && isSelected) 
        {
            m_gameObject.transform.DOMove(targetOrigin.position, duration);
            m_gameObject.transform.DORotate(targetOrigin.eulerAngles, duration);
            
        }
        else if (turnCount == -1 && isSelected)
        {
            m_gameObject.transform.DOMove(targetLeft.position, duration);
            m_gameObject.transform.DORotate(targetLeft.eulerAngles, duration);
            
        }
        else if (turnCount == 1 && isSelected)
        {
            m_gameObject.transform.DOMove(targetRight.position, duration);
            m_gameObject.transform.DORotate(targetRight.eulerAngles, duration);
            
        }
    }
}
