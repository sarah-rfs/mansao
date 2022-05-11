﻿using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

public class GameManager : MonoBehaviour{

public BoardManager boardScript;

private int level = 3;

void Awake(){
	boardScript = GetComponent<BoardManager>();
	InitGame();
}

void InitGame(){
	boardScript.SetupScene(level);
}

void Update(){

}
}
