using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontRotateText : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }


    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0f, 1.2f, 0f);
    }
}
