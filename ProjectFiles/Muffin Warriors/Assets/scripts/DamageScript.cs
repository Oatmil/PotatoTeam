using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageScript : MonoBehaviour
{
    player1Controler PlayerController;
    Text textBanner;
    BannerScript Banner;
    CameraScript GameCamera;

    void Awake()
    {
        GameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.root.tag == "Player")
        {
            player1Controler PlayerController = col.transform.root.GetComponent<player1Controler>();
            Text tempBanner = GameObject.FindGameObjectWithTag("Banner" + PlayerController.PlayerNumber.ToString()).GetComponent<Text>();
            BannerScript Banner = GameObject.FindGameObjectWithTag("Banner" + PlayerController.PlayerNumber.ToString()).GetComponent<BannerScript>();
            if (col.transform.root != transform.root && col.tag != "Ground" && !col.isTrigger) // see if you did not hit self or ground
            {
                if (!PlayerController.damage) // see if he can take damage or not
                {
                    if (PlayerController.horizontal * col.transform.root.localScale.x < -0.2f && PlayerController.up == false && PlayerController.blockCharge > 0)
                    {
                        PlayerController.block = true;
                        Banner.SetExplosionON();
                        tempBanner.text = "block";
                        transform.root.GetComponent<player1Controler>().GetBlocked = true;
                        GameCamera.ScreenSlowMo = true;
                        Debug.Log("block");
                        GameObject blockObject = blocksparkpool.m_instance1.NewObject();
                        if (blockObject != null)
                        {
                            blockObject.transform.localScale = new Vector3(1, 1, 1);
                            // blockObject.transform.rotation = Quaternion.identity;
                            if (col.transform.root.localScale.x > 0.1f)
                            {
                                blockObject.transform.eulerAngles = new Vector3(0, -52, 0);
                                blockObject.transform.position = new Vector3(col.transform.position.x + 0.5f, col.transform.position.y + 1.2f, col.transform.position.z - 0.5f);
                            }
                            else
                            {
                                blockObject.transform.eulerAngles = new Vector3(0, 52, 0);
                                blockObject.transform.position = new Vector3(col.transform.position.x - 0.5f, col.transform.position.y + 1.2f, col.transform.position.z - 0.5f);
                            }
                            blockObject.SetActive(true);
                        }
                    }
                    else
                    {
                        Banner.FadeDuration = 1.0f;
                        tempBanner.text = "hit";
                        GameCamera.ScreenShake = true;
                        Debug.Log("hit");
                        PlayerController.damage = true;
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
                        player1Controler TempRoot = transform.root.GetComponent<player1Controler>();
                        if (TempRoot.onGround == false && TempRoot.up == false)
                        {
                            PlayerController.InAirAttack = true;
                        }
                        else if (TempRoot.onGround == true && TempRoot.crouch == true)
                        {
                            PlayerController.CrouchAttack = true;
                        }
                    }
                }
            }


        }
    }

}
