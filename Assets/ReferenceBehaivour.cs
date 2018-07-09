using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Sharing;
using UnityEngine;
using UnityEngine.Networking;

public class ReferenceBehaivour : MonoBehaviour {

	
	 
	
	// Use this for initialization
	IEnumerator Start ()
	{
		
		WWW www = new WWW("http://10.104.50.41/charalens/course170/chapter2235/doc/1453.png");
		yield return www;
		Texture2D tex = www.texture;
		;// Resources.Load("longlong") as Texture2D;
		gameObject.GetComponent<Renderer>().material.mainTexture = tex;
	
		gameObject.GetComponent<Renderer>().material.mainTexture.filterMode = FilterMode.Bilinear;
		Debug.LogError(tex.width + "/" + tex.height);
		gameObject.transform.localScale = new Vector3(0.32F,0.32F * ((float)tex.height / tex.width),0.01F);
	   //	gameObject.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1F,(float)tex.width / tex.height);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	
	

	}
}
