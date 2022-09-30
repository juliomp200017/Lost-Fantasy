using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min,seg;
    [SerializeField] Text tiempo;

    private float acumulador;
    private bool activo;
    // Start is called before the first frame update
    private void Awake()
    {
        acumulador = (min * 60) + seg;
        activo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            acumulador += Time.deltaTime;
            int temMin = Mathf.FloorToInt(acumulador / 60);
            int temSeg = Mathf.FloorToInt(acumulador % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", temMin, temSeg);
        }

        
    }
}
