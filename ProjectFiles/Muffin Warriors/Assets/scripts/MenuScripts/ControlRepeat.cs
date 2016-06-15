using UnityEngine;
using System.Collections;

public class ControlRepeat : MonoBehaviour {
	public float speed;
	RectTransform canvasTransform;
	// Use this for initialization
	void Start () {
		canvasTransform = GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update () {
		canvasTransform.transform.localPosition += new Vector3(0.0f,speed,0.0f);
		if(canvasTransform.transform.localPosition.y > 280.0f)
		{
			canvasTransform.transform.localPosition = new Vector3(canvasTransform.transform.localPosition.x, -266.0f, canvasTransform.localPosition.z);
		}
	}
}
