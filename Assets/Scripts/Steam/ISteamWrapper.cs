public interface ISteamWrapper
{
	bool IsValid { get; }
	string PlayerName { get; }
	void Init(uint appId, bool asyncCallbacks);
	void Shutdown();
}

#if !UNITY_EDITOR_LINUX
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
#else
public class StubSteamWrapper : ISteamWrapper
{
	public bool IsValid => false;
	public string PlayerName => "CI_Player";

	public void Init(uint appId, bool asyncCallbacks) { }

	public void Shutdown() { }
}
#endif
