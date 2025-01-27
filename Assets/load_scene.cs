using UnityEngine;
using UnityEngine.SceneManagement;


public class load_scene : MonoBehaviour
{
    public void new_game()
	{
		SceneManager.LoadScene(1);
	}

	public void quit_game()
	{
		Application.Quit();
	}
}
