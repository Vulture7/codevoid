using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	Vector3 origin;
	RaycastHit hit;

	public bool MakeObjectAtCollision;

	public void Shoot(Vector3 fwd) {
		Physics.Raycast (transform.position, transform.forward, out hit);
		origin = transform.position;

		print ("BANG! hit " + hit.transform.name);
		if (MakeObjectAtCollision)
			GameObject.CreatePrimitive (PrimitiveType.Cube).transform.position = hit.point;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (origin, hit.point, Color.red);
	}
}
