using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
  private void Update() {
    ReloadOnKeyDown();
  }
   /* void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag)
        {
            case "Enemy":
            Debug.Log("You have collided with an enemy ship!");
            ReloadScene();
            break;
            case "Bridge":
            Debug.Log("You have bumped into a bridge g.!!");
            ReloadScene();
            break;
            default:
            Debug.Log("Nothing happened.");
            break;
        }
    }*/

    void ReloadOnKeyDown()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }
    void OnTriggerEnter(Collider other) {
        switch(other.gameObject.tag)
        {
            case "Enemy":
            Debug.Log("You have collided with an enemy ship!");
            Invoke("ReloadScene", 2f);
            break;
            case "Bridge":
            Debug.Log("You have bumped into a bridge g.!!");
            Invoke("ReloadScene", 2f);
            break;
            default:
            Debug.Log("Nothing happened.");
            break;
        }
    }

    void ReloadScene()
    {   
        
        gameObject.GetComponent<PlayerController>().enabled = false;
        int initialScene =SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"{initialScene} numbered scene reloading...");
        SceneManager.LoadScene(initialScene);
    }   

}
