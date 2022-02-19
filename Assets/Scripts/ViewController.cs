using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public GameObject MapGo;
    private TerrainMapGenerator tgen;
    public GameObject ViewTarget;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        vcam.m_Lens.OrthographicSize = 100;
        tgen = MapGo.GetComponent<TerrainMapGenerator>();
        rb = ViewTarget.GetComponent<Rigidbody2D>();
        ViewTarget.transform.position = new Vector2(tgen.MapSize / 2, tgen.MapSize / 2);
        Debug.Log("New position should be..." + ViewTarget.transform.position.ToString());
        //ViewTarget = MapGo.GetComponent<ViewController>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        ProcessInputs();
    }

    void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && Mathf.Abs(vcam.m_Lens.OrthographicSize) > 1) // forward
        {
            vcam.m_Lens.OrthographicSize --;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && Mathf.Abs(vcam.m_Lens.OrthographicSize) > 1) // backwards
        {
            vcam.m_Lens.OrthographicSize ++;
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        float moveSpeed = 10;

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            Debug.Log("No Key Pressed");
        }
        else
        {
            Debug.Log("Key Pressed!");
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void MoveTarget()
    {
        //TODO
    }


}
