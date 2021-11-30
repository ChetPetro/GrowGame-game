using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    private float time = 0f;
    private float interval = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if(time > interval)
        {
            newCube();
            interval += 3;
        }
    }

    void newCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(Random.Range(0,10), 0f, Random.Range(0, 10));
    }
}
