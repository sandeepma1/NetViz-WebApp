using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebcamTest : MonoBehaviour
{
    public RawImage rawImage;
    WebCamTexture webcamTexture;

    void Start()
    {
        webcamTexture = new WebCamTexture();
        rawImage.texture = webcamTexture;
        webcamTexture.Play();
    }

    void OnGUI()
    {
        if (webcamTexture.isPlaying)
            if (GUILayout.Button("Stop"))
                webcamTexture.Stop();
    }
}
