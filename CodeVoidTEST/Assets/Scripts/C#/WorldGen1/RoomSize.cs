using UnityEngine;
using System.Collections;

public class RoomSize : MonoBehaviour {

	public int X = 1;
	public int Y = 1;
	void Start () {
		for(int i = 0; i < X; i++){
			for(int j = 0; j < Y; j++){
				if(Physics.Linecast(transform.position + new Vector3(i, 3, j), transform.position + new Vector3(0,3,0))){
					Debug.DrawLine(transform.position + new Vector3(i, 3, j), transform.position + new Vector3(0,3,0), Color.red);
					Debug.LogError("No Room " + i + " " + j);
				}
			}
		}
	}
}
