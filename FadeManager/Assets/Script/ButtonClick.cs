using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // クリックしたら
    public void OnPointerClick(PointerEventData eventData)
    {
        FadeManager.FadeOutEvent += GoToTestScene;
        FadeManager.FadeOut();
    }

    // ゲームシーンに移動
    private void GoToTestScene()
    {
        SceneManager.LoadScene("Test");
    }
}
