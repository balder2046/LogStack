using UnityEngine;
using System.Collections;
using System.IO;
public class LogSystem : MonoBehaviour {

	// Use this for initialization
	LogInterface logWriter = null;
	void Start () {
		string logPath = Path.Combine (Application.persistentDataPath, "profile.log");
		FileStream fs = new FileStream (logPath,FileMode.Create);
		logWriter = new LogInterface (fs);
		inst = this;
	}
	public static LogSystem inst = null;
	public void LogFormat(string format,params object[] args)
	{
		string text = string.Format (format, args);
		logWriter.Log (text);
	}
	public void Log(string content)
	{
		logWriter.Log (content);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
