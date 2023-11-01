using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRoation : MonoBehaviour
{
   public Transform player;
    // Start is called before the first frame update
    void Start()
    {
       
    }
   

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(4.53f, 4.28f, -0.3f);
    }
}
