using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetitiveBackground : MonoBehaviour
{
    public GameObject background;
    public float startDelay, backgroundInterval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBackground", startDelay, backgroundInterval);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBackground()
    {
        Instantiate(background, transform.position, background.transform.rotation);
    }
}
