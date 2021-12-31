using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeManager : MonoBehaviour
{
    // FadeManagerを作ったかどうか
    public static bool fadeMaked = false;

    [SerializeField, Tooltip("FadeImage")]
    Image _fadeImage;

    private static Image _fadeImageStatic;

    public delegate void FadeOutDelegate();
    public static event FadeOutDelegate FadeOutEvent;

    void Start()
    {
        if(fadeMaked == false)
        {
            DontDestroyOnLoad(this);
            fadeMaked = true;

            _fadeImageStatic = _fadeImage;
            _fadeImageStatic.raycastTarget = false;
            
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        
    }

    // フェードイン
    public static void FadeIn()
    {
        _fadeImageStatic.color = new Color(_fadeImageStatic.color.r, _fadeImageStatic.color.g, _fadeImageStatic.color.b, 1.0f);
        _fadeImageStatic.raycastTarget = true;

        _fadeImageStatic
            .DOFade(0.0f, 1.0f)
            .OnComplete(OnCompleteFadeIn);

        // DOPplayでいいのかわからん
        _fadeImageStatic.DOPlay();
    }

    // フェードアウト
    public static void FadeOut()
    {
        _fadeImageStatic.color = new Color(_fadeImageStatic.color.r, _fadeImageStatic.color.g, _fadeImageStatic.color.b, 0.0f);
        _fadeImageStatic.raycastTarget = true;

        _fadeImageStatic
            .DOFade(1.0f, 1.0f)
            .OnComplete(OnCompleteFadeOut);

        // DOPplayでいいのかわからん
        _fadeImageStatic.DOPlay();
    }

    // フェードアウト完了イベント
    private static void OnCompleteFadeOut()
    {
        FadeOutEvent?.Invoke();
        Completed();
        FadeIn();
    }

    // フェードイン完了イベント
    private static void OnCompleteFadeIn()
    {
        _fadeImageStatic.raycastTarget = false;
    }

    // イベントの中身を破棄
    private static void Completed()
    {
        FadeOutEvent = null;
    }
}
