﻿--select COUNT( Diet.DietType,Diet.DietName, Meal.Name,Meal.Type) from  Person, Diet, DietMeal, Meal where PersonID = 2 AND Diet.DietID = (select Person.DietID from Person where Person.PersonID = 2) AND (DietMeal.BreakFast = Meal.MealID OR DietMeal.Lunch = Meal.MealID OR DietMeal.Dinner = Meal.MealID)
insert into BloodTrack (HighBloodPressure,LowBloodPressure,TrackDate,PersonID) values (120,80,GETDATE(),2);