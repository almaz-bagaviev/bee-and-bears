/*
using System.Collections;
using UnityEngine;

public class Bee2 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 targetVelocity;
    private float LaneOffset = 1.7f, LaneChangeSpeed = 15f;
    private float pointStart, pointFinish;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && pointFinish > -LaneOffset)
        {
            pointStart = pointFinish;
            pointFinish -= LaneOffset;
            targetVelocity = new Vector3(-LaneChangeSpeed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D) && pointFinish < LaneOffset)
        {
            pointStart = pointFinish;
            pointFinish += LaneOffset;
            targetVelocity = new Vector3(LaneChangeSpeed, 0, 0);
        }

        float x = Mathf.Clamp(transform.position.x, Mathf.Min(pointStart, pointFinish), Mathf.Max(pointStart, pointFinish));
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }


    private void FixedUpdate()
    {
        rb.velocity = targetVelocity;
        if ((transform.position.x > pointFinish && targetVelocity.x > 0) || (transform.position.x < pointFinish && targetVelocity.x < 0))
        {
            targetVelocity = Vector3.zero;
            rb.velocity = targetVelocity;
            rb.position = new Vector3(pointFinish, rb.position.y, rb.position.z);
        }
    }
}

*/