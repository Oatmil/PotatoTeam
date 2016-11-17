using UnityEngine;
using System.Collections;
//using UnityEditor;

public class ParticleSystemAutodisable : MonoBehaviour {

    public GameObject m_SuckPos;
	public float m_theSpeed = 1.0f;

    ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    void FixedUpdate()
    {
        
        if (ps)
        {
            if (!ps.IsAlive())
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
               
            }
        }

        var m_emitted = new ParticleSystem.Particle[5000];
        ps.GetParticles(m_emitted);

        for (int i = 0; i < m_emitted.Length; i++) {
			m_emitted [i].position = Vector3.Lerp (m_emitted [i].position, m_SuckPos.transform.position, Time.deltaTime * m_theSpeed);
            
            Vector3 m_suckVel = new Vector3(m_emitted[i].velocity.x * -1f, m_emitted[i].velocity.y * -1f, m_emitted[i].velocity.z * -1f);
            m_emitted[i].velocity = Vector3.Lerp(m_emitted[i].velocity, m_suckVel, Time.deltaTime * m_theSpeed * 2);
		}

        ps.SetParticles(m_emitted, m_emitted.Length);
    }
}
