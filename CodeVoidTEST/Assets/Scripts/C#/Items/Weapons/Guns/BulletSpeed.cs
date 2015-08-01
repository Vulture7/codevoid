using UnityEngine;
using System.Collections;

public class BulletSpeed : MonoBehaviour {
	public Vector3 Dir;

	void FixedUpdate () {
		GetComponent<Rigidbody>().velocity = Dir;
	}
	void OnTriggerEnter(Collider col){
		if(col.transform.parent.gameObject.name != "Bullet(Clone)"){
			Debug.Log(col.gameObject.name);
			Destroy(this.gameObject);
		}
	}
}
