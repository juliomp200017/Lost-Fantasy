using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class TimeController : MonoBehaviour
{
    int min,seg;
    [SerializeField] Text tiempo;

    public string MinPrefebsName = "Min";
    public string SegPrefebsName = "Seg";
    private float acumulador;
    private bool activo;
    //private GameState gameState = GameState.star;
    // Start is called before the first frame update
    private void Awake()
    {
        LoadData();
        //acumulador = (min * 60) + seg;
        activo = true;
    }


    // Update is called once per frame
    void Update()
    {
        //switch (gameState)
        //{
        //    case GameState.star:
        //        break;
        //    case GameState.play:
        //        break;
        //    case GameState.over:
        //        break;
        //    default:
        //        break;
        //}
        if (activo)
        {
            acumulador += Time.deltaTime;
            int temMin = Mathf.FloorToInt(acumulador / 60);
            int temSeg = Mathf.FloorToInt(acumulador % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", temMin, temSeg);
            SaveData(temMin, temSeg);
        }

        
    }


    private void SaveData(int minu, int segu)
    {
        PlayerPrefs.SetInt(MinPrefebsName, minu);
        PlayerPrefs.SetInt(SegPrefebsName, segu);
    }

    private void LoadData()
    {

        min = PlayerPrefs.GetInt(MinPrefebsName, 0);
        seg = PlayerPrefs.GetInt(SegPrefebsName, 0);
    }

    public enum GameState
    {
        star,
        play,
        over
    }

}
