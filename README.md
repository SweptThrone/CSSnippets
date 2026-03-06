# CSSnippets
*A collection of small utility scripts written in C#.*

## AccessLogParser
Takes a standard website traffic log and outputs a .cheatwanters file containing  
a list of IP addresses of visits to a specific file on my website.  
I made a video of me using fake cheats in a game and put a download link in the  
description.  It led to a trollface PNG.  This program finds how many people did  
that just because I really like statistics.

## NPCToPlayerModel
Takes a folder of Garry's Mod or Source Engine NPC models and recursively turns  
them all into valid Garry's Mod playermodels.  This program is DESTRUCTIVE, it  
finds NPC models and edits the files themselves to change them.

## RomanNumeralTranslator
Takes a number and outputs the Roman numeral notation for it.  Has no actual  
limit but anything over 3999 is technically invalid.

## TrafficTracker
Very similar to the poorly-named AccessLogParser.  Analyzes a web traffic log  
and outputs how many visits each of my Garry's Mod addons has received based on  
hits on images embedded in each page.  Once gain, made simply because I really  
like statistics.

## WeaponUnpacker
Takes a Garry's Mod weapon folder structured like `weapon_class/shared.lua` and  
turns it into a single file named `weapon_class.lua`.  Functionally, there is no  
difference but individual files are easier to open in bulk.
