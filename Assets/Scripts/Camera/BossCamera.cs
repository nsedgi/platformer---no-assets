using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private float tweakX;
    [SerializeField] private float tweakY;
    [SerializeField] private float zoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cameraController.setBossStage(true);
            cameraController.TraverseToBossStage(this.transform,tweakX,tweakY,zoom);
        }
    }
}
