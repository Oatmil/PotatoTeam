using UnityEngine;
using System.Collections;

public class Environment_BottleAndJar : MonoBehaviour {

    public float m_bounceScale;
    Rigidbody rigid;
    Vector3 DefaultPos;
    Vector3 DefaultRot;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        DefaultPos = transform.position;
        DefaultRot = transform.eulerAngles;
	}
	

    public void bounce()
    {
        rigid.AddForce(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f,1.0f), Random.Range(-1.0f, 1.0f)) * m_bounceScale);
    }

    public void reSetPos()
    {
        transform.position = DefaultPos;
        transform.eulerAngles = DefaultRot;
    }
}
