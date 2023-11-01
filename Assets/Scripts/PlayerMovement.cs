using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    public Transform tank;


    [SerializeField] Camera CurrentCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        //Get the Screen positions of the object
        
        Vector2 positionOnScreen = CurrentCamera.WorldToViewportPoint(transform.position);
         Vector2 mouseOnScreen = (Vector2)CurrentCamera.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f ));

        //transform.LookAt(mouseOnScreen);
        

    }

    private void LateUpdate()
    {
        transform.position = tank.transform.position + new Vector3(0f, 0.4f, 0f);
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
