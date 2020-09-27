using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Camera cam;

    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    TVScreen tvScreen = hit.collider.gameObject.GetComponent<TVScreen>();
                    if(tvScreen != null)
                        UIMain.Instance.OnTvClicked(tvScreen.id);
                }
            }
        }
    }
}
