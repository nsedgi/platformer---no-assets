using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    private float currentposX, currentposY,currentposZ;
    private bool bossStage;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossStage==false)
            transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
        if (bossStage == true)
        {
            print("Collided with camera trigger");
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentposX, currentposY, currentposZ),ref velocity,speed *Time.deltaTime);
            
        }

    }
    public void setBossStage(bool bossStage)
    {
        this.bossStage = bossStage;
    }

    public void TraverseToBossStage(Transform newPosition,float tweakX, float tweakY, float zoom)
    {
        currentposX = newPosition.position.x+tweakX;
        currentposY = newPosition.position.y+tweakY;
        currentposZ = this.transform.position.z + zoom;
    }
}
