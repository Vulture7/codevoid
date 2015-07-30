using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(WorldCreator))]
public class WorldCreatorEditor : Editor {
	public float AllValues;
	public override void OnInspectorGUI(){
		GUILayout.Label("Spawned: " + WorldCreator.Instance.SpawnedAmount + "/" + WorldCreator.Instance.MaxAmount);
		WorldCreator.Instance.Seed = EditorGUI.IntField(new Rect(15, 175, 315, 16), "Seed: ", WorldCreator.Instance.Seed);
		GUILayout.Space(120f);
		WorldCreator.Instance.MaxAmount = EditorGUI.IntSlider(new Rect(15,191,315,16), "Max Spawns: ",WorldCreator.Instance.MaxAmount, 4, 1500);
		AllValues = 0;
		for(int i = 0; i < WorldCreator.Instance.Chances.Count; i++){
			AllValues += WorldCreator.Instance.Chances[i].Value;
		}
		for(int i = 0; i < WorldCreator.Instance.Chances.Count; i++){
			float orig = WorldCreator.Instance.Chances[i].Value / AllValues;
			int temp = (int)(orig * 10000f);
			WorldCreator.Instance.Chances[i].Value = EditorGUI.IntSlider(new Rect(15,207 + (16 * i),315,16),WorldCreator.Instance.Chances[i].Segment.name + ": " + temp / 100f + "%",WorldCreator.Instance.Chances[i].Value, 1, 10);
		}
	}
	void OnApplicationQuit(){

	}
}
