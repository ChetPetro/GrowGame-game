using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    // Initilize variables
    private float time = 0f;
    private float objectInterval = 3f;
    public float offset = 0f;
    public PlayerMovement playerMovement;
    private GameObject cube;
    public WallOfDeath wallOfDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Reset the game when die
        if (playerMovement.badGrouded || wallOfDeath.isWalled)
        {
            playerMovement.badGrouded = true;
            time = 0f;
            offset = 0f;
            objectInterval = 3f;
            cube = GameObject.Find("generatedCube");
            Destroy(cube);
            wallOfDeath.isWalled = false;
            wallOfDeath.wallTransform.position = new Vector3(-100, 0f, 0f);
        }

        if (playerMovement.started)
        { 
            // Update the time every frame
            time += Time.deltaTime;

            // Change the x offset based on the decompisition function every frame
            offset += 20 * (1.8f - 1.5f * Mathf.Pow(0.99f, time) + 0.3f) * Time.deltaTime;

            // Spawn a new object at the correct time
            if (objectInterval < time)
            {
                // Add the next time a new object should be spawn based on a decompisition function {1.5 >= objectsInterval >= 0.3}
                objectInterval += 1.5f * Mathf.Pow(0.99f, time) + 0.3f;

                // Spawn a new cube 80% of the time and a wall 20% of the time
                if (Random.Range(1, 6) > 1)
                {
                    newCube();
                }
                else
                {
                    newWall();

                }

            }
        }
    }
    void newCube()
    {
        // Generates a new cube with random attributes  

        // Create new cube and set its layer and name
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.layer = 6;
        cube.name = "generatedCube";

        // Change the position and scale of the cube
        cube.transform.position = new Vector3(Random.Range(0,10) + offset, 0f, Random.Range(0, 25));
        cube.transform.localScale = new Vector3(Random.Range(7, 13), Random.Range(3, 15), Random.Range(7, 13));

        // Destroys the cube in 10 seconds
        Destroy(cube, 10);
    }

    void newWall()
    {
        // Generates a new wall with random attributes  

        // Sets important variabls to random values
        float x_pos = Random.Range(0, 50) / 10 + offset;
        float y_pos = Random.Range(40,70) / 10;
        float z_pos = Random.Range(0, 100) / 10;
        float cubeUD_offset_y = Random.Range(242,248) / 10; 
        float cubeLR_offset_z = Random.Range(540, 550) / 10;
   
        // Creates 5 new cube objects and changes their layer and name
        GameObject cubeL = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeR = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeU = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeD = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cubeM = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeL.layer = 6;
        cubeR.layer = 6;
        cubeU.layer = 6;
        cubeD.layer = 6;
        cubeM.layer = 6;
        cubeL.name = "generatedCube";
        cubeR.name = "generatedCube";
        cubeU.name = "generatedCube";
        cubeD.name = "generatedCube";
        cubeM.name = "generatedCube";

        // Sets the position and scale of the left and right cube
        cubeL.transform.position = new Vector3(x_pos, 0f, z_pos - cubeLR_offset_z);
        cubeL.transform.localScale = new Vector3(1f, 100f, 100f);
        cubeR.transform.position = new Vector3(x_pos, 0f, z_pos + cubeLR_offset_z);
        cubeR.transform.localScale = new Vector3(1f, 100f, 110f);

        // Sets the position and scale of the top and bottom cube
        cubeU.transform.position = new Vector3(x_pos, y_pos + cubeUD_offset_y , z_pos - 2.5f);
        cubeU.transform.localScale = new Vector3(1f, 45f, 10f);
        cubeD.transform.position = new Vector3(x_pos, y_pos - cubeUD_offset_y, z_pos - 2.5f);
        cubeD.transform.localScale = new Vector3(1f, 45f, 10f);

        // Sets the position and scale of the middle cube
        cubeM.transform.position = new Vector3(x_pos, y_pos - cubeUD_offset_y + 21f, z_pos - 2.5f);
        cubeM.transform.localScale = new Vector3(10f, 3f, 7f);

        // Destroys the walls in 10 secodns
        Destroy(cubeL, 10);
        Destroy(cubeR, 10);
        Destroy(cubeU, 10);
        Destroy(cubeD, 10);
        Destroy(cubeM, 10);
    }
}
