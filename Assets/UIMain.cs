using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class UIMain : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void ShowVideo(string str);

    public Text debugField;
    public static UIMain Instance;
    public Ball ball;
    public Text field;
    public int id;
    public CameraInGame cameraInGame;
    public UITVDesc uITVDesc;

    public states state;
    public enum  states
    {
        IDLE,
        TV_ON
    }

    public void Awake()
    {
        Instance = this;
        debugField.text = SystemInfo.graphicsDeviceType.ToString();
    }
    public void ShowVideoByID(string videoID)
    {
        ShowVideo(videoID);
    }
    public void ListenFromJS(string text)
    {
        field.text = text;
    }
    public void VideoClosed(int videoID)
    {
        field.text = "cierra "  + videoID;
    }
    public void RotateBall(bool left)
    {
        if(!left)
            id++;
        else
            id--;
        if (id < 0)
            id = 5;
        else if (id > 5)
            id = 0;
        ball.RotateTo(id);
    }
    public void OnTvClicked(int _id)
    {
        this.id = _id;
        ball.RotateTo(id);
        ChangeTo(states.TV_ON);
    }
    public void ChangeTo(states _state)
    {
        if(_state == states.TV_ON)
            uITVDesc.Init();
        if (_state != state)
        {
            if (_state == states.TV_ON)
            {
                cameraInGame.GotoDesc();
                GetComponent<Animation>().Play("desc");
            }
            else if (_state == states.IDLE)
            {
                cameraInGame.GotoBall();
                GetComponent<Animation>().Play("back");
            }
            this.state = _state;
        }        
    }
}
