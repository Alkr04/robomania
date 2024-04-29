using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public string scean = "SampleScene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void exit()
    {
        Application.Quit();
    }
    public void start()
    {
        SceneManager.LoadScene(scean, LoadSceneMode.Single);
    }
}
