using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] float movementSpeed = 10f;
  float xRange = 5f;
  float yRange = 3.5f;
  float positionPitchFactor = -2f;
  float controlPitchFactor = -10f;

  float positionYawFactor = -5f ,controlYawFactor = -2f;
  float positionRollFactor = 50f;
  float horizontalFlow, verticalFlow;
  // Update is called once per frame
  void Update()
  {
    PlayerTranslation();
    PlayerRotation();
  }

  void PlayerTranslation()
  {
     horizontalFlow = Input.GetAxis("Horizontal");
     verticalFlow = Input.GetAxis("Vertical");

    float xOffset = horizontalFlow * Time.deltaTime * movementSpeed;
    float yOffset = verticalFlow * Time.deltaTime * movementSpeed;

    float newXPos = transform.localPosition.x + xOffset;    
    float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

    float newYPos = transform.localPosition.y + yOffset;
    float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

    transform.localPosition = new Vector3(
    clampedXPos,
     clampedYPos,
     transform.localPosition.z);

  }

  void PlayerRotation()
  {
    float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
    float pitchDueToVerticalFlowControl =  verticalFlow * controlPitchFactor;

    float pitch = pitchDueToPosition  + pitchDueToVerticalFlowControl,
     yaw = transform.localPosition.x * -positionYawFactor + horizontalFlow * controlYawFactor,
     roll = horizontalFlow * -positionRollFactor;
    // pitch, yaw, roll
    transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
  }

}

