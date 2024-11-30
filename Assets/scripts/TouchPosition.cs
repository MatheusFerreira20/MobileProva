using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPosition : MonoBehaviour
{
    public GameObject player;
    public float accelerometerSensitivity = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
#if PLATFORM_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main
                    .ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            player.transform.position = touchPosition;
            Handheld.Vibrate();
        }

        Vector3 acceleration = Input.acceleration;
        Vector3 movement = new Vector3(acceleration.x, 0, 10) * accelerometerSensitivity;
        player.transform.Translate(movement * Time.deltaTime);
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPosition = Camera.main
                    .ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            player.transform.position = touchPosition;
        }
#endif
    }
}