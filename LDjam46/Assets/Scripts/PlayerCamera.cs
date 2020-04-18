using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 finalOffset;

    Vector3 target;
    Vector3 mousePos;
    Vector3 refVel;
    Vector3 shakeOffset;

    float cameraDist = 3.5f;

    float smoothTime = .2f;
    float yStart;
    float shakeMag;
    float shakeTimeEnd;

    Vector3 shakeVector;

    bool shaking;
    private void Start()
    {
        target = player.position;
        yStart = transform.position.y;
    }
    private void Update()
    {
        mousePos = CaptureMousePos();
        shakeOffset = UpdateShake();
        target = UpdateTargetPos();
        
    }
    private void FixedUpdate()
    {
        UpdateCameraPos();
    }
    Vector3 CaptureMousePos()
    {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        ret *= 2;
        ret -= Vector2.one;
        float xMax = 1f;
        float yMax = .9f;
        if (Mathf.Abs(ret.x) > xMax || Mathf.Abs(ret.y) > yMax)
        {
            ret.x = ret.normalized.x;
            ret.y = ret.normalized.y;
        }

        return ret;
    }
    Vector3 UpdateTargetPos()
    {
        Vector3 mouseOffset = new Vector3(mousePos.x * cameraDist, yStart, mousePos.y * cameraDist);
        Vector3 ret = player.position + mouseOffset;
        ret += shakeOffset;
        ret.y = yStart;
        return ret;
    }
    Vector3 UpdateShake()
    {
        if (!shaking || Time.time > shakeTimeEnd)
        {
            shaking = false;
            return Vector3.zero;
        }
        Vector3 tempOffset = shakeVector;
        tempOffset *= shakeMag;
        return tempOffset;

    }
    void UpdateCameraPos()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target + finalOffset, ref refVel, smoothTime);
        transform.position = tempPos;
    }
    public void Shake(Vector3 direction, float magnitude, float length)
    {
        shaking = true;
        shakeVector = direction;
        shakeMag = magnitude;
        shakeTimeEnd = Time.time + length;
    }
}
