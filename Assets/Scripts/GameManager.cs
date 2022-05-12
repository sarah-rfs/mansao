using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BoardManager boardScript;
    private int level = 3;

    void Awake()
    {
        // Tentar pegar o componente de boardscript
        boardScript = GetComponent<BoardManager>();

        // Chamar a inicialização do gamezito vulgo primeiro lvl
        InitGame();
        
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
