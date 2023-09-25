/*
    When performing performance reviews not all scores are rated equally, for example a school may choose to set 
    that a student who scores very highly in "maths" but low in "science" has achieved higher overall than a 
    student that has scored highly in "science" but low in "maths". 
    
    We take this into account by providing a "Weight" to "Scores". This Weight represents how each score should 
    be compared to each other score when computing the average. 
    
    Please write a C# function that takes list of WeightedScores and responds with a calculated average that takes into account "Weight".  
*/

using System;
using System.Collections.Generic;

public class Solution
{
    
    public static void Main(string[] args)
    {
        var scores = new List<WeightedScore>() {
            new WeightedScore() { Score = 10, Weight = 0.3M },
            new WeightedScore() { Score = 8, Weight = 1M }  
        };
        var avg = GetCalculatedAverage(scores);
        Console.WriteLine(avg);
    }
    
    // Method Signature: 
    public static decimal GetCalculatedAverage(List<WeightedScore> scores)
    {
        if(scores == null || scores.Count == 0){
            throw new ArgumentException("List of scores is null or empty");
        }
        
        decimal totalScore = 0;
        decimal totalWeight = 0; 

        foreach(var score in scores){

            if(score.Score < 0 || score.Score > 10 || score.Weight < 0 || score.Weight > 1){
                throw new ArgumentException("Invalid score or weight values"); 
            }

            totalScore += score.Score * score.Weight;
            totalWeight += score.Weight;
        }

        if(totalWeight == 0){
            throw new InvalidOperationException("Weight is zero, we can't divide by zero");
        } 

        decimal average = totalScore / totalWeight;

        return average; 
        /*....*/
    }
}


public class WeightedScore
{
    // A decimal between 0.0 and 10.0 representing the score 
    public decimal Score;


    // A decimal between 0.0 and 1.0 representing the relative weight of the score 
    public decimal Weight;
}
