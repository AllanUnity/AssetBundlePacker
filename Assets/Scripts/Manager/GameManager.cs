using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Awake()
    {
        //此层次下的所有对象禁止被删除
        DontDestroyOnLoad(transform.gameObject);
    }

}
