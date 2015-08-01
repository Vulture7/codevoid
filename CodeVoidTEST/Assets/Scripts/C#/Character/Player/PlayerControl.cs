using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour {

    public bool inManager;

	Animator an;
	Animator an_arm;
	public Camera MainCamera;
	public GameObject LookReference;
	public GameObject TurnReference;
	public GameObject PlayerModel;
	public GameObject Arms;
	public GameObject Chest;
	CharacterController cc;

	public GameObject gun;
	RaycastTest rct;

	AudioSource Gunshot;
	public ParticleSystem GunFlare;

	bool ADS = false;
	bool UpdateRotation = false;
	float ShootingTimer = 0f;

	public float MoveSpeed;
	public float AimMoveSpeed;
	Quaternion LastTurn;

	float normalFOV = 90f;

	// Use this for initialization
	void Start () {
		an = PlayerModel.GetComponent <Animator> ();
		an_arm = Arms.GetComponent <Animator> ();

		rct = gun.GetComponent <RaycastTest> ();

		cc = GetComponent <CharacterController> ();

		Gunshot = GetComponent <AudioSource>();

		normalFOV = MainCamera.fieldOfView;
	}

	void Anim_SetMultiBool(string name, bool value) {
		an.SetBool(name, value);
		an_arm.SetBool(name, value);
	}

	void Anim_SetMultiTrig(string triggername) {
		an.SetTrigger (triggername);
		an_arm.SetTrigger (triggername);
	}

	Vector3 movement = Vector3.zero;

	bool 	TURN_RIGHT = false,
			TURN_FWD = true,
			TURN_LEFT = false,
			TURN_BACK = false;

	// Update is called once per frame
	void Update () {
        if (inManager) { return; }

		TURN_RIGHT = false;
		TURN_FWD   = false;
		TURN_LEFT  = false;
		TURN_BACK  = false;

		UpdateRotation = false;

		/*
		if (!cc.isGrounded)
			movement.y -= Time.deltaTime;
		else
			movement.y = 0f;
*/
		//Begin horrible, awful code that will be optimized soon

		if (Input.GetMouseButtonDown (1)) {
			ADS = true;
			Anim_SetMultiBool("Shooting", true);
			ShootingTimer = 0.01f;
		}
		if (Input.GetMouseButtonUp (1)) {
			ADS = false;
			ShootingTimer = 0.02f;
		}

		//Forward
		if (Input.GetKey (KeyCode.W)) {
			if (an.GetBool("Shooting")) {
				transform.position += transform.forward * Time.deltaTime * AimMoveSpeed;
			}
			else
				transform.position += transform.forward * Time.deltaTime * MoveSpeed;

			TURN_FWD = true;

			UpdateRotation = true;
			Anim_SetMultiBool("RunForward", true);
		}
		if (!Input.GetKey (KeyCode.W) && an.GetBool ("RunForward")) {
			Anim_SetMultiBool ("RunForward", false);
		}

		//Left straft
		if (Input.GetKey (KeyCode.A)) {
			if (an.GetBool("Shooting")){
				Anim_SetMultiBool ("StrafeLeft", true);
				transform.position -= transform.right * Time.deltaTime * AimMoveSpeed;
				TURN_LEFT = false;
			} else {
				TURN_LEFT = true;
				Anim_SetMultiBool ("RunForward", true);
				transform.position -= transform.right * Time.deltaTime * MoveSpeed;
			}
			
			UpdateRotation = true;
		} //Right strafe
		else if (Input.GetKey (KeyCode.D)) {
			if (an.GetBool("Shooting")){
				TURN_RIGHT = false;
				Anim_SetMultiBool ("StrafeRight", true);
				transform.position += transform.right * Time.deltaTime * AimMoveSpeed;
			} else {
				TURN_RIGHT = true;
				Anim_SetMultiBool ("RunForward", true);
				transform.position += transform.right * Time.deltaTime * MoveSpeed;
			}
			
			UpdateRotation = true;
		}
		/*
		if (!Input.GetKey (KeyCode.D) && an.GetBool ("RunForward")) {
			Anim_SetMultiBool ("StrafeRight", false);
		}*/
		
		//backwards
		if (Input.GetKey (KeyCode.S)) {
			if (an.GetBool("Shooting")){
				Anim_SetMultiBool ("WalkBackward", true);
				transform.position -= transform.forward * Time.deltaTime * AimMoveSpeed;
				TURN_BACK = false;
			} else {
				TURN_BACK = true;
				Anim_SetMultiBool ("RunForward", true);
				transform.position -= transform.forward * Time.deltaTime * MoveSpeed;
			}

			UpdateRotation = true;
		}
			
		if (!Input.GetKey (KeyCode.W) && an.GetBool ("RunForward")) {
			Anim_SetMultiBool ("RunBackward", false);
			Anim_SetMultiBool ("WalkBackward", false);
		}
		//End horrible, awful code

		if (Input.GetMouseButtonDown (0)) {
			rct.Shoot(gun.transform.forward);
			UpdateRotation = true;
			GunFlare.Play();
			Gunshot.Play();
			Anim_SetMultiTrig("Shoot");
			Anim_SetMultiBool ("Shooting", true);
			ShootingTimer = 0.5f;
		}
		if (ShootingTimer > 0 && !ADS) {
			TURN_FWD = true;
			TURN_RIGHT = false;
			TURN_LEFT = false;
			TURN_BACK = false;
			ShootingTimer -= Time.deltaTime;
		}
		if (an.GetBool ("Shooting") && ShootingTimer < 0)
			Anim_SetMultiBool ("Shooting", false);

		if (ADS) {
			TURN_FWD = true;
			TURN_RIGHT = false;
			TURN_LEFT = false;
			TURN_BACK = false;
			UpdateRotation = true;
			MainCamera.fieldOfView = Mathf.Lerp (MainCamera.fieldOfView, normalFOV * 0.7f, (0.99f * Time.deltaTime*5));
		} else {
			MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, normalFOV, 0.99f*(Time.deltaTime*10));
		}

		if (TURN_FWD) {
			if (TURN_RIGHT) {
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (Vector3.Lerp (transform.right, transform.forward, 0.5f)), 0.9f * (Time.deltaTime * 10));
			} else if (TURN_LEFT) {
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (Vector3.Lerp (-transform.right, transform.forward, 0.5f)), 0.9f * (Time.deltaTime * 10));
			} else
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (transform.forward), 0.9f * (Time.deltaTime * 10));
		} else if (TURN_BACK) {
			if (TURN_RIGHT) {
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (Vector3.Lerp (transform.right, -transform.forward, 0.5f)), 0.9f * (Time.deltaTime * 20));
			} else if (TURN_LEFT) {
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (Vector3.Lerp (-transform.right, -transform.forward, 0.5f)), 0.9f * (Time.deltaTime * 20));
			} else 
				PlayerModel.transform.rotation = Quaternion.Lerp (PlayerModel.transform.rotation, Quaternion.LookRotation (-transform.forward), 0.9f * (Time.deltaTime * 10));
		} else if (TURN_RIGHT) {
			PlayerModel.transform.rotation = Quaternion.Lerp(PlayerModel.transform.rotation, Quaternion.LookRotation(transform.right), 0.9f*(Time.deltaTime*10));
		} else if (TURN_LEFT) {
			PlayerModel.transform.rotation = Quaternion.Lerp(PlayerModel.transform.rotation, Quaternion.LookRotation(-transform.right), 0.9f*(Time.deltaTime*10));
		}

		if (UpdateRotation) {
			transform.rotation = TurnReference.transform.rotation;
			TurnReference.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		}

		cc.Move(movement);
	}

	float changetmp = 0f;

	void LateUpdate()
	{
		changetmp = LookReference.transform.rotation.x - Arms.transform.rotation.x;

		if (ADS || an.GetBool("Shooting")) { 
			Arms.transform.RotateAround (Arms.transform.position, Chest.transform.right, (LookReference.transform.localRotation.x - Arms.transform.localRotation.x) * 40);
		} else {
			Arms.transform.RotateAround (Arms.transform.position, Chest.transform.right, ((0.12f) - Arms.transform.localRotation.x) * 20);
		}	
				
			
		
	}
}

