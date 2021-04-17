using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageNumber : MonoBehaviour
{
    public float damageSpeed; //DamageNumber takes speed
    public float damagePoints; //DamageNumber displays points

    public Text damageText;
    // public TMP_Text damageTextPro; 

    public Vector2 direction = new Vector2(1, 0);
    public float timeToChangeDirection = 1;
    public float timeToChangeDirectionCounter = 1; 
    

    // Update is called once per frame
    void Update()
    {
        timeToChangeDirectionCounter -= Time.deltaTime;
        if(timeToChangeDirectionCounter < timeToChangeDirection/2) //le aplicamos un centro de donde partir
        {
            direction *= -1; //rotate direction of the vector
            timeToChangeDirectionCounter += timeToChangeDirection; //siempre nos queda 1.5 veces + totaltime
        }
        damageText.text = "" + damagePoints; //lazy casting
        //damageTextPro.text = "" + damagePoints;

        //damage points will rise depending on speed
        this.transform.position = new Vector3(this.transform.position.x + direction.x*damageSpeed*Time.deltaTime,
                                            this.transform.position.y + damageSpeed * Time.deltaTime, this.transform.position.z);
        this.transform.localScale = this.transform.localScale*(1-Time.deltaTime/10); 
        

    }
}
