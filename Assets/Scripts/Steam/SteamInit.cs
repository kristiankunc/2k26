using UnityEngine;

public class SteamInit : MonoBehaviour
{
	public ISteamWrapper SteamWrapper { get; set; } = new FacepunchSteamWrapper();

	protected virtual void Awake()
	{
		MakePersistent();

		try
		{
			InitializeSteam();
		}
		catch (System.Exception e)
		{
			Debug.LogError("Error initializing Steam: " + e.Message);
		}

		if (SteamWrapper.IsValid)
		{
			Debug.Log("Logged in as: " + SteamWrapper.PlayerName);
		}
	}

	protected virtual void MakePersistent()
	{
		DontDestroyOnLoad(gameObject);
	}

	protected virtual void OnDisable()
	{
		ShutdownSteam();
	}

	protected virtual void InitializeSteam()
	{
		SteamWrapper.Init(480, true);
	}

	protected virtual void ShutdownSteam()
	{
		SteamWrapper.Shutdown();
	}
}
