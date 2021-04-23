using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[RequireComponent(typeof(BoxCollider2D))]
public class CameraLimits : MonoBehaviour
{





    // Start is called before the first frame update
    void Start()
    {

        FindObjectOfType<CameraFollow>().ChangeLimits(this.GetComponent<BoxCollider2D>());
        //find camera - when collider runs it will camera collide limits has changed between scenes
        //this.limits are now you limits, camera. 
    }

    // Update is called once per frame
    void Update()
    {




    }
}
