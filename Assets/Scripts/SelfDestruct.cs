using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{   
    [SerializeField] float timeTillDestroy = 3f;
    

   void Update() {
    
    Destroy(gameObject,timeTillDestroy);

   }
}
