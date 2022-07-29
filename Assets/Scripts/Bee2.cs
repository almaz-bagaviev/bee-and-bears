using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;

public class Bee2 : MonoBehaviour
{
    Rigidbody rb;
    Vector3 targetVelocity;
    float LaneOffset = 2f, LaneChangeSpeed = 77f;
    float pointStart, pointFinish, lastVectorX;
    bool isMoving, isJumping;
    Coroutine GoingCoroutine;
    float JumpPower = 1200f, JumpGravity = -30f, realGravity = -9.8f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isMoving = false;
        isJumping = false;
        SwipeManagerScript.instance.MoveEvent += MoveBee;
    }

    private void MoveBee(bool[] swipes)
    {
        if (swipes[(int)Direction.Left] && pointFinish > -LaneOffset) MoveHorizontal(-LaneChangeSpeed);

        if (swipes[(int)Direction.Right] && pointFinish < LaneOffset) MoveHorizontal(LaneChangeSpeed);

        if (swipes[(int)Direction.Up] && isJumping == false) Jump();
    }

    private void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        Physics.gravity = new Vector3(0, JumpGravity, 0);
        StartCoroutine(StopJumpCoroutine());
    }

    private IEnumerator StopJumpCoroutine()
    {
        do
        {
            yield return new WaitForFixedUpdate();
        }
        while (rb.velocity.y != 0);

        isJumping = false;
        Physics.gravity = new Vector3(0, realGravity, 0);
    }

    private void MoveHorizontal(float speed)
    {
        pointStart = pointFinish;
        pointFinish += Mathf.Sign(speed) * LaneOffset;

        if (isMoving == true)
        {
            StopCoroutine(GoingCoroutine);
            isMoving = false;
        }

        GoingCoroutine = StartCoroutine(MoveGo(speed));
        targetVelocity = new Vector3(-LaneChangeSpeed, 0, 0);
    }


    private IEnumerator MoveGo(float vectorX)
    {
        isMoving = true;
        while (Mathf.Abs(pointStart - transform.position.x) < LaneOffset)
        {
            yield return new WaitForFixedUpdate();
            rb.velocity = new Vector3(vectorX, rb.velocity.y, 0);
            vectorX = -lastVectorX;

            float x = Mathf.Clamp(transform.position.x, Mathf.Min(pointStart, pointFinish), Mathf.Max(pointStart, pointFinish));
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        rb.velocity = Vector3.zero;
        transform.position = new Vector3(pointFinish, transform.position.y, transform.position.z);

        if (transform.position.y > -0.03) rb.velocity = new Vector3(rb.velocity.x, -5, rb.velocity.z);
        isMoving = false;
    }
}