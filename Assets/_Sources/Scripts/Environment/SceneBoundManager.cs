using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBoundManager : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;
    private EdgeCollider2D edgeCollider;

    public Transform TopLeftPoint;
    public Transform BottomRightPoint;
    public GameObject VCam;

    public void Awake()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void Start()
    {
        TopLeftPoint = transform.Find("TopLeft");
        BottomRightPoint = transform.Find("BottomRight");
        polygonCollider.points = new Vector2[]
        {
            TopLeftPoint.position,
            new Vector2(TopLeftPoint.position.x, BottomRightPoint.position.y),
            BottomRightPoint.position,
            new Vector2(BottomRightPoint.position.x, TopLeftPoint.position.y),
            TopLeftPoint.position,
        };

        edgeCollider.points = new Vector2[]
        {
            TopLeftPoint.position,
            new Vector2(TopLeftPoint.position.x, BottomRightPoint.position.y),
            BottomRightPoint.position,
            new Vector2(BottomRightPoint.position.x, TopLeftPoint.position.y),
            TopLeftPoint.position,
        };

        if (VCam != null) VCam.SetActive(true);

    }

    

}
