using NUnit.Framework;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using System.Collections.Specialized;
using System.Collections;
using UnityEngine.Android;


// J'ai modif le fichier pour en faire deux classes distinctes et separer la gestion des ressources et la gestion des modules
// ca empeche pas qu'ils soient lies !
// Update : du coup en repensant a la gestion des ressources le mieux ca reste de faire  des classes imbriquees,
// sinon ca va etre trop la shit a gerer, faut essayer d'y faire au plus propre possible (organiser qu'on se perde pas quand
// on veut add des modules

//  0.0042f = 2(minutes) * 60(seconds) * 20(ticks / s)
public class GameManager : MonoBehaviour
{
	public const float consomation_oxygen = 0.0042f;
	public float oxygen = 10;
	public float food = 10;
	public float energy = 0;
	public float fortynium = 0;
	public int humans = 1;
	public int availableHumans = 1;


	public TextMeshProUGUI oxygenText;
	public TextMeshProUGUI foodText;
	public TextMeshProUGUI energyText;
	public TextMeshProUGUI fortyniumText;
	public TextMeshProUGUI humanText;
	public TextMeshProUGUI availableHumansText;

	void Start()
	{
		UpdateUi();
	}
	void Update()
	{
		//TODO : implement a logic to manage the constant loss of ressources.
		
		oxygen -= consomation_oxygen;
		food -= consomation_oxygen;

		oxygen = oxygen > 0 ? oxygen : 0;
		food = food > 0 ? food : 0;

		UpdateUi();
	}

	void UpdateUi()
	{
		oxygenText.text = $"oxygen : {oxygen:F1}";
		foodText.text = $"Food : {food:F1}";
		energyText.text = $"Energy : {energy}";
		fortyniumText.text = $"Fortynium: {fortynium}";
		humanText.text = $"Nb of Humans: {humans}";
		availableHumansText.text = $"Available Explorers : {availableHumans} / {humans}";
	}

	IEnumerator GatherOxygen()
	{
		yield return new WaitForSeconds(5);
		oxygen += 5;
		availableHumans += 1;
		UpdateUi();
	}

	public void CollectOxygen()
	{
		if (availableHumans > 0)
		{
			availableHumans -= 1;
			UpdateUi();
			StartCoroutine(GatherOxygen());
		}
		else
		{
			Notify.Alert.printInfo("Impossible d'envoyer des explorateurs sans qu'ils ne soient disponibles !");
		}

	}




}

