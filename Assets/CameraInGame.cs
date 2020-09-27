using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInGame : MonoBehaviour
{
    public void GotoDesc()
    {
        GetComponent<Animation>().Play("gotoDesc");
    }
    public void GotoBall()
    {
        GetComponent<Animation>().Play("camBack");
    }
}
