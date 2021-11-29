using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrow : MonoBehaviour
{
    public Transform playerBody;
    public PlayerMovement playerMovement;
    public float scaleDiff = 1f;
    public float scale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {

        }else if(Input.GetMouseButton(0))
        {
            if(scale < 3.0f)
            {
                scale += scaleDiff * Time.deltaTime;
            }else if(scale > 3.0f)
            {
                scale = 3.0f;
            }

        }else if(Input.GetMouseButton(1))
        {

            if (scale > 0.25f)
            {
                scale -= scaleDiff * Time.deltaTime;
            }
            else if (scale < 0.25f)
            {
                scale = 0.25f;
            }

        }
    }
}
