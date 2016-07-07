using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sliderscript : MonoBehaviour {

    public GameObject m_spotlight;
    public Slider m_spotlightSlider;

    public GameObject m_leftpointlight;
    public Slider m_leftPointlightSlider;

    public GameObject m_rightpointlight;
    public Slider m_rightPointLightSlider;

    public GameObject m_cameraspotlight;
    public Slider m_cameraPointLightSlider;

    Light spotlight;
    Light leftpointlight;
    Light rightpointlight;
    Light cameraspotlight;

    void Start()
    {
        spotlight = m_spotlight.GetComponent<Light>();
        leftpointlight = m_leftpointlight.GetComponent<Light>();
        rightpointlight = m_rightpointlight.GetComponent<Light>();
        cameraspotlight = m_cameraspotlight.GetComponent<Light>(); ;
    }

    public void SetSpotlight(float Value)
    {
        spotlight.intensity = m_spotlightSlider.value;
    }

    public void SetLeftPointLight(float Value)
    {
        leftpointlight.intensity = m_leftPointlightSlider.value;
    }

    public void SetRightPointLight(float Value)
    {
        rightpointlight.intensity = m_rightPointLightSlider.value;
    }
    
    public void SetCameraPointLight(float Value)
    {
        cameraspotlight.intensity = m_cameraPointLightSlider.value;
    }
}
