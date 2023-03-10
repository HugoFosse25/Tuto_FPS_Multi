using UnityEngine;

[RequireComponent(typeof(Rigidbody))]     //Le script ne peut pas fonctionner sans Rigidbody
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]private Camera cam;

   private Vector3 velocity;
   private Vector3 rotation;
   private Vector3 cameraRotation;
   private Rigidbody rb;

   private void Start()
   {
        rb = GetComponent<Rigidbody>();
   }

   public void Move(Vector3 _velocity)
   {
        velocity = _velocity;
   }

   public void Rotate(Vector3 _rotation)
   {
        rotation = _rotation;
   }

   public void RotateCamera(Vector3 _cameraRotation)
   {
        cameraRotation = _cameraRotation;
   }

   private void FixedUpdate()
   {
        PerformMovement();
        PerformRotation();
   }

   private void PerformMovement()
   {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }
   }

   private void PerformRotation()
   {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));  //Euler = Converti un Vector3 en Quaternion ; Rotation sur l'axe gauche droite
        cam.transform.Rotate(-cameraRotation);  //
   }
}
