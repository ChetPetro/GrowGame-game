using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public float time = 0f;
    public float objectInterval = 3f;
    private float offset = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        offset += (8 - 2 * Mathf.Pow(0.99f, time) + 1f) * Time.deltaTime;

        if (objectInterval < time)
        {
            objectInterval += 2 * Mathf.Pow(0.99f, time) + 1f;
            if(Random.Range(1, 6) > 1)
            {
                newCube();
            }
            else
            {
                newCube();
            }

        }

       
    }

    void newCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.layer = 6;
        cube.transform.position = new Vector3(Random.Range(0,10) + offset, 0f, Random.Range(0, 25));
        cube.transform.localScale = new Vector3(Random.Range(7, 13), Random.Range(3, 15), Random.Range(7, 13));
    }

    void newWall()
    {
        float x_pos = Random.Range(0, 5) + offset;
        float y_pos = Random.Range(4,7);
        float z_pos = Random.Range(0, 10);

        GameObject cubeL = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeR = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeU = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeD = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cubeL.layer = 6;
        cubeR.layer = 6;
        cubeU.layer = 6;
        cubeD.layer = 6;

        cubeL.transform.position = new Vector3(x_pos, 0f, z_pos - Random.Range(9,11));
        cubeL.transform.localScale = new Vector3(1f, 30f, 15f);
        cubeR.transform.position = new Vector3(x_pos, 0f, z_pos + Random.Range(9, 11));
        cubeR.transform.localScale = new Vector3(1f, 30f, 15f);

        cubeU.transform.position = new Vector3(x_pos, y_pos + 7, z_pos);
        cubeU.transform.localScale = new Vector3(1f, 10f, 10f);
        cubeD.transform.position = new Vector3(x_pos, y_pos - 7, z_pos);
        cubeD.transform.localScale = new Vector3(1f, 10f, 10f);
    }
}
