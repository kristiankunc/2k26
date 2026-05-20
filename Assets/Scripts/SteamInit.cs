using Steamworks;
using UnityEngine;

public class SteamInit : MonoBehaviour
{
	void Awake()
	{
		try
		{
			SteamClient.Init(480, true);
			DontDestroyOnLoad(gameObject);
		}
		catch (System.Exception e)
		{
			Debug.LogError("Steam failed to initialize: " + e.Message);
		}
	}

	void Update()
	{
		SteamClient.RunCallbacks();
	}

	void OnApplicationQuit()
	{
		SteamClient.Shutdown();
	}
}
