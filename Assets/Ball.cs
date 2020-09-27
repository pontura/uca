using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10;
    float to;
    public Transform target;
    public Transform rotateGO;

    void FixedUpdate()
    {
        Quaternion lookOnLook = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation =  Quaternion.Slerp(transform.rotation, lookOnLook, speed * Time.deltaTime);
    }

    public void RotateTo(int _id)
    {
        to = (360 / 6) * (float)_id;
        rotateGO.localEulerAngles = new Vector3(0, to, 0);
    }
}
