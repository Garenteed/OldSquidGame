using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCallBack : MonoBehaviour
{
    private void Update()
    {
        // call it on the first frame of the loading screen
        SceneLoader.LoadCallBack();
    }
}
