using UnityEngine;

public class ObjectPlacerManager : MonoBehaviour
{
    #region Variables
    public static ObjectPlacerManager Instance;
    public ObjectPlacer CurrentObjectPlacer;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}