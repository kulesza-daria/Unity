using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class BlockGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int blocksCount = 2;
    public GameObject block;
    public List<Material> materials = new List<Material>();
    Random random;

    void Start()
    {

        random = new Random();

        int scaleX = (int)transform.localScale.x*4;
        int scaleZ = (int)transform.localScale.z*4;
    

        List<int> pozycje_x = new List<int>(Enumerable.Range(0, scaleX*2).OrderBy(x => Guid.NewGuid()).Take(blocksCount));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, scaleZ*2).OrderBy(x => Guid.NewGuid()).Take(blocksCount));


        for (int i = 0; i < blocksCount; i++)
        {   
            this.positions.Add(new Vector3((pozycje_x[i]-scaleX), 1, (pozycje_z[i]-scaleZ)));
        }
      
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            GameObject blockGenerated = Instantiate(this.block, this.positions.ElementAt(positions.IndexOf(pos)), Quaternion.identity);

            int material = random.Next(0, materials.Count);
            var blockRenderer = blockGenerated.GetComponent<Renderer>();
            blockRenderer.material = materials[material];

            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
