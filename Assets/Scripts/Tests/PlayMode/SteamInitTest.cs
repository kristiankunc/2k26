using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SteamInitTest
{
	private class MockSteamWrapper : ISteamWrapper
	{
		public bool InitCalled { get; private set; }
		public bool ShutdownCalled { get; private set; }
		public bool IsValid { get; set; } = true;
		public string PlayerName { get; set; } = "TestPlayer";
		public bool ShouldThrowError { get; set; } = false;

		public void Init(uint appId, bool asyncCallbacks)
		{
			InitCalled = true;
			if (ShouldThrowError)
			{
				throw new System.Exception("Simulated Steam Crash");
			}
		}

		public void Shutdown()
		{
			ShutdownCalled = true;
		}
	}

	[UnityTest]
	public IEnumerator SteamInit_OnAwake_InitializesSteamSuccessfully()
	{
		GameObject go = new GameObject("SteamInitTestObject");
		go.SetActive(false);

		SteamInit steamInit = go.AddComponent<SteamInit>();

		MockSteamWrapper mockSteam = new MockSteamWrapper();
		steamInit.SteamWrapper = mockSteam;

		go.SetActive(true);
		yield return null;

		Assert.IsTrue(mockSteam.InitCalled, "SteamInit should have called Init on the wrapper.");

		Object.Destroy(go);
	}

	[UnityTest]
	public IEnumerator SteamInit_OnDisable_ShutsDownSteam()
	{
		GameObject go = new GameObject("SteamInitTestObject");
		SteamInit steamInit = go.AddComponent<SteamInit>();
		MockSteamWrapper mockSteam = new MockSteamWrapper();
		steamInit.SteamWrapper = mockSteam;

		yield return null;

		go.SetActive(false);
		yield return null;

		Assert.IsTrue(mockSteam.ShutdownCalled, "SteamInit should have called Shutdown when disabled.");

		Object.Destroy(go);
	}
}
