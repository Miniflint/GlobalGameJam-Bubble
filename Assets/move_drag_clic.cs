using UnityEngine;

public class move_drag_clic : MonoBehaviour
{
	// Vitesse de déplacement de la caméra
	public float moveSpeed = 5f;

	// Booléen pour suivre si le clic droit est enfoncé
	private bool isDragging = false;

	// Position initiale de la souris
	private Vector3 lastMousePosition;
	void Update()
	{
		// Gestion du clic droit de la souris
		HandleMouseInput();
	}

	void HandleMouseInput()
	{
		// Vérifie si le bouton droit de la souris est enfoncé
		if (Input.GetMouseButtonDown(1)) // 1 correspond au bouton droit
		{
			// Commence le drag
			isDragging = true;
			// Mémorise la position initiale de la souris
			lastMousePosition = Input.mousePosition;
		}

		// Vérifie si le bouton droit de la souris est relâché
		if (Input.GetMouseButtonUp(1))
		{
			// Arrête le drag
			isDragging = false;
		}

		// Si on est en train de dragger
		if (isDragging)
		{
			// Calcule le déplacement de la souris
			Vector3 delta = Input.mousePosition - lastMousePosition;

			// Convertit le déplacement en unités du monde
			Vector3 move = Camera.main.ScreenToWorldPoint(Input.mousePosition) -
						   Camera.main.ScreenToWorldPoint(lastMousePosition);

			// Ajuste le déplacement (inversez le signe si nécessaire)
			move.z = 0; // Assurez-vous que le mouvement est en 2D

			// Déplace la caméra
			transform.position -= move;

			// Met à jour la dernière position de la souris
			lastMousePosition = Input.mousePosition;
		}
	}
}
