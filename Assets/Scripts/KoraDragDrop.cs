using UnityEngine;
using UnityEngine.EventSystems;

public class KoraDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform slotCorrecto;
    public MiniHistoriaManager historiaManager;
    public float distanciaParaEncajar = 80f;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 posicionInicial;
    private bool colocado = false;

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
        if (colocado) return;

        canvasGroup.alpha = 0.75f;
        canvasGroup.blocksRaycasts = false;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (colocado) return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (colocado) return;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        float distancia = Vector2.Distance(rectTransform.anchoredPosition, slotCorrecto.anchoredPosition);

        if (distancia <= distanciaParaEncajar)
        {
            rectTransform.anchoredPosition = slotCorrecto.anchoredPosition;
            colocado = true;

            if (historiaManager != null)
            {
                historiaManager.ActivarKoraCompletado();
            }
        }
        else
        {
            rectTransform.anchoredPosition = posicionInicial;
        }
    }
}