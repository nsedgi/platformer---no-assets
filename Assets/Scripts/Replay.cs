using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("New Unity Project");
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
