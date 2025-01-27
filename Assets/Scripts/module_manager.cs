using System;
using Unity.VisualScripting;
using UnityEngine;

public class module_manager : MonoBehaviour
{
	public GameObject ui;
	public GameObject modules_parent;
	public GameObject rocket;
	public int index_direction;
	public string type;

	private void Start()
	{
		switch (type)
		{
			case "rocket":
				ui.GetComponent<GameManager>().Consume_human(1);
				ui.GetComponent<GameManager>().Add_rocket(1);
				Manager.Data.rocket_list.Add((this.GameObject(), 1));
				GameObject spawned_rocket = GameObject.Instantiate(rocket);
				Vector3 destination = this.transform.position;
				//destination.y += 2;
				destination.z -= 1;
				spawned_rocket.transform.position = destination;				
				break;
			case "food_prod":
				ui.GetComponent<GameManager>().Add_wheat(1);
				break;
			case "oxygen_prod":
				ui.GetComponent<GameManager>().Add_tree(1);
				break;
			case "oxygen_tank":
				ui.GetComponent<GameManager>().Add_tank(1);
				break;
			default:
				break;
		}
		if (type == "food_prod" || type == "oxygen_prod" || type == "oxygen_tank")
			ui.GetComponent<GameManager>().Consume_human(2);
	}
	private void OnMouseDown()
	{
		Debug.Log(ui);
		Manager.Data.module_source = this.gameObject;
		ui.GetComponentInParent<GameManager>().OpenCloseBuildMenu(true);
	}
	/* Description: pose un nouveau module a cote d'un module existant a une direction definie
	 * la fonction est compatible avec des modules de taille differentes.
	 * ---------------------------------------------------------------------------------------
	 * input:
	 * - reference module : le module auquel on veut attacher un nouveau module
	 * - new module : le nouveau module a placer
	 * - new module : la direction (x, y) __________
	 *										        |
	 *								                v
	 *								      (-1,  1) / \ (1,  1)
	 *								      (-1, -1) \ / (1, -1)
	 */
	public void place_module(GameObject reference_module, GameObject new_module)
	{
		Vector2 direction = Vector2.zero;

		switch (index_direction)
		{
			case 0:
				direction.x = 1;
				direction.y = -1;
				break;
			case 1:
				direction.x = -1;
				direction.y = -1;
				break;
			case 2:
				direction.x = -1;
				direction.y = 1;
				break;
			case 3:
				direction.x = 1;
				direction.y = 1;
				break;
			default:
				Debug.Log("No available space left !");
				break;
		}
		GameObject spawned_object;
		SpriteRenderer referenceSpriteRenderer = reference_module.GetComponentInParent<SpriteRenderer>();
		Vector2 referenceSize = referenceSpriteRenderer.bounds.size;
		spawned_object = GameObject.Instantiate(new_module);
		spawned_object.GetComponent<module_manager>().ui = ui;
		spawned_object.GetComponent<module_manager>().modules_parent = modules_parent;
		foreach (Component obj in spawned_object.GetComponentsInChildren<Component>())
		{
			obj.GetComponent<module_manager>().ui = ui;
			obj.GetComponent<module_manager>().modules_parent = modules_parent;
		}
		Vector3 new_module_position;
		/*switch (this.type)
		{
			case "food_prod":
				new_module_position.x = reference_module.transform.position.x + (referenceSpriteRenderer.bounds.size.x / 2) * direction.x;
				new_module_position.y = reference_module.transform.position.y + (referenceSpriteRenderer.bounds.size.y / 4) * direction.y;
				new_module_position.z = (direction.y + referenceSpriteRenderer.transform.position.z);
				break;
			default:
				break;
		}*/
		new_module_position.x = reference_module.transform.position.x + (referenceSpriteRenderer.bounds.size.x / 2) * direction.x;
		new_module_position.y = reference_module.transform.position.y + (referenceSpriteRenderer.bounds.size.y / 4) * direction.y;
		new_module_position.z = (direction.y + referenceSpriteRenderer.transform.position.z);
		spawned_object.transform.position = new_module_position;
		spawned_object.transform.SetParent(modules_parent.transform);
		Manager.Data.Modules_list.Add(spawned_object);
	}
}
