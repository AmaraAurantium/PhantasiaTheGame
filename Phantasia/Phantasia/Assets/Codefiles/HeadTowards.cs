using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class HeadTowards : MonoBehaviour
{
    public Material Facematerial;
    // Start is called before the first frame update
    private void SetHeadDirection()
    {
        if(this.Facematerial != null)
        {
            this.Facematerial.SetVector("_HeadForward",this.transform.forward);
            this.Facematerial.SetVector("_HeadRight",this.transform.right);
            Debug.Log("3");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        this.SetHeadDirection();
    }
}
