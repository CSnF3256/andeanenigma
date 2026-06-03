using UnityEngine;
using UnityEngine.EventSystems;

public class SemillaDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Datos de la semilla")]
    public string letraSemilla;

    [Header("Referencias")]
    public ModuloSemillasDragDrop manager;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 posicionInicial;
    private bool colocada = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        posicionInicial = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (colocada) return;

        canvasGroup.alpha = 0.75f;
        canvasGroup.blocksRaycasts = false;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (colocada) return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (colocada) return;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        bool encajo = manager.IntentarColocarSemilla(this);

        if (!encajo)
        {
            rectTransform.anchoredPosition = posicionInicial;
        }
        else
        {
            colocada = true;
        }
    }

    public void ColocarEn(Vector2 posicion)
    {
        rectTransform.anchoredPosition = posicion;
        colocada = true;
    }

    public void Reiniciar()
    {
        rectTransform.anchoredPosition = posicionInicial;
        colocada = false;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}