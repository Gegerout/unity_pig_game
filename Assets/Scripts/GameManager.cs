using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _block;

    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private GameObject _tapText;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private float _maxX;

    [SerializeField]
    private float _spawnRate;

    private bool gameStarted = false;
    private int _score;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();

            gameStarted = true;
            _tapText.SetActive(false);
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, _spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = _spawnPoint.position;
        spawnPos.x = Random.Range(-_maxX, _maxX);

        _player.AddSpeed();

        _block.GetComponent<Rigidbody2D>().gravityScale = _block.GetComponent<Rigidbody2D>().gravityScale + _score / 20;

        Instantiate(_block, spawnPos, Quaternion.Euler(0f, 0f, 180f));

        _score += 1;
        _scoreText.text = _score.ToString();
    }
}
