using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Image panelImage;
    public float maxAlpha = 0.8f;
    public float alphaChangeSpeed = 0.5f;
    public string sceneToLoad;

    private bool playerDetected = false;
    private bool sceneChangeInProgress = false;

    void Update()
    {
        if (sceneChangeInProgress) return;

        if (playerDetected)
        {
            // Incrementar gradualmente el alpha del panel hasta alcanzar maxAlpha
            if (panelImage != null)
            {
                panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, Mathf.MoveTowards(panelImage.color.a, maxAlpha, alphaChangeSpeed * Time.deltaTime));
            }

            // Si el alpha llega al máximo, cargar la nueva escena
            if (panelImage != null && panelImage.color.a == maxAlpha)
            {
                sceneChangeInProgress = true;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else
        {
            // Disminuir gradualmente el alpha del panel hasta llegar a 0
            if (panelImage != null)
            {
                panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, Mathf.MoveTowards(panelImage.color.a, 0f, alphaChangeSpeed * Time.deltaTime));
            }
        }
    }

    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;
    }
}
