using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  QualitySettings.vSyncCount = 0;
      //  Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + 3.0f*horizontalMovement*Time.deltaTime;
        position.y = position.y + 3.0f * verticalMovement*Time.deltaTime;
        transform.position = position;
    }
}
