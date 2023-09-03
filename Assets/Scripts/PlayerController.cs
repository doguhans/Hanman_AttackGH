using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    float xRange =7f;
    float yRange =5f;
    // Update is called once per frame
    void Update()
    {
        PlayerFlow();
    }

    void PlayerFlow()
    {
        float horizontalFlow = Input.GetAxis("Horizontal");
        float verticalFlow = Input.GetAxis("Vertical");
        float xOffset = horizontalFlow * Time.deltaTime * movementSpeed;
        float yOffset = verticalFlow * Time.deltaTime * movementSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);
       
        transform.localPosition = new Vector3
        (clampedXPos,
         clampedYPos,
         transform.localPosition.z);
      
    }
}

 //float newXPosN = transform.localPosition.x - xOffset;
        //float newYPosN = transform.localPosition.y - yOffset;

      /*  
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
        transform.localPosition = new Vector3
        (newXPosP,
         transform.localPosition.y,
         transform.localPosition.z);
        }
        else if (Input.GetKey(KeyCode.A))
        {
        transform.localPosition = new Vector3
        (newXPosN,
         transform.localPosition.y,
         transform.localPosition.z);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
             transform.localPosition = new Vector3
        (transform.localPosition.x,
         newYPosP,
         transform.localPosition.z);
        }
      /*  else if (Input.GetKey(KeyCode.S))
        {
        transform.localPosition = new Vector3
        (transform.localPosition.x,
         newYPosN,
         transform.localPosition.z);
        }*/
      //  else{ }