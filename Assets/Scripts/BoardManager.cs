using UnityEngine;
using System;
//Allows us to use Lists.
using System.Collections.Generic;
//Tells Random to use the Unity Engine random number generator.
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour{

[Serializable]
public class Count{
    public int minimum;
    public int maximum;


public Count (int min, int max){
    minimum = min;
    maximum = max;
}
}

public int columns = 8; //Colunas do tabuleiro
public int rows = 8; // Linhas do tabuleiro
public Count wallCount = new Count (5,9); // quantidade aleatoria para numeros internos
public Count foodCount = new Count (1,5); // quantidade aleatoria da comida
public GameObject exit;
public GameObject[] floorTiles;// Chao do cenario
public GameObject[] wallTiles; // Parede do cenario
public GameObject[] foodTiles; // Las comiditazitas
public GameObject[] enemyTiles; // inimigos malandros
public GameObject[] outerWallsTiles; // as outerwalls(outerwall eh triste)

public Transform boardHolder;// variavel q vai pendurar geral no tabuleiro
public List <Vector3> gridPosition = new List<Vector3>(); // possiveis posicoes dos tiles (em uma lista :D)

// Isso aqui serve para limpar a lista do grid e comecar a gerar um novo cenario
void initialiseList(){
    gridPosition.Clear();

for(int x = 1; x < columns - 1; x++){
    for(int y = 1; y < rows - 1; y++){
        gridPosition.Add(new Vector3(x,y,0f));
    }
}
}
//Configurar muros externos e chao
void BoardSetup()
{
    boardHolder = new GameObject("Board").transform;

    for (int x = -1; x <= columns; x++){
        for (int y = -1; y <= rows; y++)
        {
            GameObject toInstantiate = floorTiles[Random.Range(0,floorTiles.Length)];   

            if(x == -1 || y == -1 || x == columns || y == rows)
                toInstantiate = outerWallsTiles[Random.Range(0,outerWallsTiles.Length)];

            GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0f), Quaternion.identity) as GameObject;

            instance.transform.SetParent(boardHolder);   
            }
    }
}

//Retornar valor aleatorio da grid
Vector3 RandomPosition()
{
    int randomIndex = Random.Range(0, gridPosition.Count);

    Vector3 randomPosition = gridPosition [randomIndex];

    gridPosition.RemoveAt (randomIndex);

    return randomPosition;
}

// Pegar array de objetos
void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
{
    int objectCount = Random.Range (minimum, maximum);
    for (int i = 0; i < objectCount; i++)
    {
        Vector3 randomPosition = RandomPosition ();
        GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
        Instantiate(tileChoice, randomPosition, Quaternion.identity);
    }
}

public void SetupScene(int level)
{
    //coloca quadradinhos
    BoardSetup ();
    //inicializa grid
    initialiseList();
    //instanciar numero aleatorio de muros internos
    LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
    //Instanciar um numero aleatorio de comidas
    LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);

    // instanciar o numero de inimigos baseado no lvl da fase (Base 2)
    int enemyCount = (int)Mathf.Log (level, 2f);
    LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);

    // instanciar a saida
    Instantiate (exit, new Vector3 (columns-1, rows-1,0f), Quaternion.identity);
}
}