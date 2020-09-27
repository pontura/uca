using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10;
    float to;
    public Transform target;
    public Transform rotateGO;
    bool justStartedRotation;

    void FixedUpdate()
    {
        Quaternion lookOnLook = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation =  Quaternion.Slerp(transform.rotation, lookOnLook, speed * Time.deltaTime);
        float d = Mathf.Abs(transform.localEulerAngles.y - lookOnLook.eulerAngles.y);
      //  print(d);
        if (
            !justStartedRotation &&
            (d < 0.5f || d> 359.5f)
            )
        {
            justStartedRotation = true;
            UIMain.Instance.ActivateVideo();
        }
    }
    void Reset()
    {
        justStartedRotation = false;
    }
    public void RotateTo(int _id)
    {
        CancelInvoke();
        justStartedRotation = true;
         Invoke("Reset", 1);

        to = (360 / 6) * (float)_id;
        rotateGO.localEulerAngles = new Vector3(0, to, 0);
    }
}
