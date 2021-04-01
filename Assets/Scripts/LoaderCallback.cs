using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void FixedUpdate()
    {
        if (isFirstUpdate == true)
        {
            isFirstUpdate = false;
            SceneLoader.LoaderCallback();
        }
    }
}
