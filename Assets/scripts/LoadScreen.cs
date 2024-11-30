using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button myButton;
    public TMP_InputField txtUsuario;

    void Start()
    {
        myButton.onClick.AddListener(OnButtonClick);
    }

 
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = touch.position;
                if (IsTouchOverButton(touchPosition))
                {
                    myButton.onClick.Invoke();
                }
            }
        }
    }
    bool IsTouchOverButton(Vector2 touchPosition)
    {
        RectTransform rectTransform = myButton.GetComponent<RectTransform>();
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touchPosition, null, out localPoint);
        return rectTransform.rect.Contains(localPoint);
    }
    public void OnButtonClick()
    {
        SceneManager.LoadScene("PrincipalScene");
    }
}
