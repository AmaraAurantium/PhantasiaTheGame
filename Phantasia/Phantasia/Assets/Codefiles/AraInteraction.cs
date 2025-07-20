using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

[Serializable]
struct AraInteractionInfo
{
    [SerializeField] public string dialogueKnotName;
    [SerializeField] public GameObject ara;
}

public class AraInteraction : MonoBehaviour
{
    [Header("Dialogue")]

    [SerializeField] private List<AraInteractionInfo> araInteractionInfos;

    public event Action onAraClicked;
    public event Action onScreenClicked;

    void Awake()
    {
        
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            bool bHandled = false;
            foreach (var araInteractionInfo in araInteractionInfos)
            {
                var clickedObj = getClickedObject(out RaycastHit hit);
                if(araInteractionInfo.ara == clickedObj)
                {
                    onAraClicked?.Invoke();

                    if (!araInteractionInfo.dialogueKnotName.Equals(""))
                    {
                        bHandled = EventsManager.instance.dialogueEvents.EnterDialogue(araInteractionInfo.dialogueKnotName);
                        Debug.Log("bHandled state: " + bHandled);
                    }
                }
            }
            if (!bHandled)
            {
                //Debug.Log("clicked other space in screen.");
                onScreenClicked?.Invoke();
            }
        }
    }

    GameObject getClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit))
        {
            if (!isPointerOverUIObject()){ target = hit.collider.gameObject; }
        }
        return target;
    }
    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
}

