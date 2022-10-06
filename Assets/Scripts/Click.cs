using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Click : MonoBehaviour
{

    // [SerializeField] private Camera _cam;
    private Vector2 _target;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private TMP_Text _startExtortion;

    private void Start() {
        _target = transform.position;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0)) {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(target.y <= 0) {
                _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        float step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _target, step);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _enemy.SetActive(false);
        _startExtortion.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    
}