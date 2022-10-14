using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlider : MonoBehaviour
{

    [SerializeField] private Camera m_camera;
    [SerializeField] private Vector3 origin;
    [SerializeField] private Vector3 startMouseDown;
    [SerializeField] private bool isDrag;
    [SerializeField] private float speed = 1f;

    private void Start()
    {
        m_camera = GetComponent<Camera>();
        origin = m_camera.transform.position;
    }

    private void FixedUpdate()
    {
        if(!isDrag)
        {
            origin = Camera.main.transform.position;
        }
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(!isDrag)
            {
                startMouseDown = Input.mousePosition;
                origin = transform.position;
                isDrag = true;
            }
        }
        else
        {
            isDrag = false;
            m_camera.transform.position = origin;
        }

        if(isDrag)
        {
            Vector2 direction = (Input.mousePosition - startMouseDown).normalized;
            m_camera.transform.position 
                = translateToCameraPosition(m_camera.transform.position * Vector2.one + speed * direction * Time.deltaTime);
        }
        
    }

    private Vector3 translateToCameraPosition(Vector2 value) => new Vector3(value.x, value.y, -10);

}
