﻿using UnityEngine;
using System.Collections;

public class ImmersiveModeEnabler : MonoBehaviour {

	//WIP. Added the IfUnityAndroid for IOS Build

	//#if UNITY_ANDROID
	AndroidJavaObject unityActivity;
	AndroidJavaObject javaObj;
	AndroidJavaClass javaClass;
	//#endif

	bool paused;


	void Awake()
	{
		if(!Application.isEditor)
			HideNavigationBar();
		DontDestroyOnLoad(gameObject);
	}
	
	void HideNavigationBar()
	{
		//#if UNITY_ANDROID
		lock(this)
		{
			using(javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				unityActivity = javaClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
			
			if(unityActivity == null)
			{
				return;
			}
			
			using(javaClass = new AndroidJavaClass("com.rak24.androidimmersivemode.Main"))
			{
				if(javaClass == null)
				{
					return;
				}
				else
				{
					javaObj = javaClass.CallStatic<AndroidJavaObject>("instance");
					if(javaObj == null)
						return;
					unityActivity.Call("runOnUiThread",new AndroidJavaRunnable(() => 
					                                                           {
						javaObj.Call("EnableImmersiveMode", unityActivity);
					}));
				}
			}
		}
		//#endif
	}
	
	void OnApplicationPause(bool pausedState)
	{
		paused = pausedState;
	}
	
	void OnApplicationFocus(bool hasFocus)
	{
		if(hasFocus)
		{
			if(javaObj != null && paused != true)
			{
				unityActivity.Call("runOnUiThread",new AndroidJavaRunnable(() => 
						                                                           {
							javaObj.CallStatic("ImmersiveModeFromCache", unityActivity);
						}));
			}
		}
		
	}

}
