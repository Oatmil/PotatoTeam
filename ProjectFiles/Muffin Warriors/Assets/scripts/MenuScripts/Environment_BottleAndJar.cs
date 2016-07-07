using UnityEngine;
using System.Collections;

public class Environment_BottleAndJar : MonoBehaviour {

    public float m_bounceScale;
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void bounce()
    {
        rigid.AddForce(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f,1.0f), Random.Range(-1.0f, 1.0f)) * m_bounceScale);
    }
}
