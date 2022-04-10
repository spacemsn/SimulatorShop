using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    private GameObject _enem1;
    private GameObject _enem2;
    private GameObject _enem3;
    private GameObject _enem4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(Random.Range(-1f, 50f), 1.0f, Random.Range(-18f, 18f));
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }

        if (_enem1 == null)
        {
            _enem1 = Instantiate(enemyPrefab) as GameObject;
            _enem1.transform.position = new Vector3(Random.Range(-1f, 50f), 1.0f, Random.Range(-18f, 18f));
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }

        if (_enem2 == null)
        {
            _enem2 = Instantiate(enemyPrefab) as GameObject;
            _enem2.transform.position = new Vector3(Random.Range(-1f, 50f), 1.0f, Random.Range(-18f, 18f));
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }

        if (_enem3 == null)
        {
            _enem3 = Instantiate(enemyPrefab) as GameObject;
            _enem3.transform.position = new Vector3(Random.Range(-1f, 50f), 1.0f, Random.Range(-18f, 18f));
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }

        if (_enem4 == null)
        {
            _enem4 = Instantiate(enemyPrefab) as GameObject;
            _enem4.transform.position = new Vector3(Random.Range(-1f, 50f), 1.0f, Random.Range(-18f, 18f));
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
