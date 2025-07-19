using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

//OK this is really screwed up. monobehaviour works with events manager maybe?
public class AraInteraction: MonoBehaviour
{
    [Header("Dialogue")]

    [SerializeField] private string dialogueKnotName;

    public GameObject ara;

    public event Action onAraClicked;
    public event Action onScreenClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (ara == getClickedObject(out RaycastHit hit))
            {
                Debug.Log("ara pressed");
                onAraClicked?.Invoke();

                if (!dialogueKnotName.Equals(""))
                {
                    EventsManager.instance.dialogueEvents.EnterDialogue(dialogueKnotName);
                }
            }
            else
            {
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

