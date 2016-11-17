using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlamDownSparkPool : MonoBehaviour
{
    public static SlamDownSparkPool m_instance2;

    public GameObject m_SlamObject;
    public GameObject m_DeathPE;
    public int m_SlamPoolSize;

    public List<GameObject> m_SlamPool;
    public List<GameObject> m_DeathPEPool;
    void Awake()
    {
        m_instance2 = this;
        DontDestroyOnLoad(m_instance2.gameObject);
    }
    void Start()
    {
        m_SlamPool = new List<GameObject>();
        for (int i = 0; i < m_SlamPoolSize; i++)
        {
            GameObject tempObj = Instantiate(m_SlamObject) as GameObject;
            tempObj.SetActive(false);
            m_SlamPool.Add(tempObj);

            tempObj = Instantiate(m_DeathPE) as GameObject;
            tempObj.SetActive(false);
            m_DeathPEPool.Add(tempObj);
        }
    }

    public GameObject NewObject()
    {
        for (int i = 0; i < m_SlamPoolSize; i++)
        {
            if (m_SlamPool[i].activeInHierarchy == false)
                return m_SlamPool[i];
        }
        return null;
    }

    public GameObject DeathPE()
    {
        for (int i = 0; i < m_SlamPoolSize; i++)
        {
            if (m_DeathPEPool[i].activeInHierarchy == false)
                return m_DeathPEPool[i];
        }
        return null;
    }
}

