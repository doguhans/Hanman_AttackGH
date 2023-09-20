using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem blowUpParticles;
    [SerializeField] GameObject tailToDestroy;
    
    void Update()
    {
        ReloadOnKeyDown();
    }


    void ReloadOnKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }
    void OnTriggerEnter(Collider other)
    {

        StartCrashSequence(other);

    }

    void StartCrashSequence(Collider other)
    {        
        switch (other.gameObject.tag)
        {
            case "Enemy":
               // Debug.Log("You have collided with an enemy ship!");
               BlowUpSequence();
                Invoke("ReloadScene", 2f);
                break;
            case "Bridge":
               // Debug.Log("You have bumped into a bridge g.!!");
               BlowUpSequence();
                Invoke("ReloadScene", 2f);
                break;
            default:
           
               // Debug.Log("Nothing happened.");
                  blowUpParticles.Play();
               // Invoke("ReloadScene", 2f);
                break;
        }
    }
    void BlowUpSequence()
    {   GetComponent<PlayerController>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        tailToDestroy.GetComponent<MeshRenderer>().enabled = false;
        blowUpParticles.Play();
       
    }
    void ReloadScene()
    {


        int initialScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"{initialScene} numbered scene reloading...");
        SceneManager.LoadScene(initialScene);
    }

}
