//workaround to link PauseMenu script to ObjectClicker script. Hence this script is PauseMenuObjectClicker linker or PMOClinker
using UnityEngine;
public class PMOClinker : MonoBehaviour
{
    // Singleton instance
    public static PMOClinker instance = null;

    // Reference to ObjectClicker
    public ObjectClicker objectClicker;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //so it doesnt disappear
        DontDestroyOnLoad(gameObject);
    }
}
