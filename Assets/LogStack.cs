using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Text;
public class LogStack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	// skip 略过的堆栈数 
	public static string GetCurrentStatck(int skip)
	{
		StackTrace trace = new StackTrace (true);
		StackFrame[] frames = trace.GetFrames ();
		StringBuilder builder = new StringBuilder ();
		// 要把本次函数调用给过滤掉
		for (int i = skip + 1; i < frames.Length; ++i) {
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
		return builder.ToString ();

	}
	// Update is called once per frame
	void Update () {
	
	}
}
