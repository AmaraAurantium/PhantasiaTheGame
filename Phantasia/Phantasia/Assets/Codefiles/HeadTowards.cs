using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class HeadTowards : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer mesh;
    public Material Facematerial;

    // Start is called before the first frame update
    private void SetHeadDirection()
    {
        Material[] materials = mesh.materials;

        materials[1].SetVector("_HeadForward", this.transform.forward);
        materials[1].SetVector("_HeadRight", this.transform.right);
        mesh.sharedMaterials = materials;
    }

    // Update is called once per frame
    private void Update()
    {
        this.SetHeadDirection();
    }
}
