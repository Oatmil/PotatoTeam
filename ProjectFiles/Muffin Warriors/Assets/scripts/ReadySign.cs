using UnityEngine;
using System.Collections;

public class ReadySign : MonoBehaviour {

    public GameObject m_platform;
    Platform_Selection_Scene1 Platform;
    public float WaitTime;
    Animator anim;
    float timer;
	// Use this for initialization
	void Start () {
        Platform = m_platform.GetComponent<Platform_Selection_Scene1>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Platform.PlayerReady1 == true && Platform.PlayerReady2 == true)
        {
            timer += Time.deltaTime;
            anim.SetBool("SignBoardUp", true);
            if(timer >= WaitTime)
              LoadLevel_Scene1();
        }
        else
        {
            timer = 0;
            anim.SetBool("SignBoardUp", false);
        }
	}
    void LoadLevel_Scene1()
    {
        Application.LoadLevel("1");
    }
}
