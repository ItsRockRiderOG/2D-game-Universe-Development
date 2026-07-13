using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float score = 0f;
    public float targetScore = 300f; // Set your target score here
    public float scoreMultiplier = 10f;
    public float thrustForce =1f;
    public float maxSpeed = 5f;
    Rigidbody2D rb; 
    public GameObject stationeryPose;
    public GameObject flyingPose;
    public UIDocument uiDocument;
    private Label scoreText;
    public GameObject explosionEffect;
    private Button restartButton;
    private Label targetText;
    private Label targetScoreText;
    public string targetWinText;
    public GameObject borderParent;
    public string nextSceneName; // Name of the next scene to load
    private Button nextButton;
    private Button mainMenu;
    public Animator transitionAnim; // Reference to the transition animator
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        stationeryPose.SetActive(true);
        flyingPose.SetActive(false);

        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        targetScoreText = uiDocument.rootVisualElement.Q<Label>("WinLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        targetText = uiDocument.rootVisualElement.Q<Label>("TargetLabel");
        nextButton = uiDocument.rootVisualElement.Q<Button>("NextButton");
        mainMenu = uiDocument.rootVisualElement.Q<Button>("MainMenuButton");

        restartButton.style.display = DisplayStyle.None; // Hide the restart button initially
        restartButton.clicked += ReloadScene; // Add listener to the restart button
        
        Time.timeScale = 1f; // Ensure the game is running at normal speed

        nextButton.style.display = DisplayStyle.None; // Hide the next button initially
        nextButton.clicked += NextScene; // Add listener to the next button
        
        targetScoreText.style.display = DisplayStyle.None; // Hide the target text initially

        nextButton.clicked += NextScene; // Add listener to the next button

        mainMenu.style.display = DisplayStyle.None; // Hide the next button initially
        mainMenu.clicked += LoadMainMenu; // Add listener to the main menu button

        

        

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score;
        
        targetText.text = "Target: " + targetScore;



        
        Debug.Log("Target: " + targetScore);
        targetScoreText.text = "You "+ targetWinText;
        TargetAchieved();
       

        if (Mouse.current.leftButton.isPressed)
        {
            // Calculate Mouse Direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;
            
            // Move player in mouse direction    
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
        }
            // PowerManav's transformation into flying pose when mouse button is pressed and back to stationery pose when released
        if (Mouse.current.leftButton.wasPressedThisFrame)
            {
            flyingPose.SetActive(true);
            stationeryPose.SetActive(false);
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
            flyingPose.SetActive(false);
            stationeryPose.SetActive(true);
            

        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex; // Show the restart button when the player is destroyed
        mainMenu.style.display = DisplayStyle.Flex;
        borderParent.SetActive(false); // Hide the border when the player is destroyed
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void TargetAchieved()
    {
        if (score >= targetScore)
        {
            // Player has reached the target score
            Debug.Log("Target Score Reached!");
            targetScoreText.style.display = DisplayStyle.Flex; // Show the target text when the target score is reached
            Time.timeScale = 0f; // Pause the game

            
            if (string.IsNullOrEmpty(nextSceneName))
            {
            nextButton.style.display = DisplayStyle.None;
            mainMenu.style.display = DisplayStyle.Flex;
            }
            else
            {
            nextButton.style.display = DisplayStyle.Flex;
            mainMenu.style.display = DisplayStyle.Flex;
            }
       
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }





}
