using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
	public GameObject ui;
	public void spawn_module(GameObject new_module)
	{
		switch (new_module.GetComponent<module_manager>().type)
		{
			case "rocket":
				if (ui.GetComponent<GameManager>().get_oxy() >= Constants.REQ_ROCK_OXY && ui.GetComponent<GameManager>().get_availableHumans() >= Constants.REQ_ROCK_WOR)
				{
					ui.GetComponent<GameManager>().Add_oxy(-(int)Constants.REQ_ROCK_OXY);
					ui.GetComponent<GameManager>().Consume_human(-(int)Constants.REQ_ROCK_WOR);
					Manager.Data.module_source.GetComponent<module_manager>().place_module(Manager.Data.module_source, new_module);
				}
				break;
			case "food_prod":
				if (ui.GetComponent<GameManager>().get_oxy() >= Constants.REQ_FOOD_OXY && ui.GetComponent<GameManager>().get_availableHumans() >= Constants.REQ_FOOD_WOR)
				{
					ui.GetComponent<GameManager>().Add_oxy(-(int)Constants.REQ_FOOD_OXY);
					ui.GetComponent<GameManager>().Consume_human(-(int)Constants.REQ_FOOD_WOR);
					Manager.Data.module_source.GetComponent<module_manager>().place_module(Manager.Data.module_source, new_module);
				}
				break;
			case "oxygen_prod":
				if (ui.GetComponent<GameManager>().get_oxy() >= Constants.REQ_OXYG_OXY && ui.GetComponent<GameManager>().get_availableHumans() >= Constants.REQ_OXYG_WOR)
				{
					ui.GetComponent<GameManager>().Add_oxy(-(int)Constants.REQ_OXYG_OXY);
					ui.GetComponent<GameManager>().Consume_human(-(int)Constants.REQ_OXYG_WOR);
					Manager.Data.module_source.GetComponent<module_manager>().place_module(Manager.Data.module_source, new_module);
				}
				break;
			case "oxygen_tank":
				if (ui.GetComponent<GameManager>().get_oxy() >= Constants.REQ_TANK_OXY && ui.GetComponent<GameManager>().get_availableHumans() >= Constants.REQ_TANK_WOR)
				{
					ui.GetComponent<GameManager>().Add_oxy(-(int)Constants.REQ_TANK_OXY);
					ui.GetComponent<GameManager>().Consume_human(-(int)Constants.REQ_TANK_WOR);
					Manager.Data.module_source.GetComponent<module_manager>().place_module(Manager.Data.module_source, new_module);
				}
				break;
			default:
				break;
		}
	}
}
