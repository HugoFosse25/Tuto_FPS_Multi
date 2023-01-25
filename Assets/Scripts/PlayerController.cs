using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]     //Le script ne peut pas fonctionner sans PlayerMotor
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private PlayerMotor motor;

    private void Start() 
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //Calculer la vélocité (vitesse) du mouvement de notre joueur
        float _xMov = Input.GetAxisRaw("Horizontal");    //Raw pour enlever filtre de déplacement
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;
    }
}
