using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    [SerializeField] private float panSpeed = 30f;
    // [SerializeField] private float panBorderThickness = 10f; 
    // [SerializeField] private float scrollSpeed = 5f;
    // [SerializeField] private float minY = -80f;
    // [SerializeField] private float maxY = -7f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;
        if(!doMovement)
            return;
        if(Input.GetKey("s"))
        {
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        // Vector3 pos = transform.position;

        // pos.z -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        // pos.z = Mathf.Clamp(pos.z, minY, maxY);

        // transform.position = pos;
    }
}
