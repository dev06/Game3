using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;

public class WindowHandler : MonoBehaviour {


	public Rect ScreenPosition; public bool IsFullscreen = false;
	[DllImport("user32.dll")]
	static extern IntPtr SetWindowLong(IntPtr hwnd, int _nIndex, int dwNewLong);
	[DllImport("user32.dll")]
	static extern bool SetWindowPos (IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
	[DllImport("user32.dll")]
	static extern IntPtr GetForegroundWindow ();
	const uint SWP_SHOWWINDOW = 0x0040;
	const int GWL_STYLE = -16;
	const int WS_BORDER = 1;
#if !UNITY_EDITOR && UNITY_STANDALONE_WIN




	void Start ()
	{

		SetBorderlessWindow();
	}
#endif
#if UNITY_EDITOR
	void Update() {
		if (IsFullscreen) ScreenPosition = GetFullscreenResolution();
	}
#endif
	Rect GetFullscreenResolution()
	{
		Resolution resolution = Screen.currentResolution;
		return new Rect(0f, 0f, (float)resolution.width, (float)resolution.height);
	}

	public void SetBorderlessWindow()
	{
		if (IsFullscreen)
			ScreenPosition = GetFullscreenResolution();
		SetWindowLong (GetForegroundWindow (), GWL_STYLE, WS_BORDER);
		bool result = SetWindowPos (GetForegroundWindow (), 0, (int)(Screen.currentResolution.width / 2) - (int)(GameController.Instance.WindowResolution.x / 2), (int)(Screen.currentResolution.height / 2) - (int)(GameController.Instance.WindowResolution.y / 2), (int)GameController.Instance.WindowResolution.x, (int)GameController.Instance.WindowResolution.y, SWP_SHOWWINDOW);

	}

}
