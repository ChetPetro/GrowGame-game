using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrow : MonoBehaviour
{
    public Transform playerBody;
    private Vector3 playerScale;
    public float scaleDiff = 1f;
    private float scale = 1f;
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
            if((scale < 4f) && (scale >= 1f))
            {
                scale += scaleDiff * Time.deltaTime;
            }else if((scale < 4f) && (scale < 1f))
            {
                scale += scaleDiff * Time.deltaTime * (1 / 4);
            }

        }else if(Input.GetMouseButton(1))
        {
            Debug.Log("right click");
            if ((scale  > 0.25f) && (scale < 1f))
            {
                scale -= scaleDiff * Time.deltaTime * (1/4);
            }
            else if ((scale > 0.25f) && (scale >= 1f))
            {
                scale -= scaleDiff * Time.deltaTime;
            }

        }
        playerScale = new Vector3(scale, scale, scale);
        playerBody.transform.localScale = playerScale;
    }
}
