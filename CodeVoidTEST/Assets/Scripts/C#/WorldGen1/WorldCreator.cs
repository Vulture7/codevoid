using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCreator : Singleton<WorldCreator> {
	protected WorldCreator(){}
	public int Seed;

	public List<Chance> Chances = new List<Chance>();
	public GameObject HallwayEnd;
	GameObject MapSegments;
	public List<GameObject> Segments;
	public List<Vector3> SegmentPos;
	public List<int> Angles;
	public int SpawnedAmount;
	public int MaxAmount;
	int Count;
	bool done = false;
	void Awake(){
		if(Seed == 0){
			Seed = System.Environment.TickCount;
		}
		Random.seed = Seed;
		for(int i = 0; i < Chances.Count; i++){
			for(int j = 0; j < Chances[i].Value; j++){
				Chances[i].Name = Chances[i].Segment.name;
				Segments.Add(Chances[i].Segment);
			}
		}
		MapSegments = GameObject.Find("MapSegments");
	}
	public GameObject SpawnSegment(Vector3 pos){
		if(SpawnedAmount <= MaxAmount){
			GameObject go = (GameObject)Instantiate(Segments[Random.Range(0,Segments.Count)], pos, Quaternion.AngleAxis(Random.Range(0,3) * 90f, Vector3.up));
			go.transform.SetParent(MapSegments.transform);
			SpawnedAmount++;
			SegmentPos.Add(go.transform.position);
			return go;
		}
		else{
			return SpawnHallwayEnd(pos);
		}
	}
	public GameObject SpawnHallwayEnd(Vector3 pos){
		GameObject end = (GameObject)Instantiate(HallwayEnd, pos, Quaternion.identity);
		end.transform.SetParent(MapSegments.transform);
		return end;
	}
	void LateUpdate(){
		if(SpawnedAmount >= MaxAmount && !done){
			for(int i = 0; i < SegmentPos.Count; i++){
				for(int j = i+1; j < SegmentPos.Count; j++){
					if(SegmentPos[i] == SegmentPos[j]){
						Debug.LogError("INTERSECTION");
					}
				}
			}
			Debug.Log("Done");
			done = true;
			GameObject.Find("MapSegments").GetComponent<AstarPath>().Scan();
		}
		if(GameObject.FindGameObjectWithTag("Player").transform.position.y < -5){
			GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0,1,0);
		}
	}
}
[ExecuteInEditMode]
[System.Serializable]
public class Chance{
	[HideInInspector]
	public string Name;
	public GameObject Segment;
	[Range(1,10)]
	public int Value;
}
