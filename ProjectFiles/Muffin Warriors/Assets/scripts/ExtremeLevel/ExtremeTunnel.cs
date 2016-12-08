using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExtremeTunnel : MonoBehaviour {

    public static ExtremeTunnel m_instance;
    public int m_SizeOfPool;
    public List<GameObject> m_PlatformPool;
    public GameObject m_PlatformTunnel;
    public float m_SpawnIntervals;

    public GameObject Go_Explosions;
    public GameObject DeathPit;

    public float DelayStart = 10.0f;
    float TempTime;
    [SerializeField]
    float SpawnPlatformTempTime;

    

    void Awake()
    {
        m_instance = this;
        DontDestroyOnLoad(m_instance.gameObject);
    }

    void Start()
    {
        m_PlatformPool = new List<GameObject>();
        for (int i = 0; i < m_SizeOfPool; i++)
        {
            GameObject Obj = Instantiate(m_PlatformTunnel) as GameObject;
            Obj.SetActive(false);
            m_PlatformPool.Add(Obj);
        }
    }

    void Update()
    {
        if (SpawnPlatformTempTime > m_SpawnIntervals)
        {
            GameObject Obj = SpawnPlatform();
            if (Obj != null)
            {
                Obj.transform.position = new Vector3(Random.Range(-50, 60), -194f, -5.32f);
                Obj.GetComponent<ExtremePlatform>().randomMulti = Random.Range(0.5f, 2.0f);
                Obj.SetActive(true);
                SpawnPlatformTempTime = 0;
            }
        }
        else
        {
            SpawnPlatformTempTime += Time.deltaTime;
        }
    }

    public IEnumerator StartCountDown()
    {
        bool ended = false;
        do
        {
            TempTime += Time.deltaTime;
            if (TempTime >= DelayStart)
                ended = true;
        } while (!ended);
        Debug.Log("RUNNING");
        SpawnExplosion();
        yield return new WaitForSeconds(0.7f);
        DeathPit.SetActive(true);
        yield return null;
    }

    private void SpawnExplosion()
    {
        Detonator dTemp = (Detonator)Go_Explosions.GetComponent("Detonator");
        GameObject exp = (GameObject)Instantiate(Go_Explosions, new Vector3(0, 0, 0), Quaternion.identity);
        dTemp = (Detonator)exp.GetComponent("Detonator");
        dTemp.detail = 1.0f;
        Debug.Log("Spawned EXPLOSION");
        Destroy(exp, 10.0f);
    }

    public GameObject SpawnPlatform()
    {
        for (int i = 0; i < m_SizeOfPool; i++)
        {
            if (m_PlatformPool[i].activeInHierarchy == false)
            {
                return m_PlatformPool[i];
            }
        }
        return null;
    }

    
}
