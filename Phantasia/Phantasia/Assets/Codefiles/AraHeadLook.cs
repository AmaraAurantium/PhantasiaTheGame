using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AraHeadLook : MonoBehaviour
{
    private Camera currcam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currcam = Camera.main;
        if (Input.touchCount > 0)
        {
            Touch firsttouch = Input.GetTouch(0);
            Vector3 lookposition = currcam.ScreenToWorldPoint(firsttouch.position);
            transform.LookAt(lookposition);
        }
    }
}
