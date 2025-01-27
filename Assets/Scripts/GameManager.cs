using NUnit.Framework;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using System.Collections.Specialized;
using System.Collections;
using UnityEngine.Android;
using UnityEngine.Timeline;
using Unity.Mathematics;
using NUnit.Framework.Internal;


// J'ai modif le fichier pour en faire deux classes distinctes et separer la gestion des ressources et la gestion des modules
// ca empeche pas qu'ils soient lies !
// Update : du coup en repensant a la gestion des ressources le mieux ca reste de faire  des classes imbriquees,
// sinon ca va etre trop la shit a gerer, faut essayer d'y faire au plus propre possible (organiser qu'on se perde pas quand
// on veut add des modules
// 0.0027f  = p * (b / (M * S * T))
// 10 / (2 * 60 * 30)

public class GameManager : MonoBehaviour
{
	private float oxygen = Constants.CONS_OXY * 3;
	private float food = Constants.CONS_FOOD * 5;
	private float energy = Constants.B_ENERGY;
	private float fortynium = Constants.B_FORTYNIUM;

	private const float oxy_cons = Constants.CONS_OXY / (60 * Constants.FRAME_RATE);
	private const float food_cons = Constants.CONS_FOOD / (60 * Constants.FRAME_RATE);

	private float consomation_oxygen;
	private float consomation_food;

	private const float prod_oxygen = (Constants.PROD_OXY_TILE / (60 * Constants.FRAME_RATE));
	private const float prod_food = (Constants.PROD_FOOD_TILE);
	private const float prod_human = Constants.PROD_HUMAN / (60 * Constants.FRAME_RATE);
	private const float	prod_tank_oxy = (Constants.OXYGEN_TANK_SIZE * 1000);

	private int tiles_tree = 0;
	private int tiles_rocket = 0;
	private int tiles_wheat = 0;
	private int tank_oxygen = 0;
	private float humans = Constants.B_HUMANS * 10f;
	private int humanConsumed;
	private int availableHumans = Constants.B_HUMANS * 10;

	public TextMeshProUGUI oxygenText;
	public TextMeshProUGUI foodText;
	public TextMeshProUGUI energyText;
	public TextMeshProUGUI fortyniumText;
	public TextMeshProUGUI humanText;
	public TextMeshProUGUI availableHumansText;

	public GameObject BuildMenu;
	public GameObject PanelBuildMenu;
	public GameObject MainUI;
	public GameObject modules;


	void Start()
	{
		availableHumans = (int)humans - humanConsumed;
		Debug.Log(food_cons);
		Application.targetFrameRate = Constants.FRAME_RATE;
		UpdateUi();
	}
	void Update()
	{
		if (oxygen < tank_oxygen * prod_tank_oxy)
		{
			oxygen += tiles_tree * prod_oxygen;
		}
		food += tiles_wheat * prod_food;
		consomation_oxygen = (humanConsumed + availableHumans) * oxy_cons;
		consomation_food = (humanConsumed + availableHumans) * food_cons;
		humans += Manager.Data.rocket_list.Count * prod_human;
		if (oxygen > 0)
			oxygen -= consomation_oxygen;
		if (food > 0)
			food -= consomation_food;

		oxygen = oxygen > 0 ? oxygen : 0;
		food = food > 0 ? food : 0;
		UpdateUi();
	}

	void UpdateUi()
	{
		oxygenText.text = ((int)(oxygen)).ToString();
		foodText.text = ((int)(food)).ToString();
		energyText.text = $"Energy : {energy}";
		fortyniumText.text = $"Fortynium: {fortynium}";
		humanText.text = ((int)(humans)).ToString();
		availableHumansText.text = ((int)(availableHumans)).ToString();
	}
	IEnumerator Launch_oxygen()
	{
		oxygen -= 1000;
		yield return new WaitForSeconds(20);
		oxygen += 10000;
		availableHumans += 1;
		tiles_rocket += 1;
		UpdateUi();
	}

	IEnumerator Launch_people()
	{
		yield return new WaitForSeconds(5);
		tiles_rocket += 1;
		UpdateUi();
	}
	// todo either add a button either add a random for people / oxygen
	public void CollectOxygen()
	{
		if (tiles_rocket > 0)
		{
			tiles_rocket -= 1;
			foreach (var t in Manager.Data.rocket_list)
			{
				Debug.Log(t);
			}
			StartCoroutine(Launch_people());
		}
		else
		{
			Notify.Alert.printInfo("Impossible d'envoyer des explorateurs sans qu'ils ne soient disponibles !");
		}

	}
	public void OpenCloseBuildMenu(bool active)
	{
		MainUI.SetActive(!active);
		modules.SetActive(!active);
		BuildMenu.SetActive(active);
	}

	public void Add_tree(int i)
	{
		tiles_tree += i;
	}
	public void Add_wheat(int i)
	{
		tiles_wheat += i;
	}
	public void Add_rocket(int i)
	{
		tiles_rocket += i;
	}
	public void Add_tank(int i)
	{
		tank_oxygen += i;
	}
	public void Add_human(int i)
	{
		humans += i;
		availableHumans += i;
	}
	public void Consume_human(int i)
	{
		humanConsumed += i;
		availableHumans -= i;
	}
	public float get_availableHumans()
	{
		return (availableHumans);
	}
	public float get_oxy()
	{
		return (oxygen);
	}
	public void Add_oxy(int i)
	{
		oxygen += i;
	}
}