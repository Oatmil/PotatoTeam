using UnityEngine;
using System.Collections;

public class speed : MonoBehaviour {

	public GameObject m_SuckPos;
	public float m_theSpeed = 1.0f;
   

	void Update()
	{
		var m_Particles = GetComponent<ParticleEmitter> ().particles;
		for (int i = 0; i < m_Particles.Length; i++) {
			m_Particles [i].position = Vector3.Lerp (m_Particles [i].position, m_SuckPos.transform.position, Time.deltaTime*m_theSpeed);

			Vector3 m_suckVel = new Vector3 (m_Particles [i].velocity.x * -1f, m_Particles [i].velocity.y * -1f, m_Particles [i].velocity.z * -1f);
			m_Particles [i].velocity = Vector3.Lerp (m_Particles[i].velocity, m_suckVel, Time.deltaTime*m_theSpeed);
		}

		GetComponent<ParticleEmitter> ().particles = m_Particles;
	}
}
