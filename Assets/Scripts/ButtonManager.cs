using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is used for Managing different Button clicks
public class ButtonManager : MonoBehaviour
{
    
    public void StartLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
