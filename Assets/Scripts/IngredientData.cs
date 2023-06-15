using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class IngredientData : ScriptableObject
{
    public string ingredientName;
    public Sprite ingredientIcon;
    public GameObject ingredientPrefab;
}
