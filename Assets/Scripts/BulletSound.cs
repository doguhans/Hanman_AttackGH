using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSound : MonoBehaviour
{   [SerializeField] AudioClip aC;
    AudioSource aS;
  
    void Start() {
        aS = GetComponent<AudioSource>();
  
    }
   
    void Update()
    { 
        if(Input.GetKey(KeyCode.Space)  || Input.GetButton("Fire1") )
        {
         //   GetComponent<AudioSource>().enabled = true;
           if(!aS.isPlaying)
            aS.PlayOneShot(aC);
            
        }
        else{aS.Stop();}
    }
}
