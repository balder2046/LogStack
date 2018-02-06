using UnityEngine;
using System.Collections;
using System.IO;
using System.Net.Sockets;
public class LogSystem : MonoBehaviour {

	// Use this for initialization
	LogInterface logWriter = null;
	void Start () {
		string logPath = Path.Combine (Application.persistentDataPath, "profile.log");
		FileStream fs = new FileStream (logPath,FileMode.Create);
		fs.Close ();

		try 
		{
			TcpClient client = null;
			client = new TcpClient ("127.0.0.1", 8888);
			Stream stream = client.GetStream ();
			logWriter = new LogInterface (stream);
		}
		catch(SocketException exp) {
			Debug.LogError (exp.Message);
		}

		inst = this;
	}
	public static LogSystem inst = null;
	public void LogFormat(string format,params object[] args)
	{
		if (logWriter == null)
			return;
		string text = string.Format (format, args);
		logWriter.Log (text);
	}
	public void Log(string content)
	{
		if (logWriter == null)
			return;
		logWriter.Log (content);
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnApplicationQuit()
	{
		logWriter.Close ();
	}
}
