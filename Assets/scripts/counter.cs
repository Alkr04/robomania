using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class counter : MonoBehaviour
{
    int scean;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] manager = GameObject.FindGameObjectsWithTag("Counter");
        if (manager.Length > 1)
        {
            Destroy(this.gameObject);
        }
        scean = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            exit();
        }
        else if (Input.GetKey(KeyCode.Return))
        {
            restart();
        }
    }

    public void exit()
    {
        Application.Quit();
    }
    public void restart()
    {
        SceneManager.LoadScene(scean);
    }
}
