using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExtremeTunnel : MonoBehaviour {

    public List<GameObject> L_Explosions = new List<GameObject>();
    public GameObject DeathPit;

    public float DelayStart = 10.0f;
    float TempTime;

    void Start()
    {
        StartCoroutine(StartCountDown());
    }

    IEnumerator StartCountDown()
    {
        bool ended = false;
        do
        {
            TempTime += Time.deltaTime;
            if (TempTime >= DelayStart)
                ended = true;
        } while (!ended);

        foreach(GameObject Obj in L_Explosions)
            Obj.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        DeathPit.SetActive(true);
        
    }
}
