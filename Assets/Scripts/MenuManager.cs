using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public List<SandwichData> sandwiches; // Lista de todos os Scriptable Objects de sanduíche
    public SandwichData currentSandwich; // Sanduíche atual
    
    public int playerScore = 0;
    public Text scoreText;
    public Text endText;
    
    public Text sandwichNameText;
    public Image sandwichIcon;
    
    public Text ingredient1Text;
    public Text ingredient2Text;
    public Text ingredient3Text;
    public Image ingredient1Icon;
    public Image ingredient2Icon;
    public Image ingredient3Icon;

    private void Start()
    {
        // Inicializa o jogo pedindo um sanduíche aleatório
        RequestRandomSandwich();
    }

    public void RequestRandomSandwich()
    {
        // Seleciona um índice aleatório da lista de sanduíches
        int randomIndex = Random.Range(0, sandwiches.Count);
        // Atribui o sanduíche atual
        
        currentSandwich = sandwiches[randomIndex];
        // Atualiza a UI
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Atualiza a UI com os dados do sanduíche atual
        scoreText.text = "Score: " + playerScore;
        endText.text = "" + playerScore;
        sandwichNameText.text = currentSandwich.sandwichName;
        sandwichIcon.sprite = currentSandwich.icon;

        // Atualiza os ingredientes
        ingredient1Text.text = currentSandwich.ingredients[0].ingredientName;
        ingredient2Text.text = currentSandwich.ingredients[1].ingredientName;
        ingredient3Text.text = currentSandwich.ingredients[2].ingredientName;

        // Atualiza os ícones dos ingredientes
        ingredient1Icon.sprite = currentSandwich.ingredients[0].ingredientIcon;
        ingredient2Icon.sprite = currentSandwich.ingredients[1].ingredientIcon;
        ingredient3Icon.sprite = currentSandwich.ingredients[2].ingredientIcon;
    }

    public void IncreaseScore()
    {
        // Aumenta o score do jogador
        playerScore++;
    }
    
    public void DecreaseScore()
    {
        // Diminui o score do jogador, mas não pode ser menor que 0
        if (playerScore > 0)
            {
                playerScore--;
            }
    }
    
}
