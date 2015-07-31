using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour {

	Vector3 origin;
	RaycastHit hit;

	GameObject reddot;

	public bool MakeObjectAtCollision;
	public bool LaserPointer;

	public bool AnnounceHit;

	public Material redmat;

	private bool didHit;

	void Start () {
		if (LaserPointer) {
			reddot = GameObject.CreatePrimitive (PrimitiveType.Cube);
			reddot.GetComponent<MeshRenderer> ().material = redmat;
			reddot.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			reddot.layer = 2; //Ignores raycast
		}
	}

	public void Shoot(Vector3 fwd) {
		didHit = false;
		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			didHit = true;
			origin = transform.position;

			if (AnnounceHit) {
				print ("BANG! Hit " + hit.transform.name + "!");
			}

			if (MakeObjectAtCollision)
				GameObject.CreatePrimitive (PrimitiveType.Cube).transform.position = hit.point;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (origin, hit.point, Color.red);

		if (LaserPointer && Physics.Raycast (transform.position, transform.forward, out hit)) {
			reddot.transform.position = hit.point;
		}
	}
}
