using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public CinemachineVirtualCamera virtualCam;

    public float horizontalInput;
    public float verticalInput;
    public float mouseScrollWheel;

    public float speed = 10f;
    float zoom;
    float zoomNasobek;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        zoom = virtualCam.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        virtualCam.m_Lens.OrthographicSize = zoom;
        zoomNasobek = zoom / 10;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        horizontalInput = Input.GetAxisRaw("Horizontal");// Tyhle 2 jsou jen pro debug, aby jsi vidìl ten input
        verticalInput = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime * zoomNasobek);

        if(Input.GetAxis("Mouse ScrollWheel") > 1 && zoom > 9) // zábrana protoèení do záporných èísel
        {
            zoom -= 4;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < -1 && zoom < 50) 
        {
            zoom += 4;
        }
    }
}
