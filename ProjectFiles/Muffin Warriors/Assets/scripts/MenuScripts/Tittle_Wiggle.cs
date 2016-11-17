using UnityEngine;
using System.Collections;

public class Tittle_Wiggle : MonoBehaviour {

    public float m_RotationScale;
    Vector3 OriginalRotation;
    Vector3 m_PerlinNoiseRot;

	// Use this for initialization
	void Start () {
        OriginalRotation = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        m_PerlinNoiseRot.z = (Mathf.PerlinNoise(Time.time, Time.time)-0.5f )* m_RotationScale;
        transform.localEulerAngles = OriginalRotation + m_PerlinNoiseRot;
	}
}
