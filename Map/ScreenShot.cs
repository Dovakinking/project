using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class ScreenShot : MonoBehaviour
{ // инструмент для создания скриншота карты

	private enum AA { none = 1, _2samples = 2, _4samples = 4, _8samples = 8 }
	[SerializeField] private Transform mainCube;
	[SerializeField] private int resolution = 2000; // разрешение для наибольшей стороны
	[SerializeField] private AA antiAliasing = AA.none;
	private int width, height;

	public void TakeScreenshot()
	{
		float aspect = mainCube.localScale.x / mainCube.localScale.y;

		if (mainCube.localScale.x > mainCube.localScale.y)
		{
			width = resolution;
			height = Mathf.RoundToInt(resolution / aspect);
		}
		else
		{
			height = resolution;
			width = Mathf.RoundToInt(resolution * aspect);
		}

		Camera cam = GetComponent<Camera>();
		cam.orthographic = true;
		cam.clearFlags = CameraClearFlags.Depth;
		cam.renderingPath = RenderingPath.VertexLit;
		RenderTexture rt = new RenderTexture(width, height, 24);
		rt.antiAliasing = (int)antiAliasing;
		cam.targetTexture = rt;
		cam.orthographicSize = mainCube.localScale.y * 0.5f;
		Texture2D screenShot = new Texture2D(width, height, TextureFormat.ARGB32, false);
		cam.Render();
		RenderTexture.active = rt;
		screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		cam.targetTexture = null;
		RenderTexture.active = null;
		DestroyImmediate(rt);
		byte[] bytes = screenShot.EncodeToPNG();
		string filename = Screenshot();
		System.IO.File.WriteAllBytes(filename, bytes);
		Debug.Log("Создан скриншот: " + filename);
		DestroyImmediate(screenShot);
	}

	string Screenshot()
	{
		return string.Format("{0}/shot_{1}.png",
			Application.persistentDataPath,
			System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}
}