using UnityEngine;
using System.Collections;

public class WinLoseAnimationController : MonoBehaviour {
    Animator anim;
    public bool Win;
    public bool Lose;
    public bool Reset;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Win == true)
        {
            anim.SetTrigger("Win");
            Win = false;
        }
        if (Lose == true)
        {
            anim.SetTrigger("Lose");
            Lose = false;
        }
        if (Reset == true)
        {
            anim.SetTrigger("Reset");
            Reset = false;
        }
	}
}
