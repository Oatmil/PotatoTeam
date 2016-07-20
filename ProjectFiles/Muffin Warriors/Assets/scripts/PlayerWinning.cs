using UnityEngine;
using System.Collections;

public class PlayerWinning : MonoBehaviour {
    public int m_PlayerNum;
    public GameObject m_WinningParticleEffect;
    RoundManager m_manager;
	// Use this for initialization
	void Start () {
        m_manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<RoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(m_manager.CheckingCurrentScore(1));
        Debug.Log(m_manager.CheckingCurrentScore(2));

        if (m_PlayerNum == 1)
        {
            if (m_manager.CheckingCurrentScore(2) > m_manager.CheckingCurrentScore(1))
                m_WinningParticleEffect.SetActive(true);
            else
                m_WinningParticleEffect.SetActive(false);
        }
        if (m_PlayerNum == 2)
        {
            if (m_manager.CheckingCurrentScore(1) > m_manager.CheckingCurrentScore(2))
                m_WinningParticleEffect.SetActive(true);
            else
                m_WinningParticleEffect.SetActive(false);
        }
	}
}
