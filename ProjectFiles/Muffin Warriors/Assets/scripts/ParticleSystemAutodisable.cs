using UnityEngine;
using System.Collections;

public class ParticleSystemAutodisable : MonoBehaviour {

    ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
