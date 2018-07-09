using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;
using UnityEngine.Windows.Speech;

public class SpeechBehaivour : MonoBehaviour
{
	KeywordRecognizer recognizer;
	private GameObject video;

	private Task task ;

	private double currentTime = 0.0;

	private Dictionary<String, System.Action> actions = new Dictionary<string, Action>();
	
	// Use this for initialization
	void Start () {
		
	//	client = new Socket(SocketType.Stream,ProtocolType.Tcp);
	//	client.Connect("10.104.52.111",2700);
		
		video = GameObject.Find("Cube");
		actions.Add("scale up", () =>
		{
			Vector3 transformLocalScale = video.transform.localScale;
			video.transform.localScale = new Vector3(
			transformLocalScale.x * 1.2F,
			transformLocalScale.y * 1.2F,
			transformLocalScale.z * 1.2F
			);
			Debug.LogError("ffffuc");
		});
		actions.Add("see you", () =>
		{
			gameObject.transform.localScale = new Vector3(
				0,0,0
			);
			Debug.LogError("ffffuc");
		});
		actions.Add("assistant please", () =>
		{
			gameObject.transform.localScale = new Vector3(
				0.2F, 0.2F, 0.2F
			);
			Debug.LogError("ffffuc");
		});
		actions.Add("scale down", () =>
		{
			Vector3 transformLocalScale = video.transform.localScale;
			video.transform.localScale = new Vector3(
				transformLocalScale.x / 1.2F,
				transformLocalScale.y / 1.2F,
				transformLocalScale.z / 1.2F
			);
			Debug.LogError("ffffuc");
		});
		actions.Add("play", () =>
		{
			VideoPlayer player = GameObject.Find("Cube").GetComponent<VideoPlayer>();
			UnityWebRequest req = UnityWebRequest.Get("http://10.104.50.41:2700/charalens/api/play");
			UnityWebRequestAsyncOperation op = req.SendWebRequest();
			op.completed += operation =>
			{
				player.time = Convert.ToDouble(req.downloadHandler.text);
				player.Play();
			};
			
		});
		actions.Add("pause", () =>
		{
			VideoPlayer player = GameObject.Find("Cube").GetComponent<VideoPlayer>();
			UnityWebRequest req = UnityWebRequest.Get("http://10.104.50.41:2700/charalens/api/pause");
			UnityWebRequestAsyncOperation op = req.SendWebRequest();
			op.completed += operation =>
			{
				player.time = Convert.ToDouble(req.downloadHandler.text);
				player.Pause();
			};
		});
		recognizer = new KeywordRecognizer(actions.Keys.ToArray());
		recognizer.OnPhraseRecognized += args =>
		{
			
			actions[args.text].Invoke();
		};
		recognizer.Start();

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
