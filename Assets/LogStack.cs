using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Text;
public class LogStack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PrintCurrentStatck ();
	}
	void PrintCurrentStatck()
	{
		StackTrace trace = new StackTrace (true);
		StackFrame[] frames = trace.GetFrames ();
		StringBuilder builder = new StringBuilder ();
		for (int i = 0; i < frames.Length; ++i) {
			StackFrame frame = frames [i];
			string typename = frame.GetMethod ().DeclaringType.Namespace;
			string fullMethodname;
			if (typename == null) {
				fullMethodname = frame.GetMethod ().DeclaringType.Name ;
			} else {
				var declType = frame.GetMethod ().DeclaringType;
				fullMethodname = string.Format ("{0}.{1}", declType.Namespace, declType.Name);
			}
			fullMethodname = fullMethodname + ":" + frame.GetMethod ().Name;
			// 使用格式 namespace.class:method (fillpath:linenum)\n
			builder.AppendFormat ("{0} ({1}:{2})\n",fullMethodname,frame.GetFileName(), frame.GetFileLineNumber ());
		}
		UnityEngine.Debug.Log (builder.ToString());
	}
	// Update is called once per frame
	void Update () {
	
	}
}
