using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FireBullets : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform FirePoint;
    public float fireRate = 0.1f;
    float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireTimer<fireRate)
        {
            fireTimer += Time.deltaTime;
        }

       if(Input.GetButton("Fire1") && fireTimer>fireRate)
        {
            fireTimer = 0.0f;

            PhotonNetwork.Instantiate(bullet.name, FirePoint.position, FirePoint.rotation);
        }
    }

}
