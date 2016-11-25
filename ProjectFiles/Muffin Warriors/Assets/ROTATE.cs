using UnityEngine;
using System.Collections;

public class ROTATE : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles += new Vector3(0.0f, 50 * Time.deltaTime, 0);
	}
}
