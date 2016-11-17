using UnityEngine;
using System.Collections;

public class CreditScript : MonoBehaviour {
    public GameObject[] m_credit;
    public int m_showname = 0;
    public float m_slightShow;
    float m_time;

    // for analog movement
    public float m_DelayAnalogTime;
    float m_Analogtimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        m_time += Time.deltaTime;
        if (m_time > m_slightShow)
        {
            m_time = 0;
            if(m_showname<m_credit.Length)
                m_showname++;
            if (m_showname == m_credit.Length)
            {
                m_showname = 0;
            }
        }

        if (Input.GetButtonDown("Attack11") || Input.GetButtonDown("Attack12"))
        {
            m_time = 0;
            if(m_showname < m_credit.Length-1)
                m_showname++;
            else if (m_showname == m_credit.Length -1 )
            {
                m_showname = 0;
            }
        }
        if (Input.GetButtonDown("Block1") || Input.GetButtonDown("Block2"))
        {
            m_time = 0;
            if(m_showname > 0)
                m_showname--;
            else if (m_showname == 0)
            {
                m_showname = m_credit.Length-1;
            }
        }

        if (Input.GetAxis("Horizontal1") >= 1.0f || Input.GetAxis("Horizontal2") >= 1.0f)
        {
            m_Analogtimer += Time.deltaTime;
            if (m_Analogtimer > m_DelayAnalogTime)
            {
                m_time = 0;
                if (m_showname < m_credit.Length - 1)
                    m_showname++;
                else if (m_showname == m_credit.Length - 1)
                {
                    m_showname = 0;
                }
                m_Analogtimer = 0;
            }
        }

        if (Input.GetAxis("Horizontal1") <= -1.0f || Input.GetAxis("Horizontal2") <= -1.0f)
        {
            m_Analogtimer += Time.deltaTime;
            if (m_Analogtimer > m_DelayAnalogTime)
            {
                m_time = 0;
                if (m_showname > 0)
                    m_showname--;
                else if (m_showname == 0)
                {
                    m_showname = m_credit.Length - 1;
                }
                m_Analogtimer = 0;
            }
        }

        for (int i = 0; i < m_credit.Length; i++)
        {
            if (m_showname == i)
            {
                m_credit[i].SetActive(true);
            }
            else
            {
                m_credit[i].SetActive(false);
            }
        }
	}
}
