using UnityEngine;
using System.Collections;
using System.IO;
public class LogInterface : MonoBehaviour {

	Stream m_logStream;
	StreamWriter m_streamWriter;
	public LogInterface(Stream stream)
	{
		m_logStream = stream;
		m_streamWriter = new StreamWriter (m_logStream);
	}
	public void Log(string content)
	{
		m_streamWriter.Write (content);
		m_streamWriter.Flush ();
	}
	public void Close()
	{
		m_streamWriter.Close ();
	}
}
