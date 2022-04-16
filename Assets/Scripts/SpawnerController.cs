using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    float _xPos, _yPos;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawner", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void EnemySpawner()
    {
        _xPos = Random.Range(-6, 6);
        _yPos = Random.Range(-4, 4);
        Instantiate(_enemy, new Vector2(_xPos, _yPos), transform.rotation, transform);
    }
}
