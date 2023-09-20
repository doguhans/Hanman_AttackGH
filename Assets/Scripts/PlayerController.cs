using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
  [Header("General Setup Settings")]
  [Tooltip("How fast ship moves up,down,left,right based upon player input")]
  [SerializeField] float movementSpeed = 10f;
  [Tooltip("How fast ship moves horizontally")]
  [SerializeField]float xRange = 5f;
  [Tooltip("How fast ship moves vertically")]
  [SerializeField]float yRange = 3.5f;
  [Header("Laser gun array")]
  [Tooltip("Add all player lasers here")]
  [SerializeField] GameObject[] lasers;
  
  [Header("Screen position based tuning")]
  [SerializeField]float positionPitchFactor = -2f;
  [SerializeField]float positionYawFactor = -5f;
  [SerializeField]float positionRollFactor = 50f;  

  [Header("Player input based tuning")]
  [SerializeField]float controlPitchFactor = -10f;
  [SerializeField]float controlYawFactor = -2f;  
  [Header("Player horizontal and vertical throw values")]
  [SerializeField]float horizontalFlow;
  [SerializeField] float verticalFlow;

 
  // Update is called once per frame
  void Update()
  {
    PlayerTranslation();
    PlayerRotation();
    ProcessFire();
  }

  void PlayerTranslation()
  {
     horizontalFlow = Input.GetAxis("Horizontal");
     verticalFlow = Input.GetAxis("Vertical");

    float xOffset = horizontalFlow * Time.deltaTime * movementSpeed;
    float yOffset = verticalFlow * Time.deltaTime * movementSpeed;

    float newXPos = transform.localPosition.x + xOffset;    
    float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

    float newYPos = transform.localPosition.y - yOffset;
    float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange+2);

    transform.localPosition = new Vector3(
    clampedXPos,
     clampedYPos,
     transform.localPosition.z);

  }

  void PlayerRotation()
  {
    float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
    float pitchDueToVerticalFlowControl =  verticalFlow * controlPitchFactor;

    float pitch = pitchDueToPosition  - pitchDueToVerticalFlowControl,
     yaw = transform.localPosition.x * -positionYawFactor + horizontalFlow * controlYawFactor,
     roll = horizontalFlow * -positionRollFactor;
    // pitch, yaw, roll
    transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
  }

  void ProcessFire()
  {
    
    if(Input.GetButton("Fire1")||Input.GetKey(KeyCode.Space))
    {
      ActivateLasers(true);
    }
    else
    {
      ActivateLasers(false);
    }
  
  
  }

  void ActivateLasers(bool isActive){

    foreach(GameObject laser in lasers){

      var emissionModule = laser.GetComponent<ParticleSystem>().emission;
      emissionModule.enabled = isActive;
    }

  }
   

}

