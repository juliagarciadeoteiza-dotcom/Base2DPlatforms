using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //PROGRAMAR LA CAMARA
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed;

    void Start()
    {
        
        transform.position = playerTransform.position - offset;


    }

    void Update()
    {

        // transform.position = playerTransform.position - offset;

        //para suavizar la transicion de la camara, usamos Lerp
        //despues le asignamos la velocidad que queremos que tenga la camara para seguir al jugador
        transform.position = Vector3.Lerp(transform.position, playerTransform.position - offset, speed);

    }
}
