using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float heightAdjusment;
    public float depthAdjustment;
    public float minimumDepth;

    public bool Begin;
    public Vector3[] m_CameraPoints;
    public int m_SetPoint;
	GameObject[] players = new GameObject[2];
	Vector3[] TarPosition = new Vector3[2];
    float Distance;
    Vector3 MidPoint;

    GameObject manager;
    GameObject UICanvas;

	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
        manager = GameObject.FindGameObjectWithTag("Manager");
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
        UICanvas.SetActive(false);
        manager.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Begin == true)
        {
            for (int i = 0; i < players.Length; i++)
            {
                TarPosition[i] = players[i].transform.position;
            }
            Distance = Vector2.Distance(TarPosition[0], TarPosition[1]);
            if (-Distance > minimumDepth)
            {
                MidPoint = new Vector3((TarPosition[0].x + TarPosition[1].x) / 2, heightAdjusment + (TarPosition[0].y + TarPosition[1].y) / 2, minimumDepth);
            }
            else
            {
                MidPoint = new Vector3((TarPosition[0].x + TarPosition[1].x) / 2, heightAdjusment + (TarPosition[0].y + TarPosition[1].y) / 2, -Distance);
            }
            transform.position = Vector3.Lerp(transform.position, MidPoint, 0.05f);
        }
	}

    public void GotoPosition()
    {
        transform.position = m_CameraPoints[m_SetPoint];
    }

    public void SetCameraPosition()
    {
        m_CameraPoints[m_SetPoint] = transform.position;
    }
}
