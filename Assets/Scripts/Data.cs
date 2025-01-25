using System.Collections.Generic;
using UnityEngine;

// TODO: Globalement celui la c'est le module manager, j'ai fais un peu de code cleaning,
// mais si tu pouvais renommer la classe et les dependencies... j'ai pas trop touche au code pour pas faire de betises.
public class Manager : MonoBehaviour
{
	public class Module
	{
		public Vector2 position = new(0f, 0f);
	}
	public static class Data
	{
		//liste des modules existants
		public static List<Module> Modules_list = new();
	}
}
