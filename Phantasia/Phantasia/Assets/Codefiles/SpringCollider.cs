using UnityEngine;
using System.Collections;

public class SpringCollider : MonoBehaviour
{
	//半径
    public float radius = 0.5f;
	public float disX = 0.0f;
	public float disY = 0.0f;
	public float disZ = 0.0f;
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position + new Vector3(disX, disY, disZ), radius);
	}
}