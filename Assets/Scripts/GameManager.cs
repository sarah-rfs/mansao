using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private BoardManager boardScript;
    private int level = 3;

    void Awake()
    {

        if (instance == null)
        instance = this;

        else if (instance != this)
        Destroy (gameObject);

        DontDestroyOnLoad (gameObject);

        // Tentar pegar o componente de boardscript
        boardScript = GetComponent<BoardManager>();

        // Chamar a inicializacao do gamezito vulgo primeiro lvl
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
