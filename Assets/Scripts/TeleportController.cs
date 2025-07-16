using UnityEngine;
using UnityEngine.UI; // Necesario para interactuar con la UI, como un Text.

public class TeleportController : MonoBehaviour
{
    [Tooltip("Arrastra aquí al objeto del jugador que se va a teletransportar.")]
    public Transform playerTransform;

    [Tooltip("La lista de todos los posibles destinos de teletransporte. El orden importa.")]
    public Transform[] destinations;

    void Start()
    {
        // Si no se asigna un jugador, el script asumirá que está en el propio jugador.
        if (playerTransform == null)
        {
            playerTransform = this.transform;
        }
    }

    /// <summary>
    /// Esta es la función pública que los botones llamarán.
    /// Teletransporta al jugador al destino correspondiente al índice proporcionado.
    /// </summary>
    /// <param name="index">El índice del destino en el array 'destinations'.</param>
    public void TeleportToIndex(int index)
    {
        // Primero, verificamos que el índice sea válido para evitar errores.
        if (index >= 0 && index < destinations.Length)
        {
            // Obtenemos el destino del array usando el índice.
            Transform targetDestination = destinations[index];

            // Movemos al jugador a la posición del destino seleccionado.
            // Se añade un pequeño offset vertical para no quedar atascado en el suelo.
            playerTransform.position = targetDestination.position + new Vector3(0, 1f, 0);

            Debug.Log($"✅ Teletransportado a: {targetDestination.name} (Índice {index})");
        }
        else
        {
            // Si el botón intenta llamar a un índice que no existe, mostramos una advertencia.
            Debug.LogWarning($"⚠️ ¡Índice de teletransporte inválido: {index}! Asegúrate de que el botón esté bien configurado y el destino exista en la lista.");
        }
    }
}