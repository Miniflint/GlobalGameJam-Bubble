using UnityEditor;
using UnityEngine;

public class Notify : MonoBehaviour
{
	public class Alert
	{
		public static void printInfo(string message)
		{
			string title = "INFORMATION";
			print(title);
			print(message);
			//TODO:print an error message on the screen
		}
	}
}