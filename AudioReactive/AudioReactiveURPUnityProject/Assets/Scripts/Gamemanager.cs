using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public void BackToMenu(){
        LoadScene("Menu");
    }

    public void LoadScene(string name){
        SceneManager.LoadScene(name);
    } 
}
