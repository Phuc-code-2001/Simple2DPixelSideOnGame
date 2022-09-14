using Assets._Sources.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : SmoothFollower, IRect
{
    [Header("Properties")]
    public Vector2 thresold_offset = new Vector2(6, 3.75f);
    public Vector2 centerBoxOffSet = new Vector2(1, 0);
    [Header("Components")]
    [SerializeField] private Camera _camera;

    [Header("Calculated Fields")]
    [SerializeField] private Rect aspect;
    [SerializeField] private Vector3 centerOfBox;
    [SerializeField] private Vector2 thresold;
    [SerializeField] float x_diff;
    [SerializeField] float y_diff;

    [SerializeField] private bool IsFollow = true;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        aspect = _camera.pixelRect;
        TargetObject = PlayerController.Instance.gameObject;

        if(TargetObject == null) IsFollow = false;
    }

    private void Update()
    {
        if (!IsFollow) return;
        
        thresold = calculateThresold();
        centerOfBox = calculateCenterOfBox();

        x_diff = Mathf.Abs(TargetObject.transform.position.x - centerOfBox.x);
        y_diff = Mathf.Abs(TargetObject.transform.position.y - centerOfBox.y);

        if (x_diff >= thresold.x || y_diff >= thresold.y)
        {
            targetFollowerPosition = GetNewPosition();
        }
    }

    private void FixedUpdate()
    {
        if (!IsFollow) return;
        if (transform.position != targetFollowerPosition) Follow(Time.fixedDeltaTime);
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

    public Vector3 calculateCenterOfBox()
    {
        return transform.position - new Vector3(centerBoxOffSet.x, centerBoxOffSet.y, 0);
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
        Gizmos.DrawWireCube(centerOfBox, new Vector3(thresold.x * 2, thresold.y * 2, 1));
        Gizmos.DrawWireSphere(centerOfBox, 0.15f);
    }


}
