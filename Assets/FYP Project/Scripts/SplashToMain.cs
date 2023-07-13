//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//---------------------------------------------------------------------------------
// Author		: XXX
// Date  		: 2015-05-12
// Modified By	: YYY
// Modified Date: 2015-05-12
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
public class SplashToMain : MonoBehaviour 
{
    private IEnumerator Start()
{
    yield return new WaitForSeconds(5);
    if (FadeScreen.instance != null)
    {
        FadeScreen.instance.FadeOutToScene(6,1,0);
    }
    else
    {
        Debug.LogError("FadeScreen instance is null!");
    }
}
}
