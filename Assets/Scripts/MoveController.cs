using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    [SerializeField] GameObject _body;
    [SerializeField] Rigidbody2D _bodyRigid;
    [SerializeField] Text _scoreText;
    Animator _bodyAnim;
    float _turnSpeed = 1;
    int _score = 0;


    bool _rightMi = true;
    bool _leftMi = false;

    private void Awake()
    {
        _bodyAnim = GetComponentInParent<Animator>(); 
    }


    void Start()
    {
        _bodyRigid.velocity += new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            float _xPos = Random.Range(-5, 5);
            float _yPos = Random.Range(-5, 5);

            _bodyRigid.velocity += new Vector2(_xPos * 2 , _yPos * 2 );
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _body.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            _score += 1;
            _scoreText.text = ($"Score: {_score}");

            if (_turnSpeed <= 0.11f)
            {
                
            }
            else
            {
                _turnSpeed -= 0.1f;
                _bodyAnim.speed = _turnSpeed;
            }

            if (_rightMi)
            {
                _bodyAnim.Play("LeftMove");
               

                _rightMi = false;
                _leftMi = true;
            }
            else if (_leftMi)
            {
                _bodyAnim.Play("RightMove");
                _leftMi = false;
                _rightMi = true;
            }
            
            
            
            Destroy(collision.gameObject);
        }
    }
}
