using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManagerMaker : MonoBehaviour
{
    [SerializeField, Tooltip("FadeManager")]
    GameObject _fadeManager;

    void Start()
    {
        // フェードマネージャーが無かったら作成
        if(FadeManager.fadeMaked == false)
        {
            Instantiate(_fadeManager);
        }
    }

    void Update()
    {
        
    }
}
