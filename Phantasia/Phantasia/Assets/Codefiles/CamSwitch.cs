using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject roomcam;
    public GameObject deskcam;
    public GameObject bedcam;
    public GameObject roomara;
    public GameObject deskara;
    public GameObject bedara;
    public int camswitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            camswitch++;
        }
        //roomcam on
        if (camswitch == 0)
        {
            roomara.SetActive(true);
            deskara.SetActive(false);
            bedara.SetActive(false);

            roomcam.SetActive(true);
            deskcam.SetActive(false);
            bedcam.SetActive(false);

        }
        //deskcam on
        else if (camswitch == 1)
        {
            deskara.SetActive(true);
            bedara.SetActive(false);
            roomara.SetActive(false);

            deskcam.SetActive(true);
            bedcam.SetActive(false);
            roomcam.SetActive(false);
        }
        //bedcam on
        else if (camswitch == 2)
        {
            bedara.SetActive(true);
            roomara.SetActive(false);
            deskara.SetActive(false);

            bedcam.SetActive(true);
            roomcam.SetActive(false);
            deskcam.SetActive(false);
        }
        if (camswitch == 3)
        {
            camswitch = 0;
        }
}
}
