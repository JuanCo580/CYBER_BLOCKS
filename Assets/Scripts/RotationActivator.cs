using UnityEngine;

public class RotationActivator : MonoBehaviour
{
    [Tooltip("El GameObject que quieres prender o apagar. Si lo dejas vac�o, se usar� el mismo objeto que tiene este script.")]
    public GameObject objectRotate, objectOff;

    void Start()
    {
      
    }

    void Update()
    {
        // Obtenemos los �ngulos de rotaci�n en el formato Euler (de 0 a 360 grados).
        float rotationX = transform.eulerAngles.x;

        // La condici�n para estar "apagado" es cuando el objeto ha girado m�s all� de 90 grados
        // pero sin completar la vuelta (es decir, est� "boca abajo").
        // Esto corresponde a un rango entre 90 y 270 grados.
        if (rotationX > 90 && rotationX < 270)
        {
            // Si el objeto est� activo, lo apagamos.
            if (objectRotate.activeSelf)
            {
                objectOff.SetActive(false);
            }
        }
        else
        {
            // Si no cumple la condici�n anterior (est� "boca arriba"), lo prendemos.
            if (!objectRotate.activeSelf)
            {
                objectOff.SetActive(true);
            }
        }
    }
}
