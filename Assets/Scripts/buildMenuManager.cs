using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buildMenuManager : MonoBehaviour
{
	public Button b_module_prefab;
	public List<Button> b_module_list;
	public Vector2 first_b_module_pos;
	public float space_between_modules;
	public float nbr_of_modules_per_line;
	public GameObject dome;
	public void spawn_module(GameObject new_module)
	{
		Manager.Data.module_source.GetComponent<module_manager>().place_module(Manager.Data.module_source, new_module);
	}
}
