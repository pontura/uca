using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITVDesc : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }
    
    public void Init()
    {
        
    }
    public void Close()
    {
        UIMain.Instance.ChangeTo(UIMain.states.IDLE);
    }
}
