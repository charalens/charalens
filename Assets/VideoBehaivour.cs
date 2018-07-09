using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;


public class VideoBehaivour : MonoBehaviour
{
	private int c = 0;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		//gameObject.GetComponent<VideoPlayer>().playbackSpeed = 60;

		if (c == 10)
		{
			UnityWebRequest req = UnityWebRequest.Get("http://10.104.50.41:2700/charalens/api/state");
			UnityWebRequestAsyncOperation op = req.SendWebRequest();
			VideoPlayer player = GetComponent<VideoPlayer>();
			op.completed += operation =>
			{
				//Console.WriteLine(req.downloadHandler.text);
			//   Debug.LogWarning(req.downloadHandler.text);
				String[] ks = req.downloadHandler.text.Split(':');
				player.time = Convert.ToDouble(ks[1]);
				if(ks[0].Equals("play")){
					player.Play();
				}
				else if (ks[0].EndsWith("pause"))
				{
					player.Pause();
				}
			};
			c = 0;
		}
		++c;


	}
}
