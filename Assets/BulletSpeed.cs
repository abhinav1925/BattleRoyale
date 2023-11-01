using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletSpeed : MonoBehaviour
{

    [SerializeField] float bspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bspeed);
       
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player") && !other.gameObject.GetComponent<PhotonView>().IsMine)
        {
            other.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.AllBufferedViaServer, 10f);
        }

        Destroy(this.gameObject);
    }

}
