using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float heightAdjusment;
    public float depthAdjustment;

	GameObject[] players = new GameObject[2];
	Vector3 TarPosition;
    float Distance;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");

		for (int i = 0; i < players.Length; i++) {
			TarPosition += players [i].transform.position;
		}
		transform.position = TarPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < players.Length; i++) {
			TarPosition += players [i].transform.position;
		}
        Distance = Vector2.Distance(players[0].transform.position, players[1].transform.position);
		transform.position = Vector3.Lerp (transform.position,TarPosition / players.Length,0.1f);
        TarPosition = new Vector3(0.0f, 2.8f + heightAdjusment, depthAdjustment - Distance * 1.5f);
	}
}
