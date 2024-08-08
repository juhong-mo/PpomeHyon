using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://blog.naver.com/kch8246/221264679015
public class Fixed : MonoBehaviour
{
    public GameObject m_objBackScissor;

    // Start is called before the first frame update
    void Start()
    {
        //SetResolution();

        //var camera = GetComponent<Camera>();
        //var r = camera.rect;
        //var scaleheight = ((float)Screen.width / Screen.height) / (9f / 16f);
        //var scalewidth = 1f / scaleheight;

        //if(scaleheight < 1f)
        //{
        //    r.height = scaleheight;
        //    r.y = (1f - scaleheight) / 2f;
        //}
        //else
        //{
        //    r.width = scalewidth;
        //    r.x = (1f - scalewidth) / 2f;
        //}

        //camera.rect = r;
    }

    //private void OnPreCull() => GL.Clear(true, true, Color.black);


    //void SetResolution()
    //{
    //    int setWidth = 1080;
    //    int setHeight = 1920;

    //    int deviceWidth = Screen.width;
    //    int deviceHeight = Screen.height;

    //    Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true);

    //    if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight)
    //    {
    //        float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight);
    //        Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
    //    }
    //    else
    //    {
    //        float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight);
    //        Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
    //    }
    //}

    private void Awake()
    {
        UpdateResolution();
    }

    void UpdateResolution()
    {
        Camera[] objCameras = Camera.allCameras;

        float fResolX = Screen.width / 9f;
        float fResolY = Screen.height / 16f;

        if(fResolX < fResolY)
        {
            float fValue = (fResolY - fResolX) * 0.5f;
            fValue = fValue / fResolY;

            foreach(Camera obj in objCameras)
            {
                obj.rect = new Rect(obj.rect.x, ((Screen.height * fValue) / Screen.height) + (obj.rect.x * (1.0f - (2.0f * fValue))),
                    obj.rect.width, obj.rect.height * (1.0f - (2.0f * fValue)));
            }


            GameObject objBottomScissor = (GameObject)Instantiate(m_objBackScissor);
            objBottomScissor.GetComponent<Camera>().rect = new Rect(0, 0, 1.0f, (Screen.height * fValue) / Screen.height);

            GameObject objTopScissor = (GameObject)Instantiate(m_objBackScissor);
            objTopScissor.GetComponent<Camera>().rect = new Rect(0, (Screen.height - (Screen.height * fValue)) / Screen.height,
                1.0f, (Screen.height * fValue) / Screen.height);

            objBottomScissor.transform.parent = gameObject.transform;
            objTopScissor.transform.parent = gameObject.transform;
        }
        else
        {

        }
    }
}
