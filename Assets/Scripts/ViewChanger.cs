using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChanger : MonoBehaviour
{
    
    [SerializeField] GameObject[] cams; 
    int currentIndex = 0;

    // Update is called once per frame
    void Update()
    {
        ChangeView();
    }
    void ChangeView()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {   
            cams[currentIndex].SetActive(false);
            currentIndex++;
            
            if(currentIndex < cams.Length)
            {
                
                
                cams[currentIndex].SetActive(true);
            }
            else
            {
                currentIndex = 0;
                if(cams.Length > 0)
                {cams[currentIndex].SetActive(true);
                }
            }
        }
    }
}
