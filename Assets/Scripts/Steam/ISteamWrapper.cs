public interface ISteamWrapper
{
	bool IsValid { get; }
	string PlayerName { get; }
	void Init(uint appId, bool asyncCallbacks);
	void Shutdown();
}

public class FacepunchSteamWrapper : ISteamWrapper
{
	public bool IsValid => Steamworks.SteamClient.IsValid;
	public string PlayerName => Steamworks.SteamClient.Name;

	public void Init(uint appId, bool asyncCallbacks)
	{
		Steamworks.SteamClient.Init(appId, asyncCallbacks);
	}

	public void Shutdown()
	{
		Steamworks.SteamClient.Shutdown();
	}
}
