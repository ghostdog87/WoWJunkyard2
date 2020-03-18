# WoWJunkyard2
Course project for Softuni - ASP.NET Core and Vue JS 2020

## Type - WoW Information Site

## Description

This is Web page that gives information about characters in World of Warcraft.
It provides the following  information: character items, character progress in mythic dungeons,
detailed information about characters. 
Shows the details for each character item.
Search bar to find characters.

## Profiles
### Admin:
	email: admin@admin.bg
	password: admin
### User:
	email: user@user.bg
	password: user

## Entities

### User
  - Id (string)
  - Username (string)
  - Password (string)
  - Email (string)
  - WoWAccount (Account)
  - Settings (Settings)

### Character
  - Id (Integer)
  - Level (Integer)
  - Items (List of Items)
  - Price (Decimal)
  - Dungeons (List of accomplished mythic dungeons)
  
### Item
  - Id (Integer)
  - Name (string)
  - ItemType (Enum head,chest,shoulders etc.) 
  
### Dungeon
  - Id (Integer)
  - Name (string)
  - AccomplishedLevel (integer - best accomplished level)


