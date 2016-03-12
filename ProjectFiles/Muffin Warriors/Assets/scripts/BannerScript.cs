using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BannerScript : MonoBehaviour {

    public float FadeDuration;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        FadeOut(Time.deltaTime);
        
	}

    void FadeOut(float time)
    {
        
        FadeDuration -= time;
        if(FadeDuration <0)
        {
            text.CrossFadeAlpha(0.0f, 0.2f, false);
        }
        else
        {
            text.CrossFadeAlpha(1.0f, 0.1f, false);
        }
    }
}
