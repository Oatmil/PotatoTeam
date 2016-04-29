using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float heightAdjusment;
    public float depthAdjustment;
    public float minimumDepth;

	GameObject[] players = new GameObject[2];
	Vector3[] TarPosition = new Vector3[2];
    float Distance;
    Vector3 MidPoint;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < players.Length; i++) {
			TarPosition[i] = players [i].transform.position;
		}
        Distance = Vector2.Distance(TarPosition[0], TarPosition[1]);
        if (-Distance > minimumDepth)
        {
            MidPoint = new Vector3((TarPosition[0].x + TarPosition[1].x) / 2, heightAdjusment + (TarPosition[0].y + TarPosition[1].y)/2, minimumDepth);
        }
        else
        {
            MidPoint = new Vector3((TarPosition[0].x + TarPosition[1].x) / 2, heightAdjusment + (TarPosition[0].y + TarPosition[1].y)/2, -Distance);
        }
        transform.position = Vector3.Lerp(transform.position, MidPoint, 0.05f);
	}
}
