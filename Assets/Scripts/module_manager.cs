using UnityEngine;

public class module_manager
{
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
	void place_module(GameObject reference_module, GameObject new_module, Vector2 direction)
	{
		GameObject spawned_object;
		SpriteRenderer referenceSpriteRenderer = reference_module.GetComponent<SpriteRenderer>();
		Vector2 referenceSize = referenceSpriteRenderer.bounds.size;
		spawned_object = GameObject.Instantiate(new_module);
		Vector3 new_module_position;
		new_module_position.x = (referenceSpriteRenderer.bounds.size.x / 2) * direction.x;
		new_module_position.y = (referenceSpriteRenderer.bounds.size.y / 4) * direction.y;
		new_module_position.z = (direction.y + referenceSpriteRenderer.transform.position.z);
		spawned_object.transform.position = new_module_position;
		Manager.Module module = new();
		module.position = spawned_object.transform.position;
		Manager.Data.Modules_list.Add(module);
	}
}
