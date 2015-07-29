using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour {
	void Awake () {
		StartCoroutine(Linecasts());
	}
	IEnumerator Linecasts(){
		yield return new WaitForSeconds(.1f);
		if(!Physics.Linecast(transform.position + new Vector3(0,3,0), transform.position + new Vector3(7,3,0))){
			if(!Physics.Linecast(transform.position + new Vector3(7,3,0), transform.position + new Vector3(0,-15,0))){
				GameObject go = WorldCreator.Instance.SpawnSegment(transform.position + new Vector3(7,0,0));
				for(int i = 0; i < 4; i++){
					if(Physics.Linecast(transform.position + new Vector3(0,3,0), transform.position + new Vector3(7,3,0))){
						go.transform.Rotate(Vector3.up, i * 90f);
					}
					else{
						break;
					}
				}
			}
		}
		yield return new WaitForSeconds(.1f);
		if(!Physics.Linecast(transform.position + new Vector3(0,3,0), transform.position + new Vector3(-7,3,0))){
			if(!Physics.Linecast(transform.position + new Vector3(-7,3,0), transform.position + new Vector3(0,-15,0))){
				GameObject go = WorldCreator.Instance.SpawnSegment(transform.position + new Vector3(-7,0,0));
				for(int i = 0; i < 4; i++){
					if(Physics.Linecast(transform.position + new Vector3(0,3,0), transform.position + new Vector3(-7,3,0))){
						go.transform.Rotate(Vector3.up, i * 90);
					}
					else{
						break;
					}
				}
			}
		}
		yield return new WaitForSeconds(.1f);
		if(!Physics.Linecast(transform.position + new Vector3(0,3,0), transform.position + new Vector3(0,3,7))){
			if(!Physics.Linecast(transform.position + new Vector3(0,3,7), transform.position + new Vector3(0,-15,0))){
				GameObject go = WorldCreator.Instance.SpawnSegment(transform.position + new Vector3(0,0,7));
				for(int i = 0; i < 4; i++){
					if(Physics.Linecast(transform.position + new Vector3(0,3,0), transform.position + new Vector3(0,3,7))){
						go.transform.Rotate(Vector3.up, i * 90f);
					}
					else{
						break;
					}
				}
			}
		}
		yield return new WaitForSeconds(.1f);
		if(!Physics.Linecast(transform.position + new Vector3(0,3,0), transform.position + new Vector3(0,3,-7))){
			if(!Physics.Linecast(transform.position + new Vector3(0,3,-7), transform.position + new Vector3(0,-15,0))){
				GameObject go = WorldCreator.Instance.SpawnSegment(transform.position + new Vector3(0,0,-7));
				for(int i = 0; i < 4; i++){
					if(Physics.Linecast(transform.position + new Vector3(0,3,0), transform.position + new Vector3(0,3,-7))){
						go.transform.Rotate(Vector3.up, i * 90f);
					}
					else{
						break;
					}
				}
			}
		}
	}
}
