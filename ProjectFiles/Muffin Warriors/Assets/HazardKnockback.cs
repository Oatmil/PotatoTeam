using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class HazardKnockback : MonoBehaviour {

    public Vector3 m_KnockForce;
    Environment_BottleAndJar[] m_moveObject = new Environment_BottleAndJar[40];
    CameraScript GameCamera;

    void Awake()
    {
        GameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
    }

    void Start()
    {
        for (int i = 0; i < m_moveObject.Length; i++)
        {
            GameObject[] tempObject = GameObject.FindGameObjectsWithTag("EnvironmentObject");
            m_moveObject[i] = tempObject[i].GetComponent<Environment_BottleAndJar>();
        }
    }

    void bounceObjects()
    {
        for (int i = 0; i < m_moveObject.Length; i++)
        {
            if (m_moveObject[i] != null)
                m_moveObject[i].bounce();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.root.tag == "Player")
        {
            player1Controler m_Player = col.transform.root.GetComponent<player1Controler>();
            Vector3 dir = col.transform.position - transform.position;
            int HitDir = 0;
            if (dir.x > 0)
            {
                HitDir = 1;
            }
            else if (dir.x < 0)
            {
                HitDir = -1;
            }
            bounceObjects();
            GameCamera.ScreenShake = true;
            Debug.Log("EnvironmentHit");
            m_Player.HazardKnock(m_KnockForce, HitDir);
            col.transform.root.GetComponentInChildren<Animator>().SetTrigger("Damage");
            GameObject newObject = hitsparkpool.m_instance.NewObject();
            if (newObject != null)
            {
                newObject.transform.localScale = new Vector3(1, 1, 1);
                if (col.transform.root.localScale.x > 0.1f)
                {
                    newObject.transform.eulerAngles = new Vector3(-15.6f, -52, 0);
                    newObject.transform.position = new Vector3(col.transform.position.x - 1f, col.transform.position.y + 1.2f, col.transform.position.z - 1.5f);
                }
                else
                {
                    newObject.transform.eulerAngles = new Vector3(-15.6f, 52, 0);
                    newObject.transform.position = new Vector3(col.transform.position.x + 1f, col.transform.position.y + 1.2f, col.transform.position.z - 1.5f);
                }
                newObject.SetActive(true);
            }

        }
    }

}
