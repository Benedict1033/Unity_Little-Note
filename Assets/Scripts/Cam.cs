using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    private bool camAvailable;
    WebCamTexture backcam;
    Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

        
    private void Start()
    {

        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            camAvailable = false;return;
        }

        for (int i = 0; i < devices.Length; i++) {

            if (!devices[i].isFrontFacing) {
                backcam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);

            }
        }

        if (backcam == null) {
            return;
        }

        backcam.Play();
        background.texture = backcam;

        camAvailable = true;

       
    }

    private void Update()
    {
        if (!camAvailable)
            return;

        float ratio = (float)backcam.width / (float)backcam.height;
        fit.aspectRatio = ratio;

        float scaleY = backcam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(0.465f, scaleY*0.465f, 1f);

        int orient = -backcam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    public void calender() {

        SceneManager.LoadScene("calender");
    }
}
