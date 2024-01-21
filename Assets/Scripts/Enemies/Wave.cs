using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] GameObject normal;
    [SerializeField] GameObject fast;
    [SerializeField] GameObject heavy;

    [SerializeField] Transform normalSpawn;
    [SerializeField] Transform fastSpawn;
    [SerializeField] Transform heavySpawn;

    public event EventHandler GameWon;
    void Start()
    {
        StartCoroutine(PerformWave());

    }

    private IEnumerator PerformWave()
    {
        //Subwave 1
        yield return new WaitForSeconds(10f);

        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);

        yield return new WaitForSeconds(10f);

        //Subwave 2
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, fastSpawn.position, Quaternion.identity);

        yield return new WaitForSeconds(10f);

        // Subwave 3
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(heavy, heavySpawn.position, Quaternion.identity);

        yield return new WaitForSeconds(8f);

        // Subwave 4
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(heavy, heavySpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(heavy, heavySpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);

        yield return new WaitForSeconds(8f);

        // Subwave 5
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(heavy, heavySpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(heavy, heavySpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(normal, normalSpawn.position, Quaternion.identity);

        yield return new WaitForSeconds(8f);


        // Subwave 7
        Instantiate(heavy, heavySpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(heavy, heavySpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(heavy, heavySpawn.position, Quaternion.identity);


        yield return new WaitForSeconds(3f);

        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(fast, fastSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(10f);

        GameWon?.Invoke(this, EventArgs.Empty);

    }
}
