using UnityEngine;
using System.Collections;

public class KillDeathParticle : MonoBehaviour {

    public float deathTimer;
    float endTime;

	// Use this for initialization
	void Start () {
        endTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (endTime >= deathTimer)
        {
            Destroy(this.gameObject);
        }
        endTime += Time.deltaTime;

	}
}
