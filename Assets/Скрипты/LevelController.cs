using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Serializable classes
[System.Serializable]
public class EnemyWaves 
{
    [Tooltip("time for wave generation from the moment the game started")]
    public float timeToStart;

    [Tooltip("Enemy wave's prefab")]
    public GameObject wave;
}

#endregion

public class LevelController : MonoBehaviour {

    //Скрипт который отвечает за спавно волн врагов, бонусов и планет на задний план
    public EnemyWaves[] enemyWaves; 

    public GameObject powerUp;
    public float timeForNewPowerup;
    public GameObject[] planets;
    public float timeBetweenPlanets;
    public float planetsSpeed;
    List<GameObject> planetsList = new List<GameObject>();

    Camera mainCamera;   

    private void Start()
    {
        mainCamera = Camera.main;
        //для каждой волны врагов создаем процендуру спавна
        for (int i = 0; i<enemyWaves.Length; i++) 
        {
            StartCoroutine(CreateEnemyWave(enemyWaves[i].timeToStart, enemyWaves[i].wave));
        }
        StartCoroutine(PowerupBonusCreation());
        StartCoroutine(PlanetsCreation());
    }
    
    //Создаем новую волну после задержки
    IEnumerator CreateEnemyWave(float delay, GameObject Wave) 
    {
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        if (Player.instance != null)
            Instantiate(Wave);
    }

    //Генерация бонусв
    IEnumerator PowerupBonusCreation() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(timeForNewPowerup);
                Instantiate(
                    powerUp,
                    //Назвначаем позицию в пределах экрана
                    new Vector2(
                        Random.Range(PlayerMoving.instance.borders.minX, PlayerMoving.instance.borders.maxX),
                        mainCamera.ViewportToWorldPoint(Vector2.up).y + powerUp.GetComponent<Renderer>().bounds.size.y / 2),
                    Quaternion.identity
                    );
            
        }
    }

    IEnumerator PlanetsCreation()
    {
        //Создаем копию массива плане
        for (int i = 0; i < planets.Length; i++)
        {
            planetsList.Add(planets[i]);
        }
        yield return new WaitForSeconds(10);
        while (true)
        {
            //выбираем рандомную планету, спавним ее и удаляем с листа
            int randomIndex = Random.Range(0, planetsList.Count);
            GameObject newPlanet = Instantiate(planetsList[randomIndex]);
            planetsList.RemoveAt(randomIndex);
            //Если длинна листа равна 0 тогда пересоздаем
            if (planetsList.Count == 0)
            {
                for (int i = 0; i < planets.Length; i++)
                {
                    planetsList.Add(planets[i]);
                }
            }
            newPlanet.GetComponent<DirectMoving>().speed = planetsSpeed;

            yield return new WaitForSeconds(timeBetweenPlanets);
        }
    }
}
