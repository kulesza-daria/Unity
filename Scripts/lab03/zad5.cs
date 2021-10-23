using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    public GameObject myPrefab;
    private int bokkwadratu = 10;
    public int ilosc = 10;

    void Start()
    {
        List<Vector3> tab = new List<Vector3>();
        for (int i = 0; i < bokkwadratu; i++)
        {
            for (int j = 0; j < bokkwadratu; j++)
            {
                tab.Add(new Vector3(i, 0, j));
            }
        }
        var rand = new System.Random();
        for (int i = 0; i < ilosc; i++)
        {
            int x = rand.Next(tab.Count);
            Instantiate(myPrefab, tab[x], Quaternion.identity);
            tab.RemoveAt(x);
        }
    }

}
