using System.Collections.Generic;
using UnityEngine;

// TODO: Globalement celui la c'est le module manager, j'ai fais un peu de code cleaning,
// mais si tu pouvais renommer la classe et les dependencies... j'ai pas trop touche au code pour pas faire de betises.
public class Manager : MonoBehaviour
{
	public GameObject prefab_oxygen_module;
	public GameObject prefab_energy_module;
	public GameObject prefab_rocket_module;
	public class Module
	{
		public GameObject module_object;
		public string module_name;
	}
	public static class Data
	{
		//liste des module_manager existants
		public static List<GameObject> Modules_list = new();
		public static GameObject module_source;
	}
}
