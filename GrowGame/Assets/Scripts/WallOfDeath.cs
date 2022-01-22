using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    public Generation generation;
    public Transform wallTransform;
    public Transform playerTransform;
    public bool isWalled = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wallTransform.position = new Vector3(generation.offset - 100, 0f, 0f);
        if(wallTransform.position.x > playerTransform.position.x)
        {
            isWalled = true;
        }
    }
}
