using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {
	public GameObject BulletPrefab;
	public enum Type {
		Shotgun,
		SemiAuto,
		FullAuto
	}
	public Type GunType;
	public float Delay = 1;
	public float BulletSpeed = 10;
//	[Range(0f,15f)]
	public float Spread = 10f;
	float RealSpread;
	bool IsFiring = false;
	Vector3 Dir;

	void Start () {
		RealSpread = Spread / 100f;
	}

	void Update () {
		if(Input.GetMouseButtonDown(0) && !IsFiring){
			StartCoroutine(Firing());
		}
	}
	IEnumerator Firing(){
		IsFiring = true;
		Dir = transform.forward;
		float Rand1 = 0;
		float Rand2 = 0;
		if(GunType != Type.Shotgun){
			if(RealSpread != 0){
				Rand1 = Random.Range(-RealSpread,RealSpread);
				Rand2 = Random.Range(-RealSpread,RealSpread);
			}
			GameObject go = (GameObject)Instantiate(BulletPrefab, this.transform.GetChild(1).position, new Quaternion(this.transform.parent.rotation.x + Rand1, this.transform.parent.rotation.y + Rand2, this.transform.parent.rotation.z, this.transform.parent.rotation.w));
			Dir.x += Rand1;
			Dir.y += Rand2;
			go.GetComponent<BulletSpeed>().Dir =  Dir * BulletSpeed;
			yield return new WaitForSeconds(Delay);
		}
		else{
			int j = Random.Range(5,10);
			for(int i = 0; i < j; i++){
				if(RealSpread != 0){
					Rand1 = Random.Range(-RealSpread,RealSpread);
					Rand2 = Random.Range(-RealSpread,RealSpread);
				}
				GameObject go = (GameObject)Instantiate(BulletPrefab, this.transform.GetChild(1).position, new Quaternion(this.transform.parent.rotation.x + Rand1, this.transform.parent.rotation.y + Rand2, this.transform.parent.rotation.z, this.transform.parent.rotation.w));
				Dir.x += Rand1;
				Dir.y += Rand2;
				go.GetComponent<BulletSpeed>().Dir = Dir * BulletSpeed;
			}
			yield return new WaitForSeconds(Delay);
		}
		if(Input.GetMouseButton(0) && GunType == Type.FullAuto){
			StartCoroutine(Firing());
		}
		else{
			IsFiring = false;
		}
	}
}
