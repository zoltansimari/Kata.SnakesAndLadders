# Summary

This a implementation attempt for the [Snakes and Ladders Kata](http://agilekatas.co.uk/katas/SnakesAndLadders-Kata), for interviewing purpose. To learn more, follow the link.

# Approach

I was driven by the criteria described on the Agile Kata page. I have started with the tests and tried to apply **OOP/SOLID** principles on top to end up with the current structure. I felt (potentially intentional) ambiguity reading the acceptance criteria, so I mostly shaped my classes based on what the game would look like in real life and the **attributes these objects would have**. 

I tried to follow both **TDD & DDD** while coding this kata.   

# Structure

- **CommandLine project**: the only executable which only here to demonstrate the *game* running
- **Domain project**: all the types (and their related interfaces) that would be part of the *DSL*
- **Tests project**: all tests that are defined on the kata page

# How To Run

The command line application is a simple *.NET Core 2.1* application, therefore a simple **'dotnet run'** command will do in its directory if you have the SDK installed. The tests are written using **NUnit**.

# Future Changes

Without implementing any other features of the kata or adding any other non-functional requirements there is still space for improvement. There could plenty more test written (mostly thinking about edge cases/validating the guard clauses) and adding some comments/documentation.

Thinking about adding futures, I would revisit access modifiers and general ownership. Would potentially try to abstract the rules of the game.

The first feature doesn't tackle the name giver *snakes and ladders* but my initial thought about how I would implement it, lead to an array with length of each possible position and the number at place would define by how much the position should change. For instance if there is a snake from square #66 to #60 then `snakesAndLadders[65] = -6;`. Of course, this would raise optimisation questions.
