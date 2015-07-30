using UnityEngine;
using System.Collections;

/* PlayerCamera.cs
 * Written by Thomas Hall, (C)2015
 */

public class PlayerCamera : MonoBehaviour {
	
	public float YSensitivity = 1.0f;
	public float XSensitivity = 1.0f;

	public bool ModifyVertical = true;
	public bool ModifyHorizontal = false;

	public bool Invert = false;
	
	float mousey, mousex;
	
	// Use this for initialization
	void Start () {
		mousey = Input.mousePosition.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (ModifyHorizontal) 
			transform.Rotate (0f, -(mousex - Input.mousePosition.x) * XSensitivity, 0f);

		if (ModifyVertical)
			if ((mousey - Input.mousePosition.y) < 0 || transform.localRotation.x < 0.6) {
				if ((mousey - Input.mousePosition.y) > 0 || transform.localRotation.x > -0.6) {
					if (Invert) {
						transform.Rotate (-(mousey - Input.mousePosition.y) * YSensitivity, 0f, 0f);
					} else {
						transform.Rotate ((mousey - Input.mousePosition.y) * YSensitivity, 0f, 0f);
					}
				} else {
					transform.localRotation.Set(-0.6f,
					                       transform.localRotation.y,
					                       transform.localRotation.z,
					                       transform.localRotation.w);
				}
			} else {
				transform.localRotation.Set(0.6f,
				                       transform.localRotation.y,
				                       transform.localRotation.z,
				                       transform.localRotation.w);
			}
		
		mousex = Input.mousePosition.x;
		mousey = Input.mousePosition.y;
	}
}
