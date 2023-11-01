using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
public class PlayerSetup : MonoBehaviourPunCallbacks
{

    [SerializeField] Transform tank;
    [SerializeField] Transform cube;
    [SerializeField] Transform camera;
    [SerializeField] Transform firepoint;
    [SerializeField] Slider slider;
 

    [SerializeField] TextMeshProUGUI playernameText;
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine)
        {
            tank.GetComponent<TankMovement>().enabled = true;
            //tank.GetComponent<TakingDamage>().enabled = true;
            cube.GetComponent<PlayerMovement>().enabled = true;
            camera.gameObject.GetComponent<Camera>().enabled = true;
            firepoint.GetComponent<FireBullets>().enabled = true;
            //slider.GetComponent<Slider>().enabled = true;
        }
        else
        {
            tank.GetComponent<TankMovement>().enabled = false;
            cube.GetComponent<PlayerMovement>().enabled = false;
            camera.gameObject.GetComponent<Camera>().enabled = false;
            firepoint.GetComponent<FireBullets>().enabled = false;
            //tank.GetComponent<TakingDamage>().enabled = false;
           // slider.GetComponent<Slider>().enabled = false;
        }

        SetPlayerUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetPlayerUI()
    {
        if(playernameText != null)
        {
            playernameText.text = photonView.Owner.NickName;
        }
        
    }

}
