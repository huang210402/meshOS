using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class DockMotionGroup : MonoBehaviour
{
    XRBaseInteractable m_interactable = null;
    private GameObject m_gameObject = null;

    bool isSelected = false;

    public Transform origin = null;
    public Transform target = null;

    private GameObject icon1 = null;
    private GameObject icon2 = null;
    private GameObject icon3 = null;
    private GameObject icon4 = null;
    private GameObject icon5 = null;
    private GameObject icon6 = null;
    private GameObject icon7 = null;
    private GameObject icon8 = null;
    private GameObject icon9 = null;

    private GameObject srfLeft = null;
    private GameObject srfRight = null;
    private GameObject srfFront = null;
    private GameObject srfBack = null;

    public Transform icon1Origin = null;
    public Transform icon2Origin = null;
    public Transform icon3Origin = null;
    public Transform icon4Origin = null;
    public Transform icon5Origin = null;
    public Transform icon6Origin = null;
    public Transform icon7Origin = null;
    public Transform icon8Origin = null;
    public Transform icon9Origin = null;

    public Transform srfLeftOrigin = null;
    public Transform srfRightOrigin = null;
    public Transform srfFrontOrigin = null;
    public Transform srfBackOrigin = null;

    public Transform icon1Target = null;
    public Transform icon2Target = null;
    public Transform icon3Target = null;
    public Transform icon4Target = null;
    public Transform icon5Target = null;
    public Transform icon6Target = null;
    public Transform icon7Target = null;
    public Transform icon8Target = null;
    public Transform icon9Target = null;

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

        Debug.Log(gameObject + "is selected");

        icon1 = FindChildGameObjectByName(m_gameObject, "at");
        icon2 = FindChildGameObjectByName(m_gameObject, "blender");
        icon3 = FindChildGameObjectByName(m_gameObject, "bag");
        icon4 = FindChildGameObjectByName(m_gameObject, "bookmark");
        icon5 = FindChildGameObjectByName(m_gameObject, "calculator");
        icon6 = FindChildGameObjectByName(m_gameObject, "chart");
        icon7 = FindChildGameObjectByName(m_gameObject, "crown");
        icon8 = FindChildGameObjectByName(m_gameObject, "gym");
        icon9 = FindChildGameObjectByName(m_gameObject, "card");

        srfLeft = FindChildGameObjectByName(m_gameObject, "srfLeft");
        srfRight = FindChildGameObjectByName(m_gameObject, "srfRight");
        srfFront = FindChildGameObjectByName(m_gameObject, "srfFront");
        srfBack = FindChildGameObjectByName(m_gameObject, "srfBack");
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
                icon1.transform.DOMove(icon1Target.position, duration);
                icon1.transform.DORotate(icon1Target.eulerAngles, duration);
                icon2.transform.DOMove(icon2Target.position, duration);
                icon2.transform.DORotate(icon2Target.eulerAngles, duration);
                icon3.transform.DOMove(icon3Target.position, duration);
                icon3.transform.DORotate(icon3Target.eulerAngles, duration);
                icon4.transform.DOMove(icon4Target.position, duration);
                icon4.transform.DORotate(icon4Target.eulerAngles, duration);
                icon5.transform.DOMove(icon5Target.position, duration);
                icon5.transform.DORotate(icon5Target.eulerAngles, duration);
                icon6.transform.DOMove(icon6Target.position, duration);
                icon6.transform.DORotate(icon6Target.eulerAngles, duration);
                icon7.transform.DOMove(icon7Target.position, duration);
                icon7.transform.DORotate(icon7Target.eulerAngles, duration);
                icon8.transform.DOMove(icon8Target.position, duration);
                icon8.transform.DORotate(icon8Target.eulerAngles, duration);
                icon9.transform.DOMove(icon9Target.position, duration);
                icon9.transform.DORotate(icon9Target.eulerAngles, duration);

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
            s.Insert(0, icon1.transform.DOMove(icon1Origin.position, duration));
            s.Insert(0, icon1.transform.DORotate(icon1Origin.eulerAngles, duration));
            s.Insert(0, icon2.transform.DOMove(icon2Origin.position, duration));
            s.Insert(0, icon2.transform.DORotate(icon2Origin.eulerAngles, duration));
            s.Insert(0, icon3.transform.DOMove(icon3Origin.position, duration));
            s.Insert(0, icon3.transform.DORotate(icon3Origin.eulerAngles, duration));
            s.Insert(0, icon4.transform.DOMove(icon4Origin.position, duration));
            s.Insert(0, icon4.transform.DORotate(icon4Origin.eulerAngles, duration));
            s.Insert(0, icon5.transform.DOMove(icon5Origin.position, duration));
            s.Insert(0, icon5.transform.DORotate(icon5Origin.eulerAngles, duration));
            s.Insert(0, icon6.transform.DOMove(icon6Origin.position, duration));
            s.Insert(0, icon6.transform.DORotate(icon6Origin.eulerAngles, duration));
            s.Insert(0, icon7.transform.DOMove(icon7Origin.position, duration));
            s.Insert(0, icon7.transform.DORotate(icon7Origin.eulerAngles, duration));
            s.Insert(0, icon8.transform.DOMove(icon8Origin.position, duration));
            s.Insert(0, icon8.transform.DORotate(icon8Origin.eulerAngles, duration));
            s.Insert(0, icon9.transform.DOMove(icon9Origin.position, duration));
            s.Insert(0, icon9.transform.DORotate(icon9Origin.eulerAngles, duration));

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

    private GameObject FindChildGameObjectByName(GameObject parentGameObject, string gameObjectName)
    {
        for (int i = 0; i < parentGameObject.transform.childCount; i++)
        {
            if (parentGameObject.transform.GetChild(i).name == gameObjectName)
            {
                return parentGameObject.transform.GetChild(i).gameObject;
            }
        }

        return null;
    }
}
