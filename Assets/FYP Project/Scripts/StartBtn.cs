//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


//---------------------------------------------------------------------------------
// Author		: XXX
// Date  		: 2015-05-12
// Modified By	: YYY
// Modified Date: 2015-05-12
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
public class StartBtn : MonoBehaviour
{
	public void StartButton(string GameScene)
	{
		SceneManager.LoadScene(GameScene);

	}
}
