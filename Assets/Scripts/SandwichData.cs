using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sandwich", menuName = "Sandwich")]
public class SandwichData : ScriptableObject
{
    public string sandwichName; // Nome do sanduíche
    public Sprite icon; // Ícone do sanduíche
    public IngredientData[] ingredients; // Array de ingredientes do sanduíche
}
