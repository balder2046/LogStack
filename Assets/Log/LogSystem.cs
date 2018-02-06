using UnityEngine;
using System.Collections;
using System.IO;
using System.Net.Sockets;
public class LogSystem : MonoBehaviour {

	// Use this for initialization
	LogInterface logWriter = null;
	public string localFileName = "profile.log";
	public bool useLocalLogFile = true;
	public string hostLogServer = "127.0.0.1";
	public int hostLogServerPort = 8888;
	void Start () {
		if (useLocalLogFile) {
			string logPath = Path.Combine (Application.persistentDataPath, localFileName);
			FileStream stream = new FileStream (logPath, FileMode.Create);
			logWriter = new LogInterface (stream);
		} else {
			try 
			{
				TcpClient client = null;
				client = new TcpClient (hostLogServer, hostLogServerPort);
				Stream stream = client.GetStream ();
				logWriter = new LogInterface (stream);
			}
			catch(SocketException exp) {
				Debug.LogError (exp.Message);
			}
		}

		inst = this;
	}
	public static LogSystem inst = null;

	public void LogFormatWithStack(string format,params object[] args)
	{
		if (logWriter == null)
			return;
		string content = string.Format (format, args);
		log (true, content);

	}
	public void LogFormat(string format,params object[] args)
	{
		if (logWriter == null)
			return;
		string content = string.Format (format, args);
		log (false, content);

	}
	public void Log(string content)
	{
		if (logWriter == null)
			return;
		log (false,content);
	}
	public void LogWithStack(string content)
	{
		if (logWriter == null)
			return;
		log (true,content);
	}
	void log(bool withstack,string content)
	{
		if (logWriter == null)
			return;
		if (!content.EndsWith ("\n")) {
			content += "\n";
		}
		if (withstack) {
			content = content + LogStack.GetCurrentStatck (2);
		}
		logWriter.Log (content);
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnApplicationQuit()
	{
		if (logWriter == null)
			return;
		logWriter.Close ();
	}
}
