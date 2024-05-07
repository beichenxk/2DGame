using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Button newGame;
    public Button continueGame;
    public Button loadGame;
    public GameObject loadCanvas;
    public Button cancelButton;
    public Button saveButton1;
    public Button saveButton2;
    public Button saveButton3;
    void Start()
    {
        newGame.onClick.AddListener(BeginNewGame);
        continueGame.onClick.AddListener(delegate { ContinueGame("save1"); });
        loadGame.onClick.AddListener(LoadGame);
        cancelButton.onClick.AddListener(cancel);
        saveButton1.onClick.AddListener(delegate { ContinueGame("save1"); });
        saveButton2.onClick.AddListener(delegate { ContinueGame("save2"); });
        saveButton3.onClick.AddListener(delegate { ContinueGame("save3"); });
    }


    

    void BeginNewGame()
    {
        SceneManager.LoadScene("Map2");
        
        GamManager.Instance.LoadGame(String.Empty);
    }

    void ContinueGame(string saveAssetName)
    {
        SceneManager.LoadScene("Game");
        GamManager.Instance.LoadGame(saveAssetName);
        
    }

    void LoadGame()
    {
        loadCanvas.SetActive(true);
    }

    void cancel()
    {
        loadCanvas.SetActive(false);
    }
    
}
