using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadAScene : MonoBehaviour
{
    public int whichScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void loadTHeScene()
    {
        SceneManager.LoadScene(whichScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
