using UnityEngine;
using System.Collections;

public class ExtremePlatform : MonoBehaviour {
    public Vector3 m_Movement;
    public float randomMulti;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += m_Movement * randomMulti * Time.deltaTime;

        if (transform.position.y > -9)
        {
            transform.gameObject.SetActive(false);
        }
	}
}
