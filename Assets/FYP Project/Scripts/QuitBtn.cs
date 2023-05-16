//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

//---------------------------------------------------------------------------------
// Author		: XXX
// Date  		: 2015-05-12
// Modified By	: YYY
// Modified Date: 2015-05-12
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
public class QuitBtn : MonoBehaviour
{
    public void QuitButton()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
