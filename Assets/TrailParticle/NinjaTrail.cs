using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class NinjaTrail : MonoBehaviour
{
    public TrailRenderer  trailRenderer;

    public float depth = 0.5f;

    bool isTrailActive = false;

    void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;

        if (Input.GetMouseButton(0))
        {
            ShowTrail();
        }
    }

    void LateUpdate()
    {
        trailRenderer.emitting = isTrailActive;
        isTrailActive = false;
    }

    public void ShowTrail()
    {
        isTrailActive = true;
    }
}
