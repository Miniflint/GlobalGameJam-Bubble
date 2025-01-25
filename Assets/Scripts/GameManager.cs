using NUnit.Framework;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using System.Collections.Specialized;
using System.Collections;
using UnityEngine.Android;
using UnityEngine.Timeline;


// J'ai modif le fichier pour en faire deux classes distinctes et separer la gestion des ressources et la gestion des modules
// ca empeche pas qu'ils soient lies !
// Update : du coup en repensant a la gestion des ressources le mieux ca reste de faire  des classes imbriquees,
// sinon ca va etre trop la shit a gerer, faut essayer d'y faire au plus propre possible (organiser qu'on se perde pas quand
// on veut add des modules
// 0.0027f  = p * (b / (M * S * T))
// 10 / (2 * 60 * 30)
public class GameManager : MonoBehaviour
{
    private float oxygen = Constants.CONS_OXY;
    private float food = Constants.CONS_FOOD;
    private float energy = Constants.B_ENERGY;
    private float fortynium = Constants.B_FORTYNIUM;
    private int humans = Constants.B_HUMANS;
    private int availableHumans = Constants.B_HUMANS;
	private int i = 0;
	
	private const float oxy_cons = Constants.CONS_OXY / (60 * Constants.FRAME_RATE);
    private const float food_cons = Constants.CONS_FOOD / (60 * Constants.FRAME_RATE);

    private float consomation_oxygen;
    private float consomation_food;

    public TextMeshProUGUI oxygenText;
	public TextMeshProUGUI foodText;
	public TextMeshProUGUI energyText;
	public TextMeshProUGUI fortyniumText;
	public TextMeshProUGUI humanText;
	public TextMeshProUGUI availableHumansText;


    void Start()
    {
        Debug.Log(food_cons);
        Application.targetFrameRate = Constants.FRAME_RATE;
        UpdateUi();
	}
	IEnumerator Teeeeee()
	{
		yield return new WaitForSeconds(1);
		Debug.Log(i);
		i = 0;
	}
	void Update()
    {
		i += 1;
        consomation_oxygen = availableHumans * oxy_cons;
        consomation_food = availableHumans * food_cons;
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
		oxygenText.text = $"oxygen : {oxygen:F1}";
		foodText.text = $"Food : {food:F1}";
		energyText.text = $"Energy : {energy}";
		fortyniumText.text = $"Fortynium: {fortynium}";
		humanText.text = $"Nb of Humans: {humans}";
		availableHumansText.text = $"Available Explorers : {availableHumans} / {humans}";
	}
    IEnumerator GatherOxygen()
	{
        oxygen -= 1000;
        yield return new WaitForSeconds(5);
		oxygen += 5000;
		availableHumans += 1;
		UpdateUi();
	}

	public void CollectOxygen()
	{
		if (availableHumans > 0)
		{
			availableHumans -= 1;
			StartCoroutine(GatherOxygen());
		}
		else
		{
			Notify.Alert.printInfo("Impossible d'envoyer des explorateurs sans qu'ils ne soient disponibles !");
		}

    }

}

