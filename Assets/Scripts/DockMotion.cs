using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class DockMotion : MonoBehaviour
{
    XRBaseInteractable m_interactable = null;
    private GameObject m_gameObject = null;

    bool isSelected = false;

    private GameObject icon = null;
    private Vector3 m_scale;

    private GameObject env = null;
    private Vector3 m_scaleEnv;

    private GameObject srfLeft = null;
    private GameObject srfRight = null;
    private GameObject srfFront = null;
    private GameObject srfBack = null;
    public Transform origin = null;
    public Transform target = null;
    public Transform iconOrigin = null;
    public Transform envOrigin = null;
    public Transform srfLeftOrigin = null;
    public Transform srfRightOrigin = null;
    public Transform srfFrontOrigin = null;
    public Transform srfBackOrigin = null;
    public Transform iconTarget = null;
    public Transform envTarget = null;
    public Transform srfLeftTarget = null;
    public Transform srfRightTarget = null;
    public Transform srfFrontTarget = null;
    public Transform srfBackTarget = null;

    public float duration = 2;

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

        icon = FindChildGameObjectByName(m_gameObject, "icon");
        env = FindChildGameObjectByName(m_gameObject, "env");

        srfLeft = FindChildGameObjectByName(m_gameObject, "srfLeft");
        srfRight = FindChildGameObjectByName(m_gameObject, "srfRight");
        srfFront = FindChildGameObjectByName(m_gameObject, "srfFront");
        srfBack = FindChildGameObjectByName(m_gameObject, "srfBack");

        m_scale = icon.transform.localScale;
        m_scaleEnv = env.transform.localScale;

        Debug.Log(gameObject + "is selected" + m_scale);
    }

    private void SwapOutController(HoverExitEventArgs arg0)
    {
        m_gameObject = null;

        isSelected = false;
        Debug.Log(gameObject + "is deselected");

        //icon = null;
        //srfLeft = null;
        //srfRight = null;
        //srfFront = null;
        //srfBack = null;
    }

    private void OnDisable()
    {
        m_interactable.hoverEntered.RemoveListener(SwapInController);
        m_interactable.hoverExited.RemoveListener(SwapOutController);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch) && isSelected)
        {
            Sequence s = DOTween.Sequence();
            s.Append(m_gameObject.transform.DOMove(target.position, duration));
            s.Insert(0, m_gameObject.transform.DORotate(target.eulerAngles, duration));
            s.OnComplete(() => {
                icon.transform.DOMove(iconTarget.position, duration);
                icon.transform.DORotate(iconTarget.eulerAngles, duration);
                icon.transform.DOScale(m_scale/2, duration);
                env.transform.DOMove(envTarget.position, duration);
                env.transform.DORotate(envTarget.eulerAngles, duration);
                env.transform.DOScale(m_scaleEnv * 8, duration);

                srfLeft.transform.DOMove(srfLeftTarget.position, duration);
                srfLeft.transform.DORotate(srfLeftTarget.eulerAngles, duration);
                srfRight.transform.DOMove(srfRightTarget.position, duration);
                srfRight.transform.DORotate(srfRightTarget.eulerAngles, duration);
                srfFront.transform.DOMove(srfFrontTarget.position, duration);
                srfFront.transform.DORotate(srfFrontTarget.eulerAngles, duration);
                srfBack.transform.DOMove(srfBackTarget.position, duration);
                srfBack.transform.DORotate(srfBackTarget.eulerAngles, duration);
            });
        }

        else if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.RTouch) && isSelected)
        {
            Sequence s = DOTween.Sequence();
            s.Insert(0, icon.transform.DOMove(iconOrigin.position, duration));
            s.Insert(0, icon.transform.DORotate(iconOrigin.eulerAngles, duration));
            s.Insert(0, icon.transform.DOScale(m_scale * 2, duration));
            env.transform.DOMove(envOrigin.position, duration);
            env.transform.DORotate(envOrigin.eulerAngles, duration);
            env.transform.DOScale(m_scaleEnv / 8, duration);

            s.Insert(0, srfLeft.transform.DOMove(srfLeftOrigin.position, duration));
            s.Insert(0, srfLeft.transform.DORotate(srfLeftOrigin.eulerAngles, duration));
            s.Insert(0, srfRight.transform.DOMove(srfRightOrigin.position, duration));
            s.Insert(0, srfRight.transform.DORotate(srfRightOrigin.eulerAngles, duration));
            s.Insert(0, srfFront.transform.DOMove(srfFrontOrigin.position, duration));
            s.Insert(0, srfFront.transform.DORotate(srfFrontOrigin.eulerAngles, duration));
            s.Insert(0, srfBack.transform.DOMove(srfBackOrigin.position, duration));
            s.Insert(0, srfBack.transform.DORotate(srfBackOrigin.eulerAngles, duration));
            s.OnComplete(() => {
                m_gameObject.transform.DOMove(origin.position, duration);
                m_gameObject.transform.DORotate(origin.eulerAngles, duration);
            });

        }
    }

    private GameObject FindChildGameObjectByName(GameObject parentGameObject,string gameObjectName)
    {
        for(int i  = 0; i < parentGameObject.transform.childCount; i++)
        {
            if(parentGameObject.transform.GetChild(i).name == gameObjectName)
            {
                return parentGameObject.transform.GetChild(i).gameObject;
            }
        }

        return null;
    }
}
