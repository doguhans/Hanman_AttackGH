using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{  

    [SerializeField] int hitPoint = 3;
   [SerializeField] int amountToIncrease = 15;
   [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;

   [SerializeField] GameObject parentGameObject;

   ScoreBoard scoreBoard;
    Rigidbody rBod;
   
   void Start()
    {
        
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidBody();
        parentGameObject = GameObject.FindWithTag("SAR");
    }

    private void AddRigidBody()
    {
        rBod = gameObject.AddComponent<Rigidbody>();

        rBod.useGravity = false;
        rBod.isKinematic = true;
    }

    void OnParticleCollision(GameObject other)
    {
        // Debug.Log($" {this.name}+ has been shot by + {other.gameObject.name}");
        if(hitPoint == 0)
        {
            EnemyGotKilled();
        }
        else
        {
            EnemyHit();
            hitPoint-=1;
           // Debug.Log($"Enemy Health = {hitPoint}");
        }

    }

    private void EnemyGotKilled()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position , Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    private void EnemyHit()
    {   
        GameObject hFX = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hFX.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(amountToIncrease);
    }
}
