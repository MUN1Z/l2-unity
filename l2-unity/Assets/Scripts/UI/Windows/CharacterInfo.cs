using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterInfo : MonoBehaviour
{

    private VisualTreeAsset _testUITemplate;
    public VisualElement minimal_panel;
    private bool isHide;
    private VisualElement rootWindow;
    private VisualElement content;
    private ButtonCharacter _buttonCharacter;


    public void Start()
    {
        if (_testUITemplate == null)
        {
            _testUITemplate = Resources.Load<VisualTreeAsset>("Data/UI/_Elements/Windows/CharacterInfo");
        }

        if (_testUITemplate == null)
        {
            Debug.LogError("Could not load status window template.");
        }
    }

    private static CharacterInfo _instance;
    public static CharacterInfo Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _buttonCharacter = new ButtonCharacter(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddWindow(VisualElement root)
    {
        if (_testUITemplate == null)
        {
            return;
        }


        StartCoroutine(BuildWindow(root));
    }


    public IEnumerator BuildWindow(VisualElement root)
    {
        var testUI = _testUITemplate.Instantiate()[0];
        
        
        //closeButton = testUI.Q<VisualElement>(className: "btn-close-frame");
        rootWindow = testUI.Q<VisualElement>(className: "windows");

        var dragArea = testUI.Q<VisualElement>(className: "drag-area");
        content = testUI.Q<VisualElement>(className: "content");
        _buttonCharacter.RegisterButtonCloseWindow(rootWindow, "btn-close-frame");
        //MouseOverDetectionManipulator mouseOverDetection = new MouseOverDetectionManipulator(testUI);
        //testUI.AddManipulator(mouseOverDetection);

        DragManipulator drag = new DragManipulator(dragArea, testUI);
        dragArea.AddManipulator(drag);
        HideElements(true);

        root.Add(testUI);
        yield return new WaitForEndOfFrame();
    }



    public void HideElements(bool is_hide)
    {
        HideElements(is_hide, rootWindow);
    }

    public void HideElements(bool is_hide, VisualElement rootWindow)
    {
        if (is_hide)
        {
            isHide = is_hide;
            content.style.display = DisplayStyle.None;
            rootWindow.style.display = DisplayStyle.None;
        }
        else
        {
            isHide = is_hide;
            content.style.display = DisplayStyle.Flex;
            rootWindow.style.display = DisplayStyle.Flex;
        }
    }

    public bool isHideWindow()
    {
        return isHide;
    }





    private void OnDestroy()
    {
        _instance = null;
    }


}
