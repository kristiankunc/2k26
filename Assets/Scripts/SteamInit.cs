using UnityEngine;

public class SteamInit : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);

		try
		{
			// Replace 252490 with your own App ID
			Steamworks.SteamClient.Init(480, true);
		}
		catch (System.Exception e)
		{
			// Steam is either closed, DLLs are missing, or you don't own the game
			Debug.LogError("Error initializing Steam: " + e.Message);
		}
		if (Steamworks.SteamClient.IsValid)
		{
			Debug.Log("Logged in as: " + Steamworks.SteamClient.Name);
		}
	}

	private void OnDisable()
	{
		Steamworks.SteamClient.Shutdown();
	}
}
