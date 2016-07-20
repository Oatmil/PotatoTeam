using UnityEngine;
using System.Collections;

public class EnvironmentParticle : MonoBehaviour {
    	
    public GameObject m_Particle0;
    public GameObject m_Particle1;
    public GameObject m_Particle2;
    public GameObject m_Particle3;
    public GameObject m_Particle4;



    public void SetEnvironment(int Selection)
    {
        Debug.Log(Selection + " Particle Avtivated");
        if (Selection == 0)
        {
            m_Particle0.SetActive(true);
            m_Particle1.SetActive(false);
            m_Particle2.SetActive(false);
            m_Particle3.SetActive(false);
            m_Particle4.SetActive(false);
        }
        if (Selection == 1)
        {
            m_Particle0.SetActive(false);
            m_Particle1.SetActive(true);
            m_Particle2.SetActive(false);
            m_Particle3.SetActive(false);
            m_Particle4.SetActive(false);
        }
        if (Selection == 2)
        {
            m_Particle0.SetActive(false);
            m_Particle1.SetActive(false);
            m_Particle2.SetActive(true);
            m_Particle3.SetActive(false);
            m_Particle4.SetActive(false);
        }
        if (Selection == 3)
        {
            m_Particle0.SetActive(false);
            m_Particle1.SetActive(false);
            m_Particle2.SetActive(false);
            m_Particle3.SetActive(true);
            m_Particle4.SetActive(false);
        }
        if (Selection == 4)
        {
            m_Particle0.SetActive(false);
            m_Particle1.SetActive(false);
            m_Particle2.SetActive(false);
            m_Particle3.SetActive(false);
            m_Particle4.SetActive(true);
        }

    }
}
