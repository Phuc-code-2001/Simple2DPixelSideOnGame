using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : SmoothFollower, IRect
{

    public Vector2 thresold_offset = new Vector2(6, 3.75f);
    public Vector2 centerBoxOffSet = new Vector2(3, 0);
    [SerializeField] private Vector2 thresold;


    [SerializeField] float x_diff;
    [SerializeField] float y_diff;

    private void Start()
    {
        Follower = transform.gameObject;
        TargetObject = PlayerController.Instance.gameObject;
        Speed = 4;
    }

    private void Update()
    {
        thresold = calculateThresold();
        FollowerOffset = thresold;
    }

    private void FixedUpdate()
    {
        Camera camera = GetComponent<Camera>();
        Rect aspect = camera.pixelRect;
        Vector3 centerOfBox = transform.position - new Vector3(centerBoxOffSet.x, centerBoxOffSet.y, 0);

        x_diff = Mathf.Abs(TargetObject.transform.position.x - centerOfBox.x);
        y_diff = Mathf.Abs(TargetObject.transform.position.y - centerOfBox.y);

        if (x_diff >= thresold.x || y_diff >= thresold.y) Follow(Time.fixedDeltaTime); 
    }

    public Vector3 calculateThresold()
    {
        Camera camera = GetComponent<Camera>();
        Rect aspect = camera.pixelRect;
        Vector2 t = new Vector2(camera.orthographicSize * aspect.width / aspect.height, camera.orthographicSize);
        t.x -= thresold_offset.x;
        t.y -= thresold_offset.y;
        return t;
    }

    public float GetWidth()
    {
        Camera camera = GetComponent<Camera>();
        Rect aspect = camera.pixelRect;
        return camera.orthographicSize * aspect.width / aspect.height;
    }

    public float GetHeight()
    {
        Camera camera = GetComponent<Camera>();
        Rect aspect = camera.pixelRect;
        return camera.orthographicSize;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 border = thresold;
        Vector3 centerOfBox = transform.position - new Vector3(centerBoxOffSet.x, centerBoxOffSet.y, 0);
        Gizmos.DrawWireCube(centerOfBox, new Vector3(border.x * 2, border.y * 2, 1));
        Gizmos.DrawWireSphere(centerOfBox, 0.25f);
    }


}
