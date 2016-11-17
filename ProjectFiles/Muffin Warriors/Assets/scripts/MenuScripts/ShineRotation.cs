using UnityEngine;
using System.Collections;

public class ShineRotation : MonoBehaviour {

    public float m_RotationSpeed;
    public float m_size;
    Vector3 m_OriginalScale;
	// Use this for initialization
	void Start () {
        m_OriginalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.localEulerAngles += new Vector3(0, 0, m_RotationSpeed);
        transform.localScale = m_OriginalScale * (Mathf.PerlinNoise(Time.time, 1.0f) + m_size);
	}
}
