using UnityEngine;
using System.Collections;

public class DisablePE : MonoBehaviour {
    ParticleSystem ps;
	// Use this for initialization
	void Start () {
	    ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                this.gameObject.SetActive(false);
            }

        }
	}
}
