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
    public float dragSpeed = 50f;
    public float zoom;
    public float zoomNasobek;

    Vector2 movement;

    void Start()
    {
        zoom = virtualCam.m_Lens.OrthographicSize;
    }

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

        if (Input.GetMouseButton(0)) // Movement pomocí myše
        {
            Vector2 dragDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            transform.Translate(-dragDelta * dragSpeed * Time.deltaTime * zoomNasobek, Space.World);
        }
    }
}
