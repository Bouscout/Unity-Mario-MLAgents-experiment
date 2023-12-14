# Objectives
First project of a series of experiments with the goal of having video games AI perform interesting behaviors in order to push the boundaries of what is possible for video games AI using possibly reinforcement learning.

## Requirements 
-Unity
-C#
-Microsoft visual studio (required to get type hints for unity framework)

## Description
In this project, we will have the mario character slowly climbing the ladders in order to reach the princess at the top. While in his quests, the vilain would be throwing different barils at him each able to randomly choose to climb down the ladder
 in order to reach mario.

 So mario would need to learn to jump over the barils and also to take the decisions to placed himself in a way to avoid uncoming barils with their random decisions.

 Mario (the agent) would be provided as a state, the position of the ladders and barils next to him in a certain radius, everytime he goes one level higher, he gets rewarded and everytime he gets hit by a baril or fall down, he gets a penalty.

 This is inspired by Cod bullet youtube videos, but I aim to go beyond what he did.
