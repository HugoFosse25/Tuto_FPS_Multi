using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]     //Le script ne peut pas fonctionner sans PlayerMotor
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float mouseSensitivityX = 10f;
    [SerializeField] private float mouseSensitivityY = 8f;

    private PlayerMotor motor;

    private void Start() 
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //Calculer la vélocité (vitesse) du mouvement de notre joueur

        float _xMov = Input.GetAxisRaw("Horizontal");    //Raw pour enlever lissage du déplacement
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);  //On passe la vélocité a PlayerController pour qu'il éffectue réellemment le mouvement

        //On calcule la rotation du joueur en un Vector3

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0, _yRot, 0) * mouseSensitivityX;

        motor.Rotate(_rotation);    //On passe la rotation du joueur a PlayerController pour qu'il éffectue réellemment le mouvement

        //On calcule la rotation de la caméra en un Vector3

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0, 0) * mouseSensitivityY; //On passe la rotation de la caméra a PlayerController pour qu'il éffectue réellemment le mouvement

        motor.RotateCamera(_cameraRotation);
    }
}
