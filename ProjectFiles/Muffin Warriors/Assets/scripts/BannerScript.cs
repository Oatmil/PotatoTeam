using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BannerScript : MonoBehaviour {

    public float FadeDuration;
    public GameObject m_BannerExplosion;
    BannerExplosionScript m_bannerExpo;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        m_bannerExpo = m_BannerExplosion.GetComponent<BannerExplosionScript>();
    }

    // Update is called once per frame
    void Update () {
        FadeOut(Time.deltaTime);
        
	}

    void FadeOut(float time)
    {
        
        
        if(FadeDuration <0)
        {
            text.CrossFadeAlpha(0.0f, 0.2f, false);
        }
        else
        {
            FadeDuration -= time;
            text.CrossFadeAlpha(1.0f, 0.1f, false);
            m_BannerExplosion.SetActive(true);
        }
    }
    public void SetExplosionON()
    {
        FadeDuration = 1.0f;
        
    }
}
